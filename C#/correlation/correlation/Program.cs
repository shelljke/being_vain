using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace correlation
{
    class Program
    {
        static void Main(string[] args)
        {

            int e = 150;
            List<double> A = new List<double>();
            double[] R = { 5, 1, 2, -8, -4, -6, -2, -8, -4, -6, -2, -8, -4, -6, -2, -8, -8, -4, 10 };

            Random rand = new Random();

            //  for (int i = 0; i < e; i++)
            {
                A.AddRange(R);
                //  A.Add(rand.Next());
            }
            Stopwatch stopeatch = new Stopwatch();
            stopeatch.Start();
            List<List<double>> mods = new List<List<double>>();
            emd(A, mods);
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
            Parallel.For(0, 20, new ParallelOptions { MaxDegreeOfParallelism = 8 }, (lag) =>
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
            double[] tempX = new double[windowSize];
            Parallel.For(0, x.Length / step, new ParallelOptions { MaxDegreeOfParallelism = 6 }, (i) =>
              {
                  if (i * step < x.Length - windowSize)
                  {
                      for (int j = 0; j < windowSize; j++)
                      {
                          tempX[j] = x[j + i * step];
                      }

                  }
                  else
                  {
                      for (int j = 0; j < x.Length - i * step; j++)
                      {
                          tempX[j] = x[j + i * step];
                      }

                  }
              });

            return result;
        }

        static double[][] emd(double[] signal)
        {
            double[] mod = new double[signal.Length];
            while (true)
            {
                double[,] localMaximums = new double[2, signal.Length/2+2];
                double[,] localMinimums = new double[2, signal.Length/2+2];
                double[] loaclMeans = new double[signal.Length];
                double[] interpMaximums = new double[signal.Length];
                double[] interpMinimums = new double[signal.Length];
                double[] difference = new double[signal.Length];

                findExtremums(signal, out localMinimums, out localMaximums);
            }
            return mods;
        }
        static List<List<double>> emdLists(List<double> listX, List<List<double>> mods = null)
        {
            List<double> mod = new List<double>();
            while (true)
            {
                if (mods == null) mods = new List<List<double>>();
                List<DoublePoint> localMaximums, localMinimums;
                List<double> localMeans = new List<double>();
                List<double> interpMaximums = new List<double>();
                List<double> interpMinimums = new List<double>();
                List<double> difference = new List<double>();

                //  List<double> difference = new List<double>();

                findExtremums(listX, out localMinimums, out localMaximums);

                double step = ((double)localMinimums.Count - 1) / ((double)listX.Count - 1);
                for (double interpolatedX = 0; interpolatedX < listX.Count - 1; interpolatedX++)
                {
                    interpMinimums.Add(InterpolateLagrangePolynomial(interpolatedX * step, localMinimums));
                }
                step = ((double)localMaximums.Count - 1) / ((double)listX.Count - 1);
                for (double interpolatedX = 0; interpolatedX < listX.Count - 1; interpolatedX++)
                {
                    interpMaximums.Add(InterpolateLagrangePolynomial(interpolatedX * step, localMaximums));
                }
                if (interpMaximums.Count < listX.Count) interpMaximums.Add(localMaximums.Last().Y);
                if (interpMinimums.Count < listX.Count) interpMinimums.Add(localMinimums.Last().Y);
                for (int i = 0; i < listX.Count; i++)
                {
                    localMeans.Add((interpMaximums[i] + interpMinimums[i]) / 2);
                }

                //интерполяция массива средних
                Stopwatch stopeatch = new Stopwatch();
                //stopeatch.Start();
                int ii = 0;


                //   if (localMeans.Count > listX.Count) interpMeans.Remove(interpMeans.Count-1);
                //  stopeatch.Stop();

                //вычитание из исходного массива массива интерполированных средних
                for (int i = 0; i < localMeans.Count; i++)
                {
                    difference.Add(listX[i] - localMeans[i]);
                }

                int countOfNulls = 0;
                for (int i = 0; i < difference.Count - 1; i++)
                {
                    if (difference[i] * difference[i + 1] <= 0 || difference[i] * difference[i + 1] == 0) countOfNulls++;
                }

                List<DoublePoint> localMaximumsOfDifference, localMinimumsOfDifference;
                List<double> interpLocalMaximumsOfDifference = new List<double>();
                List<double> interpLocalMinimumsOfDifference = new List<double>();
                findExtremums(difference, out localMaximumsOfDifference, out localMinimumsOfDifference);
                double mean = 0;
                step = ((double)localMinimumsOfDifference.Count - 1) / ((double)listX.Count - 1);
                for (double interpolatedX = 0; interpolatedX < listX.Count - 1; interpolatedX++)
                {
                    interpLocalMinimumsOfDifference.Add(InterpolateLagrangePolynomial(interpolatedX * step, localMinimumsOfDifference));
                }
                step = ((double)localMaximumsOfDifference.Count - 1) / ((double)listX.Count - 1);
                for (double interpolatedX = 0; interpolatedX < listX.Count - 1; interpolatedX++)
                {
                    interpLocalMaximumsOfDifference.Add(InterpolateLagrangePolynomial(interpolatedX * step, localMaximumsOfDifference));
                }
                if (interpLocalMinimumsOfDifference.Count < listX.Count) interpLocalMinimumsOfDifference.Add(localMinimumsOfDifference.Last().Y);
                if (interpLocalMaximumsOfDifference.Count < listX.Count) interpLocalMaximumsOfDifference.Add(localMaximumsOfDifference.Last().Y);
                for (int i = 0; i < listX.Count; i++)
                {
                    mean += ((interpLocalMinimumsOfDifference[i] + interpLocalMaximumsOfDifference[i]) / 2);
                }
                mean /= listX.Count;
                int countOfExtremums = localMaximumsOfDifference.Count + localMinimumsOfDifference.Count;

                if (((int)Math.Abs(countOfNulls - countOfExtremums) == 1 || countOfNulls == countOfExtremums) && (Math.Abs(mean) <= 0.6))
                {
                    mod = difference;
                    mods.Add(mod);
                }
                else { listX = difference; continue; }

                List<double> signalWithoutMod = new List<double>();
                for (int i = 0; i < mod.Count; i++)
                {
                    signalWithoutMod.Add(listX[i] - mod[i]);
                }
                List<DoublePoint> localMaximumsOfSignalWithoutMod, localMinimumsOfSignalWithoutMod;
                findExtremums(signalWithoutMod, out localMaximumsOfSignalWithoutMod, out localMinimumsOfSignalWithoutMod);
                if (localMaximumsOfSignalWithoutMod.Count == 0 && localMinimumsOfSignalWithoutMod.Count == 0)
                {
                    return mods;
                }
                else listX = signalWithoutMod;
            }
        }

        static void findExtremums(double[] x, out double[,] localMinimums, out double[,] localMaximums)
        {
            double[,] maximums = new double[2,x.Length / 2 + 2];
            double[,] minimums = new double[2,x.Length / 2 + 2];
            int countOfMinimums = 0;
            int countOfMaximums = 0;
            for (int i = 1; i < x.Length - 1; i++)
            {
                if (x[i] > x[i - 1] && x[i] > x[i + 1])
                {
                    maximums[0,countOfMaximums] = x[i];
                    maximums[1,countOfMaximums] = i;
                    countOfMaximums++;
                }
                else if (x[i] < x[i - 1] && x[i] < x[i + 1])
                {
                    maximums[0,countOfMinimums] = x[i];
                    maximums[1,countOfMinimums] = i;
                    countOfMinimums++;
                }
            }
            localMaximums = maximums;
            localMinimums = minimums;
        }


        static double InterpolateLagrangePolynomial(double x, List<DoublePoint> values)
        {
            return values[(int)x].Y + ((values[(int)x + 1].Y - values[(int)x].Y) * (x - values[(int)x].X)) / (values[(int)x + 1].X - values[(int)x].X);
        }
    }
    struct DoublePoint
    {
        public double X, Y;
        public DoublePoint(double x, double y)
        {
            this.Y = y;
            this.X = x;
        }
    }
}
