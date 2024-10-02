using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "Z:\\f.txt";
            try
            {
                StreamReader sr = new StreamReader(path);
                int n;
                n = Convert.ToInt32(sr.ReadLine());
                double[,] matrixG = new double[n, n];
                for (int i = 0; i < n; i++)
                {
                    string[] lin = new string[n];
                    lin = sr.ReadLine().Split(' ');
                    for (int j = 0; j < n; j++)
                    {
                        matrixG[i, j] = double.Parse(lin[j]);
                    }
                }
                double[] vectorX = new double[n];
                string[] line = sr.ReadLine().Split(' ');
                for (int i = 0; i < n; i++)
                    vectorX[i] = double.Parse(line[i]);
                sr.Close();
                int f = 1;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (matrixG[i, j] != matrixG[j, i])
                        {
                            f = 0;
                        }
                    }
                }
                if (f==1){
                            Console.WriteLine("матрица симетрична");
                        }
                    else Console.WriteLine("матрица не симетрична");
                double[] vectorY = new double[n];
                for (int i = 0; i < n; i++)
                {
                    double sum = 0;
                    for (int j = 0; j < n; j++)
                    {
                        sum += vectorX[i] * matrixG[i, j];
                    }
                    vectorY[i] = sum;
                }
                double summ = 0;
                for (int i = 0; i < n; i++)
                {
                    summ = vectorY[i] * vectorX[i];
                }
                double dlina = Math.Sqrt(summ);
                Console.Write("длинна вектора = ");
                Console.WriteLine(dlina);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
