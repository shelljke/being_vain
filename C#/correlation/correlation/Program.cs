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
            double[] A = { 0, 0.757710425524595, 1.27377607106028, 1.40100671229060, 1.14364543170176, 0.654279130117015, 0.171943859289168, -0.0739590442794045, 0.0442552300208481, 0.501072461819308, 1.12736337788519, 1.67724170759455, 1.92565020546421, 1.75791801049639, 1.21571522158559, 0.481142261559946, -0.194743095864767, -0.590595769826805, -0.601488179095839, -0.279243978971693, 0.189584363928795, 0.559310548511715, 0.624219211321314, 0.301779686286431, -0.333120177284167, -1.07655417639276, -1.67531501760230, -1.92640297354671, -1.75675939464985, -1.25159997665984, -0.620112108069826, -0.112152100033682, 0.0809664899333857, -0.0978101078165236, -0.549119368373945, -1.05737354097629, -1.37731685837694, -1.33254683783576, -0.886841179304860, -0.159928739256162, 0.618594713688444, 1.19894020964684, 1.40881165129938, 1.22034505542996, 0.759752770584199, 0.255878720657409, -0.0518691156767602, -0.00961210602599194, 0.389071252923232, 0.999999999999999, 1.58529231390567, 1.90772360004733, 1.82506772842276, 1.34694852307850, 0.631612330622777, -0.0761117351856164, -0.541044173064265, -0.629885036384779, -0.362840390319432, 0.0958255841128520, 0.504523921902112, 0.641816728993143, 0.395881754369059, -0.189606062741181, -0.931436625776687, -1.57836610196716, -1.90979173596501, -1.82243762604437, -1.37064611782857, -0.744290808840825, -0.193096429713795, 0.0725694588546660, -0.0349705084083903, -0.446337740345515, -0.963336613331411, -1.33856482290748, -1.37475322108006, -1.00435241642435, -0.317724803890221, 0.471290030787056, 1.10879734691485, 1.40016245607159, 1.28581289828587, 0.863459518962686, 0.347947743350473, -0.0152806022496104, -0.0487133613646897, 0.285876606387580, 0.871609054516184, 1.48250756582719, 1.87308047605247, 1.87589678008424, 1.46840064990475, 0.782419570078441, 0.0525756292806665, -0.475930131808926, -0.643559635013040, -0.438510635457839 };
            Random rand = new Random();


            Stopwatch stopeatch = new Stopwatch();
            stopeatch.Start();
            double[][] mods=new double[50][];
             mods=   emd(A, mods,0,0,0);
            var gg=Array.ConvertAll(mods[0], input =>  input.ToString());
            File.WriteAllLines("C:\\Games\\1.txt", gg);
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

        static double[][] emd(double[] signal, double[][]mods, int calls, int countOfMods, int countOfCalls)
        {
            //int calls = 0;
            double[] mod = new double[signal.Length];
          //  while (true)
            {
         
                double[] localMaximums = new double[signal.Length / 2 + 2];
                double[] localMinimums = new double[signal.Length / 2 + 2];
                int[] indexesOfLocalMaximums;
                int[] indexesOfLocalMinimums;
                double[] localMeans = new double[signal.Length];
                double[] difference = new double[signal.Length];
                int x0, x1, index = 0;
                FindExtremums(signal, out localMinimums, out localMaximums, out indexesOfLocalMinimums, out indexesOfLocalMaximums);
                if (calls > 1000) return mods;
                if ((indexesOfLocalMaximums.Length-1 <=1  || indexesOfLocalMinimums.Length-1 <= 1) )
                {
                    return mods;
                }
                x0 = 0;
                x1 = indexesOfLocalMinimums[0];
                for (int interpolatedX = 0; interpolatedX < signal.Length - 1; interpolatedX++)
                {
                    if (interpolatedX > x1)
                    {
                        index++;
                    }
                    x0 = indexesOfLocalMinimums[index];
                    x1 = indexesOfLocalMinimums[index + 1];
                    localMinimums[interpolatedX] = linear(interpolatedX, x0, x1, localMinimums[x0], localMinimums[x1]);
                }

                x0 = 0;
                x1 = indexesOfLocalMaximums[0];
                index = 0;
                for (int interpolatedX = 0; interpolatedX < signal.Length - 1; interpolatedX++)
                {
                    if (interpolatedX > x1)
                    {
                        index++;
                    }
                    x0 = indexesOfLocalMaximums[index];
                    x1 = indexesOfLocalMaximums[index + 1];
                    localMaximums[interpolatedX] = linear(interpolatedX, x0, x1, localMaximums[x0], localMaximums[x1]);
                }

                for (int i = 0; i < signal.Length; i++)
                {
                    localMeans[i] = (localMinimums[i] + localMaximums[i]) / 2;
                }

                for (int i = 0; i < signal.Length; i++)
                {
                    difference[i] = signal[i] - localMeans[i];
                }

                int countOfNulls = 0;
                double mean = 0;
                for (int i = 0; i < difference.Length - 1; i++)
                {
                    if (Math.Abs(difference[i] * difference[i + 1]) < 0.00005 || difference[i] * difference[i + 1] < 0) countOfNulls++;
                    mean += difference[i];
                }
                mean /= difference.Length;
                
                FindExtremums(difference, out localMinimums, out localMaximums, out indexesOfLocalMinimums, out indexesOfLocalMaximums);
                if (Math.Abs(mean) <= 0.5 && Math.Abs(indexesOfLocalMaximums.Length-1 + indexesOfLocalMinimums.Length-1 - countOfNulls) <= 50)
                {
                    mods[countOfMods] = difference;
                    countOfMods++;
                    
                    for (int i = 0; i < signal.Length; i++)
                    {
                        difference[i] = signal[i]-difference[i];
                    }
                    countOfCalls = 0;
                    calls++;
                    return emd(difference, mods, calls, countOfMods, countOfCalls);
                }
                calls++;
                countOfCalls++;
                return emd(difference, mods,calls, countOfMods, countOfCalls);
            }           
            
        }

        static void FindExtremums(double[] x, out double[] localMinimums, out double[] localMaximums,
            out int[] indexesOfLocalMinimums, out int[] indexesOfLocalMaximums)
        {
            double[] maximums = new double[x.Length];
            double[] minimums = new double[x.Length];
            int[] indexesOfMaximums = new int[x.Length/2+1 ];
            int[] indexesOfMinimums = new int[x.Length /2+1];

            int countOfMinimums = 0;
            int countOfMaximums = 0;
            double p = 0.005;

            for (int i = 1; i < x.Length - 1; i++)
            {
                if ((x[i] - x[i - 1])>p && ( x[i] - x[i + 1])>p)
                {
                    maximums[i] = x[i];
                    indexesOfMaximums[countOfMaximums] = i;
                    countOfMaximums++;
                }
                else if ( (x[i - 1]- x[i]) >p && (x[i + 1] - x[i]) > p)

                {
                    minimums[i] = x[i];
                    indexesOfMinimums[countOfMaximums] = i;
                    countOfMinimums++;
                }
            }
            Array.Resize(ref indexesOfMaximums, countOfMaximums + 1);
            Array.Resize(ref indexesOfMinimums, countOfMinimums + 1);
            maximums[x.Length - 1] = x[x.Length - 1];
            minimums[x.Length - 1] = x[x.Length - 1];

            indexesOfMaximums[indexesOfMaximums.Length - 1] = x.Length - 1;
            indexesOfMinimums[indexesOfMinimums.Length - 1] = x.Length - 1;

            indexesOfLocalMaximums = indexesOfMaximums;
            indexesOfLocalMinimums = indexesOfMinimums;
            localMaximums = maximums;
            localMinimums = minimums;
        }


        static public double linear(double x, double x0, double x1, double y0, double y1)
        {
            if ((x1 - x0) == 0)
            {
                return (y0 + y1) / 2;
            }
            return y0 + (x - x0) * (y1 - y0) / (x1 - x0);
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