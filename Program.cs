using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Net.Http.Headers;
using System.Numerics;
using Класс_матриц;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            //Matrix M = new Matrix(2, 2);
            //M.ShowMatrix();
            //Console.WriteLine();
            //Matrix Z = new Matrix(3, 3, '0');
            //Z.ShowMatrix();
            //Console.WriteLine();
            //Matrix R = new Matrix(3, 3, 1, 10);
            //R.ShowMatrix();
            //Console.WriteLine();
            //Matrix F = new Matrix("Matrix.txt");
            //F.ShowMatrix();
            Console.WriteLine("1. Умножение матрицы на константу");
            Console.WriteLine("2. Деление матрицы на константу");
            Console.WriteLine("3. Cложение матриц");
            Console.WriteLine("4. Вычитание матриц");
            Console.WriteLine("5. Умножение матриц с проверкой размерностей");
            Console.WriteLine("6. Транспонирование матрицы");
            Console.WriteLine("7. Вывод элемента матрицы");
            Console.WriteLine("8. Найти определитель квадратной матрицы");
            Console.WriteLine("9. Удалить линейно зависимые строки или столбцы матрицы");
            Console.WriteLine("10. Нахождение обратной матрицы");
            Console.WriteLine("Введите номер задачи: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            switch (n)
            {
                case 1:
                    Matrix R = new Matrix(3, 4, 1, 10);
                    R.ShowMatrix();
                    Console.WriteLine();
                    Console.WriteLine("Введите константу:");
                    int c = Convert.ToInt32(Console.ReadLine());
                    R.Multiplication_by_scalar(c);
                    break;
                case 2:
                    Matrix R1 = new Matrix(3, 4, 1, 10);
                    R1.ShowMatrix();
                    Console.WriteLine();
                    Console.WriteLine("Введите константу:");
                    int c1 = Convert.ToInt32(Console.ReadLine());
                    R1.Division_by_scalar(c1);
                    break;
                case 3:
                    Matrix R2 = new Matrix(3, 4, 1, 10);
                    R2.ShowMatrix();
                    Console.WriteLine("+");
                    Matrix R3 = new Matrix(3, 4, 1, 10);
                    R3.ShowMatrix();
                    Console.WriteLine();
                    Console.WriteLine("Результат:");
                    Matrix A = R2 + R3;
                    A.ShowMatrix();
                    if (A is SquareMatrix)
                    {
                        Console.WriteLine("Square Matrix");
                    }
                    else
                    {
                        Console.WriteLine("Matrix");
                    }
                    break;
                case 4:
                    Matrix R4 = new Matrix(3, 4, 1, 10);
                    R4.ShowMatrix();
                    Console.WriteLine("-");
                    Matrix R5 = new Matrix(3, 4, 1, 10);
                    R5.ShowMatrix();
                    Console.WriteLine();
                    Console.WriteLine("Результат:");
                    Matrix S = R4 - R5;
                    S.ShowMatrix();
                    if (S is SquareMatrix)
                    {
                        Console.WriteLine("Square Matrix");
                    }
                    else
                    {
                        Console.WriteLine("Matrix");
                    }
                    break;
                case 5:
                    Console.WriteLine("Введите первую матрицу:");
                    Matrix M = new Matrix(3, 4, 1, 10);
                    Console.WriteLine();
                    Console.WriteLine("Введите вторую матрицу:");
                    Matrix M1 = new Matrix(4, 3, 1, 10);
                    Console.WriteLine();
                    M.ShowMatrix();
                    Console.WriteLine("*");
                    M1.ShowMatrix();
                    Console.WriteLine();
                    Console.WriteLine("Результат:");
                    Matrix M2 = M * M1;
                    M2.ShowMatrix();
                    if (M2 is SquareMatrix)
                    {
                        Console.WriteLine("Square Matrix");
                    }
                    else
                    {
                        Console.WriteLine("Matrix");
                    }
                    break;
                case 6:
                    Matrix R6 = new Matrix(2, 3, 1, 10);
                    R6.ShowMatrix();
                    Console.WriteLine();
                    Console.WriteLine("Результат:");
                    R6.Matrix_transposition();
                    break;
                case 7:
                    Matrix R7 = new Matrix(3, 4, 1, 10);
                    R7.ShowMatrix();
                    Console.WriteLine();
                    Console.WriteLine("Введите индекс строки:");
                    int i = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                    Console.WriteLine("Введите индекс столбца:");
                    int j = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                    Console.WriteLine("Результат:");
                    R7.Output_of_the_matrix_element(i, j);
                    break;
                case 8:
                    SquareMatrix SR = new SquareMatrix(3, 1, 10);
                    SR.ShowMatrix();
                    Console.WriteLine();
                    Console.WriteLine("Результат:");
                    SR.Show_determinant();
                    break;
                case 9:
                    SquareMatrix SR1 = new SquareMatrix(3, "keyboard");
                    SR1.ShowMatrix();
                    SR1.Linear_dependence();
                    break;
                case 10:
                    InverseMatrix IR2 = new InverseMatrix(3, "keyboard");
                    IR2.Inverse_matrix();
                    break;
                case 11:
                    Matrix X = new Matrix(3, 3, "keyboard");
                    X.ShowMatrix();
                    Console.WriteLine();
                    X.Show_Gauss();
                    break;
            }
        }
    }
}