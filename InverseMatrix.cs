using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Класс_матриц
{
    internal class InverseMatrix: SquareMatrix
    {
        public InverseMatrix()
        {

        }
        public InverseMatrix(int n) : base(n)
        {

        }
        public InverseMatrix(int n, string c) : base(n, c)
        {

        }
        public InverseMatrix(int n, int a = 1)
        {
            
        }
        public void Inverse_matrix()
        {
            InverseMatrix B = new InverseMatrix(this.N);
            for (int i = 0; i < this.N; i++)
            {
                for(int j = 0; j < this.N; j++)
                {
                    if ((i + j + 2) % 2 == 0)
                    {
                        B.Array[j, i] = Minor(this, i, j);
                    }
                    else
                    {
                        if (Minor(this, i, j) == 0)
                        {
                            B.Array[j, i] = 0;
                        }
                        else
                        {
                            B.Array[j, i] = (-1) * Minor(this, i, j);
                        }                     
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine("Результат:");
            for (int i = 0; i < B.N; i++)
            {
                for (int j = 0; j < B.M; j++)
                {
                    Console.Write("{0}/{1},", B.Array[i, j], Determinant_of_a_square_matrix(this));
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("Проверка:");
            this.ShowMatrix();
            Console.WriteLine("*");
            for (int i = 0; i < B.N; i++)
            {
                for (int j = 0; j < B.M; j++)
                {
                    Console.Write("{0}/{1},", B.Array[i, j], Determinant_of_a_square_matrix(this));
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("Результат:");
            Matrix C = this * B;
            C.Division_by_scalar(Determinant_of_a_square_matrix(this));
        }
    }
}
