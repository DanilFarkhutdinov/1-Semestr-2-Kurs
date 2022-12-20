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
        private float[,] array;
        protected int N { get { return n; } set { n = value; } }
        protected int M { get { return m; } set { m = value; } }
        protected float [,] Array { get { return array; } set { array = value; } }
        /*public Matrix()
        {

        }*/
        public Matrix(int n=0, int m=0)
        {
            this.n = n;
            this.m = m;
            this.array = new float[n, m];
        }
        public Matrix(int n, int m, string c = "keyboard")
        {
            this.n = n;
            this.m = m;
            this.array = new float[n, m];
            for (int i = 0; i < n; i++)
            {
                for(int j = 0; j < m; j++)
                {
                    Console.WriteLine("Введите элемент матрицы с индексами {0}{1}", i + 1, j + 1);
                    array[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
        }
        public Matrix(int n, int m, int a = 0)
        {
            this.n = n;
            this.m = m;
            this.array = new float[n, m];
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
            this.array = new float[n, m];
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
                    this.array = new float[n, m];
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
        public static Matrix operator +(Matrix A, Matrix B)
        {
            if (A.n != B.n || A.m != B.m)
            {
                Console.WriteLine("Сложение невозможно");
                return new Matrix();
            }
            else
            {
                Matrix C = new Matrix(A.n, A.m);
                for (int i = 0; i < A.n; i++)
                {
                    for (int j = 0; j < A.m; j++)
                    {
                       C.array[i, j] = A.array[i, j] + B.array[i, j];
                    }
                }
                if (A.n == A.m)
                {
                    SquareMatrix D = new SquareMatrix(A.n);
                    for (int i = 0; i < A.n; i++)
                    {
                        for (int j = 0; j < A.m; j++)
                        {
                            D.array[i, j] = C.array[i, j];
                        }
                    }
                    return D;
                }
                else
                {
                    return C;
                }
            }
        }
        public static Matrix operator -(Matrix A, Matrix B)
        {
            if (A.n != B.n || A.m != B.m)
            {
                Console.WriteLine("Вычитание невозможно");
                return new Matrix();
            }
            else
            {
                Matrix C = new Matrix(A.n, A.m);
                for (int i = 0; i < A.n; i++)
                {
                    for (int j = 0; j < B.m; j++)
                    {
                        C.array[i, j] = A.array[i, j] - B.array[i, j];
                    }
                }
                if (A.n == A.m)
                {
                    SquareMatrix D = new SquareMatrix(A.n);
                    for (int i = 0; i < A.n; i++)
                    {
                        for (int j = 0; j < A.m; j++)
                        {
                            D.array[i, j] = C.array[i, j];
                        }
                    }
                    return D;
                }
                else
                {
                    return C;
                }
            }
        }
        public static Matrix operator *(Matrix A, Matrix B)
        {
            if (A.m != B.n)
            {
                Console.WriteLine("Произведение невозможно");
                return new Matrix();
            }
            else
            {
                Matrix C = new Matrix(A.n,  B.m);
                int c = 0;
                float sum = 0;
                for (int i = 0; i < A.n; i++)
                {
                    for (int d = 0; d < B.m; d++)
                    {
                        for (int j = 0; j < A.m; j++)
                        {
                            sum += A.array[i, j] * B.array[c, d];
                            c++;
                        }
                        C.array[i, d] = sum; 
                        c = 0;
                        sum = 0;
                    }
                }
                if (A.n == B.m)
                {
                    SquareMatrix D = new SquareMatrix(A.n);
                    for (int i = 0; i < A.n; i++)
                    {
                        for (int j = 0; j < B.m; j++)
                        {
                            D.array[i, j] = C.array[i, j];
                        }
                    }
                    return D;
                }
                else
                {
                    return C;
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
            if (i <= this.n && j <= this.m)
            {
                Console.WriteLine(this.array[i - 1, j - 1]);
            }
            else
            {
                Console.WriteLine("Такого элемента не существует");
            }
        }
        public Matrix Non_zero(Matrix A, int start)
        {
            for(int i = 1; i < A.n; i++)
            {
                if (A.array[i, start] != 0)
                {
                    for (int j = start; j < A.m; j++)
                    {
                        (A.array[start, j], A.array[i, j]) = (A.array[i, j], A.array[start, j]);
                    }
                    break;
                }
            }
            return A;
        }
        public void Show_non_zero()
        {
            Matrix Y = Non_zero(this, 0);
            Y.ShowMatrix();
            Console.WriteLine();
            this.ShowMatrix();
        }
        public void Show_Gauss()
        {
            Matrix G = Gauss_method(this);
            int count = 0;
            int index = G.n;
            Console.WriteLine("Ступенчатый вид матрицы");
            G.ShowMatrix();
            Console.WriteLine();
            for (int i = 0; i < G.n; i++)
            {
                for (int j = 0; j < G.m; j++)
                {
                    if (G.array[i, j] == 0)
                    {
                        count++;
                    }
                }
                if (count == G.m)
                {
                    index = i;
                    break;
                }
                count = 0;
            }
            Console.WriteLine("Результат:");
            for (int i = 0; i < index; i++)
            {
                for (int j = 0; j < G.m; j++)
                {
                    Console.Write(G.array[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        public Matrix Gauss_method_step(Matrix A, int start = 0)
        {
            for (int i = A.M - 1; i >= 0; i--)
            {
                A.array[start, i] = A.array[start, i] / A.array[start, start];
            }
            for (int i = start + 1; i < A.n; i++)
            {
                for (int j = A.M - 1; j >= 0; j--)
                {
                    A.array[i, j] = A.array[i, j] - A.array[i, start] * A.array[start, j];
                }
            }
            return A;
        }
        public Matrix Gauss_method(Matrix A)
        {
            int start = 0;
            while (start != A.n - 1 && start != A.m - 1)
            {
                if (A.array[start, start] == 0)
                {
                    A = Non_zero(A, start);
                    Console.WriteLine();
                    if (A.array[start, start] != 0)
                    {
                        Gauss_method_step(A, start);
                        start++;
                    }
                    else
                    {
                        start++;
                    }
                }
                else
                {
                    Gauss_method_step(A, start);
                    start++;
                }
            }
            return A;
        }
    }
}
