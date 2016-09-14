using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace correlation
{
    class Program
    {
        static void Main(string[] args)
        {

            int e = 40240000;
            double[] A = new double[e];
            double[][] R = new double[e][];
            Random rand = new Random();
            for (int i = 0; i < A.Length; i++)
            {
                A[i] = rand.Next();
            }
            Stopwatch stopeatch = new Stopwatch();
            stopeatch.Start();
            R = windowedFFT(A, 50000, 1000);
            stopeatch.Stop();

            Console.WriteLine("  ");
            Console.WriteLine(stopeatch.ElapsedMilliseconds + " мс");




            Console.ReadKey();
        }
        static double correlation(double[] X, double[] Y)
        {
            double sumX = 0, sumY = 0, sumNumerator = 0, sumDenominatorX = 0, sumDenominatorY = 0, averageX, averageY;
            int length = (X.Length > Y.Length) ? Y.Length : X.Length;

            for (int i = 0; i < length; i++)
            {
                sumX += X[i];
                sumY += Y[i];
            }

            averageX = sumX / length;
            averageY = sumY / length;

            for (int i = 0; i < length; i++)
            {
                sumNumerator += (X[i] - averageX) * (Y[i] - averageY);
                sumDenominatorX += (X[i] - averageX) * (X[i] - averageX);
                sumDenominatorY += (Y[i] - averageY) * (Y[i] - averageY);
            }

            return sumNumerator / Math.Sqrt(sumDenominatorX * sumDenominatorY);
        }

        static double[] correlation(double[] X)
        {
            double[] result = new double[X.Length - 1];
            Parallel.For(0, 20, new ParallelOptions { MaxDegreeOfParallelism = 3 }, (lag) =>
            {

                double sumX = 0, sumY = 0, sumNumerator = 0, sumDenominatorX = 0, sumDenominatorY = 0, averageX, averageY;

                int length = X.Length - lag;
                for (int i = 0; i < length; i++)
                {
                    sumX += X[i];
                    sumY += X[i + lag];
                }

                averageX = sumX / length;
                averageY = sumY / length;

                for (int i = 0; i < length; i++)
                {
                    sumNumerator += (X[i] - averageX) * (X[i + lag] - averageY);
                    sumDenominatorX += (X[i] - averageX) * (X[i] - averageX);
                    sumDenominatorY += (X[i + lag] - averageY) * (X[i + lag] - averageY);
                }

                result[lag] = sumNumerator / Math.Sqrt(sumDenominatorX * sumDenominatorY);
                sumX = sumY = sumNumerator = sumDenominatorX = sumDenominatorY = 0;
            });
            return result;
        }
        static double[][] windowedFFT(double[] x, int windowSize, int step)
        {

            double[][] result = new double[x.Length / step][];

            Parallel.For(0, x.Length / step, new ParallelOptions { MaxDegreeOfParallelism = 4 }, (i) =>
              {
                  if (i * step < x.Length - windowSize)
                  {
                      double[] tempX = new double[windowSize];
                      for (int j = 0; j < windowSize; j++)
                      {
                          tempX[j] = x[j + i * step];
                      }
                    //   Task.Delay(x.Length / 1000).Wait();

                      //  result[i] = fft(tempX);              
                  }
                  else
                  {
                      double[] tempX = new double[x.Length - i * step];
                      for (int j = 0; j < x.Length-i*step; j++)
                      {
                          tempX[j] = x[j + i * step];

                      }
                   //   Task.Delay(x.Length / 1000).Wait();

                  }
              });

            return result;
        }


    }
}
