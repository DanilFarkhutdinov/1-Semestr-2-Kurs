using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Класс_матриц
{
    internal class SquareMatrix: Matrix
    {
        public SquareMatrix()
        {

        }
        public SquareMatrix(int n): base(n, n)
        {

        }
        public SquareMatrix(int n, string c): base(n, n, c)
        {

        }
        public SquareMatrix(int n, int a) : base(n, n, a)
        {

        }
        public SquareMatrix(int n, int start, int end) : base(n, n, start, end)
        {

        }
        public SquareMatrix(string filename) : base(filename)
        {

        }
        
        public static float Determinant_of_a_square_matrix(SquareMatrix A, float sum = 0)
        {
            if (A.N > 2)
            {
                for (int i = 0; i < A.M; i++)
                {
                    SquareMatrix B = new SquareMatrix(A.N - 1);
                    if ((i % 2) == 0)
                    {
                        int count = 0;
                        for (int j = 0; j < A.N - 1; j++)
                        {
                            for (int k = 0; k < A.M; k++)
                            {
                                if (k != i)
                                {
                                    B.Array[j, count] = A.Array[j + 1, k];
                                    count++;
                                }
                            }
                            count = 0;
                        }
                        sum += A.Array[0, i] * Determinant_of_a_square_matrix(B);
                    }
                    else
                    {
                        int count = 0;
                        for (int j = 0; j < A.N - 1; j++)
                        {
                            for (int k = 0; k < A.M; k++)
                            {
                                if (k != i)
                                {
                                    B.Array[j, count] = A.Array[j + 1, k];
                                    count++;
                                }
                            }
                            count = 0;
                        }
                        sum += -A.Array[0, i] * Determinant_of_a_square_matrix(B);
                    }
                }
                return sum;
            }
            else
            {
               return A.Array[0, 0] * A.Array[1, 1] - A.Array[1, 0] * A.Array[0, 1];
            }
        }
        public void Show_determinant()
        {
            Console.WriteLine(Determinant_of_a_square_matrix(this));
        }
        public void Linear_dependence()
        {
            this.Show_determinant();
            if (Determinant_of_a_square_matrix(this) != 0)
            {

                Console.WriteLine("Определитель матрицы не равен 0");
            }
            else
            {
                Console.WriteLine("det");

            }
        }
        public static float Minor(SquareMatrix A, int i, int j)
        {
            SquareMatrix B = new SquareMatrix(A.N - 1);
            int count1 = 0;
            int count2 = 0;
            for(int k = 0; k < A.N; k++)
            {
                for (int l = 0; l < A.N; l++)
                {
                    if (k != i && l != j)
                    {
                        B.Array[count1, count2] = A.Array[k, l];
                        count2++;
                    }
                }
                count2 = 0;
                if(k != i)
                {
                    count1++;
                }
            }
            return Determinant_of_a_square_matrix(B);
        }
    }
}
