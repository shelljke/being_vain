﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
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
            double[] A;

             Thread.CurrentThread.CurrentCulture=new CultureInfo("en-US");
            Random rand = new Random();
            var gg = File.ReadAllLines("C:\\Games\\2.txt");
            A = Array.ConvertAll(gg, Convert.ToDouble);

            //  ToFile(A);
            Stopwatch stopeatch = new Stopwatch();
            stopeatch.Start();
            double[][] mods = new double[50][];
            mods = emd(A, mods, 0, 0);
              Thread.CurrentThread.CurrentCulture = new CultureInfo("ru-RU");
            ToFile(mods[0]);
            ToFile(mods[1]);
            ToFile(mods[2]);
            ToFile(mods[3]);
            ToFile(mods[4]);
            ToFile(mods[5]);
            // ToFile(A);

            stopeatch.Stop();

            Console.WriteLine("  ");
            Console.WriteLine(stopeatch.ElapsedMilliseconds + " мс");


            Console.ReadKey();
        }

        static void ToFile(double[] dd)
        {
            var gg = Array.ConvertAll(dd, input => input.ToString());
            File.WriteAllLines("C:\\Games\\1.txt", gg);
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

                  double sumX = 0,
                      sumY = 0,
                      sumNumerator = 0,
                      sumDenominatorX = 0,
                      sumDenominatorY = 0,
                      averageX,
                      averageY;

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

        private static double[] originalSignal;
        static double[][] emd(double[] signal, double[][] mods, int calls, int countOfMods)
        {
            if (originalSignal == null)
            {
                originalSignal = signal;
            }
            //int calls = 0;
            double[] mod = new double[signal.Length];
            //  while (calls<=21)
            {

                double[] localMaximums;
                double[] localMinimums;
                double[] indexesOfLocalMaximums;
                double[] indexesOfLocalMinimums;
                

                FindExtremums(signal, out localMinimums, out localMaximums, out indexesOfLocalMinimums, out indexesOfLocalMaximums);

                 if (calls == 100)
                {
                    GC.Collect();
                }
                if (calls > 150 || indexesOfLocalMaximums.Length <= 1 || indexesOfLocalMinimums.Length <= 1)
                {
                    mods[countOfMods] = originalSignal;
                    return mods;
                }
                double[] interpMinimums = new double[signal.Length];
                double[] interpMaximums = new double[signal.Length];
                Stopwatch sss = new Stopwatch();
                sss.Start();

                // ToFile(localMinimums);
                // ToFile(localMaximums);
                CubicSpline interp = new CubicSpline();
                interp.BuildSpline(indexesOfLocalMinimums, localMinimums, indexesOfLocalMinimums.Length);

                int min = (int)(indexesOfLocalMinimums[0] < indexesOfLocalMaximums[0]
                    ? indexesOfLocalMaximums[0]
                    : indexesOfLocalMinimums[0]);

                int max = (int)(indexesOfLocalMinimums[indexesOfLocalMinimums.Length - 1] > indexesOfLocalMaximums[indexesOfLocalMaximums.Length - 1]
                    ? indexesOfLocalMaximums[indexesOfLocalMaximums.Length - 1]
                    : indexesOfLocalMinimums[indexesOfLocalMinimums.Length - 1]);
                double[] difference = new double[max - min];
                for (int interpolatedX = min; interpolatedX < max; interpolatedX++)
                {
                    interpMinimums[interpolatedX] = interp.Interpolate(interpolatedX);
                }
                 // ToFile(interpMinimums);

                interp.BuildSpline(indexesOfLocalMaximums, localMaximums, indexesOfLocalMaximums.Length);
                for (int interpolatedX = min; interpolatedX < max; interpolatedX++)
                {
                    interpMaximums[interpolatedX ] = interp.Interpolate(interpolatedX);
                }

                 // ToFile(interpMaximums);
                sss.Stop();
                
                for (int i = min; i < max; i++)
                {
                    difference[i-min] = signal[i] - (interpMaximums[i] + interpMinimums[i]) / 2;
                }

                int countOfNulls = 0;
                double mean = 0;
                for (int i = 0; i < difference.Length - 1; i++)
                {
                    if (difference[i] * difference[i + 1] < 0) countOfNulls++;
                    mean += difference[i];
                }
                mean /= difference.Length;
                FindExtremums(difference, out localMinimums, out localMaximums, out indexesOfLocalMinimums, out indexesOfLocalMaximums);
                if (Math.Abs(mean) <= 0.009 && Math.Abs(indexesOfLocalMaximums.Length + indexesOfLocalMinimums.Length - countOfNulls) <= 1)
                {
                    mods[countOfMods] = difference;
                     countOfMods++;
                    var backupLink = originalSignal;
                    originalSignal = new double[max-min];
                    for (int i = min; i < max; i++)
                    {
                        originalSignal[i-min] = backupLink[i] - difference[i-min];
                    }
                    calls++;
                   /* difference = null;
                    localMinimums = null;
                    localMaximums = null;
                    indexesOfLocalMinimums = null;
                    indexesOfLocalMaximums = null;
                    interpMaximums = null;
                    interpMinimums = null;*/
                    return emd(originalSignal, mods, calls, countOfMods);
                }
                calls++;
                return emd(difference, mods, calls, countOfMods);
            }

        }

        static void FindExtremums(double[] x, out double[] localMinimums, out double[] localMaximums,
            out double[] indexesOfLocalMinimums, out double[] indexesOfLocalMaximums)
        {
            double[] maximums = new double[x.Length / 2 + 1];
            double[] minimums = new double[x.Length / 2 + 1];
            double[] indexesOfMaximums = new double[x.Length / 2 + 1];
            double[] indexesOfMinimums = new double[x.Length / 2 + 1];

            int countOfMinimums = 0;
            int countOfMaximums = 0;
            double p = 0.00002;
            /* if ((x[0] - x[1]) > p)
             {
                 maximums[0] = (x[0]+x[1])/2;
                 countOfMaximums++;
             }
             else
             {
                 minimums[0] = (x[0] + x[1]) / 2;
                 countOfMinimums++;
             }*/
            for (int i = 1; i < x.Length - 1; i++)
            {
                if ((x[i] - x[i - 1]) > p && (x[i] - x[i + 1]) > p)
                {
                    maximums[countOfMaximums] = x[i];
                    indexesOfMaximums[countOfMaximums] = i;
                    countOfMaximums++;
                }
                else if ((x[i - 1] - x[i]) > p && (x[i + 1] - x[i]) > p)

                {
                    minimums[countOfMinimums] = x[i];
                    indexesOfMinimums[countOfMinimums] = i;
                    countOfMinimums++;
                }
            }
            //  countOfMinimums++;
            // countOfMaximums++;


            /*     if ((x[x.Length - 1] - x[x.Length - 2]) > p)
                  {
                      maximums[countOfMaximums] = (x[x.Length - 1]+ x[x.Length - 2])/2;
                      indexesOfMaximums[countOfMaximums] = x.Length-1;
                      countOfMaximums++;
                  }
                  else
                  {
                      minimums[countOfMinimums] = (x[x.Length - 1] + x[x.Length - 2]) / 2;
                      indexesOfMinimums[countOfMinimums] = x.Length - 1;
                      countOfMinimums++;
                  }
                  */
            Array.Resize(ref indexesOfMinimums, countOfMinimums);
            Array.Resize(ref indexesOfMaximums, countOfMaximums);
            Array.Resize(ref minimums, countOfMinimums);
            Array.Resize(ref maximums, countOfMaximums);

            indexesOfLocalMaximums = indexesOfMaximums;
            indexesOfLocalMinimums = indexesOfMinimums;
            localMaximums = maximums;
            localMinimums = minimums;
        }

        static double LP(double[] x, double[] y, int n, double argx)
        {
            double c, s = 0;
            for (int i = 0; i < n; i++)
            {
                c = 1;
                for (int j = 0; j < n; j++)
                {
                    if (i != j)
                        c *= (argx - x[j]) / (x[i] - x[j]);
                }
                s += c * y[i];
            }
            return s;
        }




        class CubicSpline
        {
            SplineTuple[] splines; // Сплайн

            // Структура, описывающая сплайн на каждом сегменте сетки
            private struct SplineTuple
            {
                public double a, b, c, d, x;
            }

            // Построение сплайна
            // x - узлы сетки, должны быть упорядочены по возрастанию, кратные узлы запрещены
            // y - значения функции в узлах сетки
            // n - количество узлов сетки
            public void BuildSpline(double[] x, double[] y, int n)
            {
                // Инициализация массива сплайнов
                splines = new SplineTuple[n];
                for (int i = 0; i < n; ++i)
                {
                    splines[i].x = x[i];
                    splines[i].a = y[i];
                }
                splines[0].c = splines[n - 1].c = 0.0;

                // Решение СЛАУ относительно коэффициентов сплайнов c[i] методом прогонки для трехдиагональных матриц
                // Вычисление прогоночных коэффициентов - прямой ход метода прогонки
                double[] alpha = new double[n - 1];
                double[] beta = new double[n - 1];
                alpha[0] = beta[0] = 0.0;
                for (int i = 1; i < n - 1; ++i)
                {
                    double hi = x[i] - x[i - 1];
                    double hi1 = x[i + 1] - x[i];
                    double A = hi;
                    double C = 2.0 * (hi + hi1);
                    double B = hi1;
                    double F = 6.0 * ((y[i + 1] - y[i]) / hi1 - (y[i] - y[i - 1]) / hi);
                    double z = (A * alpha[i - 1] + C);
                    alpha[i] = -B / z;
                    beta[i] = (F - A * beta[i - 1]) / z;
                }

                // Нахождение решения - обратный ход метода прогонки
                for (int i = n - 2; i > 0; --i)
                {
                    splines[i].c = alpha[i] * splines[i + 1].c + beta[i];
                }

                // По известным коэффициентам c[i] находим значения b[i] и d[i]
                for (int i = n - 1; i > 0; --i)
                {
                    double hi = x[i] - x[i - 1];
                    splines[i].d = (splines[i].c - splines[i - 1].c) / hi;
                    splines[i].b = hi * (2.0 * splines[i].c + splines[i - 1].c) / 6.0 + (y[i] - y[i - 1]) / hi;
                }
            }

            // Вычисление значения интерполированной функции в произвольной точке
            public double Interpolate(double x)
            {
                if (splines == null)
                {
                    return double.NaN; // Если сплайны ещё не построены - возвращаем NaN
                }

                int n = splines.Length;
                SplineTuple s;

                if (x <= splines[0].x) // Если x меньше точки сетки x[0] - пользуемся первым эл-тов массива
                {
                    s = splines[0];
                }
                else if (x >= splines[n - 1].x) // Если x больше точки сетки x[n - 1] - пользуемся последним эл-том массива
                {
                    s = splines[n - 1];
                }
                else // Иначе x лежит между граничными точками сетки - производим бинарный поиск нужного эл-та массива
                {
                    int i = 0;
                    int j = n - 1;
                    while (i + 1 < j)
                    {
                        int k = i + (j - i) / 2;
                        if (x <= splines[k].x)
                        {
                            j = k;
                        }
                        else
                        {
                            i = k;
                        }
                    }
                    s = splines[j];
                }

                double dx = x - s.x;
                // Вычисляем значение сплайна в заданной точке по схеме Горнера (в принципе, "умный" компилятор применил бы схему Горнера сам, но ведь не все так умны, как кажутся)
                return s.a + (s.b + (s.c / 2.0 + s.d * dx / 6.0) * dx) * dx;
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
}