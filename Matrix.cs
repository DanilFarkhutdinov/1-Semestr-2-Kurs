using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Класс_матриц
{
    internal class Matrix
    {
        private int n;
        private int m;
        private int[,] array;
        public int N { get { return n; } set { n = value; } }
        public int M { get { return m; } set { m = value; } }
        public int [,] Array { get { return array; } set { array = value; } }
        public Matrix(int n, int m)
        {
            this.n = n;
            this.m = m;
            this.array = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for(int j = 0; j < m; j++)
                {
                    Console.WriteLine("Введите элемент матрицы с индексами {0}{1}", i + 1, j + 1);
                    array[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
        }
        public Matrix(int n, int m, char a = '0')
        {
            this.n = n;
            this.m = m;
            this.array = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for(int j = 0; j < m; j++)
                {
                    array[i, j] = 0;
                }
            }
        }
        public Matrix(int n, int m, int start, int end)
        {
            this.n = n;
            this.m = m;
            this.array = new int[n, m];
            Random rnd = new Random();
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < m; j++)
                {
                    this.array[i, j] = rnd.Next(start, end);
                }
            }
        }
        public Matrix(string filename)
        {
            StreamReader fstream = null;
            int count = -1;
            fstream = new StreamReader(filename);
            while (!fstream.EndOfStream)
            {
                string s = fstream.ReadLine();
                List<int> list = s.Split(' ').Select(x => Convert.ToInt32(x)).ToList();
                if (count == -1)
                {
                    this.n = list[0];
                    this.m = list[1];
                    this.array = new int[n, m];
                }
                else
                {
                    for( int i = 0; i < list.Count; i++)
                    {
                        array[count, i] = list[i];
                    }
                }
                count++;
            }
            fstream.Close();
        }
        public void ShowMatrix()
        {
            for (int i = 0; i < this.n; i++)
            {
                for (int j = 0; j < this.m; j++)
                {
                    Console.Write(this.array[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        public void Multiplication_by_scalar(int x)
        {
            for(int i = 0; i < this.n; i++)
            {
                for(int j = 0; j < this.m; j++)
                {
                    Console.Write(this.array[i, j] * x + " ");
                }
                Console.WriteLine();
            }
        }
        public void Division_by_scalar(double x)
        {
            for (int i = 0; i < this.n; i++)
            {
                for (int j = 0; j < this.m; j++)
                {
                    Console.Write(this.array[i, j] / x + " ");
                }
                Console.WriteLine();
            }
        }
        public void Matrix_addition(Matrix A)
        {
            if (this.n != A.N || this.m != A.m)
            {
                Console.WriteLine("Сложение невозможно");
            }
            else
            {
                for (int i = 0; i < this.n; i++)
                {
                    for (int j = 0; j < this.m; j++)
                    {
                        Console.Write(this.array[i, j] + A.array[i, j] + " ");
                    }
                    Console.WriteLine();
                }
            }
        }
        public void Matrix_subtraction(Matrix A)
        {
            if (this.n != A.N || this.m != A.m)
            {
                Console.WriteLine("Вычитание невозможно");
            }
            else
            {
                for (int i = 0; i < this.n; i++)
                {
                    for (int j = 0; j < this.m; j++)
                    {
                        Console.Write(this.array[i, j] - A.array[i, j] + " ");
                    }
                    Console.WriteLine();
                }
            }
        }
        public void Matrix_multiplication(Matrix A)
        {
            if (this.m != A.N)
            {
                Console.WriteLine("Произведение невозможно");
            }
            else
            {
                int c = 0, sum = 0;
                for (int i = 0; i < n; i++)
                {
                    for (int d = 0; d < A.m; d++)
                    {
                        for (int j = 0; j < m; j++)
                        {
                            sum += this.array[i, j] * A.array[c, d];
                            c++;
                        }
                        c = 0;
                        Console.Write(sum + " ");
                        sum = 0;
                    }
                    Console.WriteLine();
                }
            }
        }
        public void Matrix_transposition()
        {
            for (int j = 0; j < m; j++)
            {
                for (int i = 0; i < n; i++)
                {
                    Console.Write(this.array[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        public void Output_of_the_matrix_element(int i, int j)
        {
            Console.WriteLine(this.array[i - 1, j - 1]);
        }
    }
}
