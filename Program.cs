using System;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Security.AccessControl;
using Класс_точек_и_четырехугольников;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            Point A = new Point (1, 4);
            Point B = new Point (1, 1);
            Point C = new Point (4, 1);
            Point D = new Point (4, 4);
            Point E = new Point(5, 4);
            Point F = new Point(5, 2);
            Point G = new Point(7, 2);
            Point H = new Point(7, 4);
            Quadrilateral Q = new Quadrilateral(A, B, C, D);
            Console.WriteLine("1. Площадь 4-угольника");
            Console.WriteLine("2. Периметр 4-угольника");
            Console.WriteLine("3. Длины диагоналей 4-угольника");
            Console.WriteLine("4. Проверить является ли выпуклым");
            Console.WriteLine("5. Узнать пересекаются ли два 4-угольника");
            Console.WriteLine("6. Лежит ли один внутри другого");
            Console.WriteLine("7. Является ли фигура квадратом/ромбом/прямоуг/параллелограммом/трапеция");
            Console.WriteLine("Введите номер задачи: ");
            int n = Convert.ToInt32(Console.ReadLine());
            switch (n)
            {
                case 1:
                    Q.Square();
                    break;
                case 2:
                    Q.Perimeter();
                    break;
                case 3:
                    Q.Diagonals();
                    break;
                case 4:
                    if (Q.Type_of_quadrilateral() == 0)
                    {
                        Console.WriteLine("Выпуклый");
                    }
                    else
                    {
                        Console.WriteLine("Невыпуклый");
                    }
                    break;
                case 5:
                    Point[] Q1array = { A, B, C, D, A };
                    Point[] Q2array = { E, F, G, H, E };
                    int count = 0;
                    for (int i = 0; i < Q1array.Length - 1; i++)
                    {
                        for (int j = 0; j < Q2array.Length - 1; j++)
                        {
                            if (Q1array[i].Sign_of_Point(Q2array[j], Q2array[j + 1]) * Q1array[i + 1].Sign_of_Point(Q2array[j], Q2array[j + 1]) < 0 && Q2array[j].Sign_of_Point(Q1array[i], Q1array[i + 1]) * Q2array[j + 1].Sign_of_Point(Q1array[i], Q1array[i + 1]) < 0)
                            {
                                count++;
                            }
                        }
                    }
                    if (count != 0)
                    {
                        Console.WriteLine("Пересекаются");
                    }
                    else
                    {
                        Console.WriteLine("Не пересекаются");
                    }
                    break;
                case 6:
                     Point[] Qarray = { A, B, C, D, A };
                     int count1 = 0;
                     for (int i = 0; i < Qarray.Length - 1; i++)
                     {
                         int e = E.Sign_of_Point(Qarray[i], Qarray[i + 1]);
                         int f = F.Sign_of_Point(Qarray[i], Qarray[i + 1]);
                         int g = G.Sign_of_Point(Qarray[i], Qarray[i + 1]);
                         int h = H.Sign_of_Point(Qarray[i], Qarray[i + 1]);
                         if (e + f + g + h != 4 && e + f + g + h != -4)
                         {
                             count1++;
                         }
                     }
                     if (count1 != 0)
                     {
                         Console.WriteLine("Не лежит");
                     }
                     else
                     {
                         Console.WriteLine("Лежит");
                     }
                    break;
                case 7:
                    if (Q.Type_of_quadrilateral() == 0)
                    {
                        Q.Type_of_figure();
                    }
                    else
                    {
                        Console.WriteLine("Четырехугольник невыпуклый");
                    }
                    break;
            }
        }
    }
}