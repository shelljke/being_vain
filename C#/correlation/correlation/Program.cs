using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace correlation
{
    class Program
    {
        static void Main(string[] args)
        {

            int e = 150;
            List<double> A = new List<double>();
            double[] R = { 5, 1, 2, -8, -4, -6, -2, -8, -4, -6, -2, -8, -4, -6, -2, -8, -8, -4, -6, -2, -8, -4, -6, -2, -8, -4, -6, -2, -8, -4, -6, -2, -8, -4, -6, -2, -8, -4, -6, -2, -8, -4, -6, -2, -8, -4, -6, -2, -8, -4, -6, -2, -8, -4, -6, -2, -8, -4, -6, -2, -8, -4, -6, -2, -8, -4, -6, -2, 5, 7, -3, -7, 5, 6,  };

            Random rand = new Random();

            for (int i = 0; i < e; i++)
            {
                A.AddRange(R);
              //  A.Add(rand.Next());
            }
            Stopwatch stopeatch = new Stopwatch();
            stopeatch.Start();
            List< List<double>> mods = new List<List<double>>();
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


        static List<List<double>> emd(List<double> listX, List<List<double>> mods = null)
        {
            List<double> mod = new List<double>();
            while (true)
                 {
                if (mods == null) mods = new List<List<double>>();
                List<double> localMaximums, localMinimums;
                List<double> localMeans = new List<double>();
                List<double> interpMeans = new List<double>();
                List<double> difference = new List<double>();
                
                //  List<double> difference = new List<double>();

                findExtremums(listX, out localMinimums, out localMaximums);

                int n = (localMinimums.Count > localMaximums.Count) ? localMaximums.Count : localMinimums.Count;
                for (int i = 0; i < n; i++)
                {
                    localMeans.Add((localMaximums[i] + localMinimums[i]) / 2);
                }

                double step = ((double)localMeans.Count - 1) / ((double)listX.Count - 1);

                //интерполяция массива средних
                Stopwatch stopeatch = new Stopwatch();
                //stopeatch.Start();
                int ii = 0;
                for (double interpolatedX = 0; interpolatedX < listX.Count - 1; interpolatedX++)
                {
                    interpMeans.Add(InterpolateLagrangePolynomial(interpolatedX * step, localMeans));
                }
                if (interpMeans.Count < listX.Count) interpMeans.Add(localMeans.Last());
                //   if (localMeans.Count > listX.Count) interpMeans.Remove(interpMeans.Count-1);
                //  stopeatch.Stop();

                //вычитание из исходного массива массива интерполированных средних
                for (int i = 0; i < interpMeans.Count; i++)
                {
                    difference.Add(listX[i] - interpMeans[i]);
                }

                int countOfNulls = 0;
                for (int i = 0; i < difference.Count - 1; i++)
                {
                    if (difference[i] * difference[i + 1] <= 0 || difference[i] * difference[i + 1] == 0) countOfNulls++;
                }

                List<double> localMaximumsOfDifference, localMinimumsOfDifference;
                findExtremums(difference, out localMaximumsOfDifference, out localMinimumsOfDifference);
                n = (localMinimumsOfDifference.Count > localMaximumsOfDifference.Count) ? localMaximumsOfDifference.Count : localMinimumsOfDifference.Count;
                double mean = 0;
                for (int i = 0; i < n; i++)
                {
                    mean += ((localMaximumsOfDifference[i] + localMinimumsOfDifference[i]) / 2);
                }
                mean /= n;
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
                List<double> localMaximumsOfsignalWithoutMod, localMinimumsOfsignalWithoutMod;
                findExtremums(signalWithoutMod, out localMaximumsOfsignalWithoutMod, out localMinimumsOfsignalWithoutMod);
                if (localMaximumsOfsignalWithoutMod.Count == 0 && localMinimumsOfsignalWithoutMod.Count == 0)
                {
                    return mods;
                }
                else listX = signalWithoutMod;
            }
        }

        static void findExtremums(List<double> list, out List<double> localMinimums, out List<double> localMaximums)
        {
            List<double> maximums = new List<double>(list.Count / 2 + 2);
            List<double> minimums = new List<double>(list.Count / 2 + 2);
            for (int i = 1; i < list.Count - 1; i++)
            {
                if (list[i] > list[i - 1] && list[i] > list[i + 1])
                {
                    maximums.Add(list[i]);
                }
                else if (list[i] < list[i - 1] && list[i] < list[i + 1])
                {
                    minimums.Add(list[i]);
                }
            }
            localMaximums = maximums;
            localMinimums = minimums;
        }

        static double InterpolateLagrangePolynomial(double x, List<double> xValues)
        {         
            return xValues[(int)x]+ (xValues[(int)x+1] - xValues[(int)x])*(x-(int)x);
        }
    }
}
