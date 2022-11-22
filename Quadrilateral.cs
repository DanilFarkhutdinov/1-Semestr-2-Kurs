using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;
using System.Text;
using System.Threading.Tasks;
/*
1. Находить площадь 4-угольника +
2. Находить периметр. +
3. Найти длины диагоналей. +
4. Проверить является ли выпуклым. +
5. Узнать пересекаются ли два 4-угольника.
6. Если есть пересечения - лежит ли один внутри другого.
7. Является ли фигура квадратом/ромбом/прямоуг/параллелогр/трапеция
*/
namespace Класс_точек_и_четырехугольников
{
    internal class Quadrilateral: Point
    {
        private Point a;
        private Point b;
        private Point c;
        private Point d;
        public Point A { get { return a; } set { a = value; } }
        public Point B { get { return b; } set { b = value; } }
        public Point C { get { return c; } set { c = value; } }
        public Point D { get { return d; } set { d = value; } }
        public Quadrilateral(Point a, Point b, Point c, Point d)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
        }
        public int Type_of_quadrilateral()
        {
            double a = ((A.X - C.X) * (D.Y - C.Y) - (D.X - C.X) * (A.Y - C.Y)) * ((B.X - C.X) * (D.Y - C.Y) - (D.X - C.X) * (B.Y - C.Y));
            double b = ((B.X - D.X) * (A.Y - D.Y) - (A.X - D.X) * (B.Y - D.Y)) * ((C.X - D.X) * (A.Y - D.Y) - (A.X - D.X) * (C.Y - D.Y));
            double c = ((D.X - B.X) * (A.Y - B.Y) - (A.X - B.X) * (D.Y - B.Y)) * ((C.X - B.X) * (A.Y - B.Y) - (A.X - B.X) * (C.Y - B.Y));
            double d = ((A.X - B.X) * (C.Y - B.Y) - (C.X - B.X) * (A.Y - B.Y)) * ((D.X - B.X) * (C.Y - B.Y) - (C.X - B.X) * (D.Y - B.Y));
            if (a >= 0 && b >= 0 && c >= 0 && d >= 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        public void Perimeter()
        {
            double a = A.distance(B);
            double b = B.distance(C);
            double c = C.distance(D);
            double d = D.distance(A);
            Console.WriteLine(a + b + c + d);
        }
        public void Diagonals()
        {
            Console.WriteLine("d1 = {0}", A.distance(C));
            Console.WriteLine("d2 = {0}", B.distance(D));
        }
        public void Square()
        {
            Point d1 = vector(A, C);
            Point d2 = vector(B, D);
            double sin = Math.Abs(d1.X * d2.Y - d1.Y * d2.X) / (A.distance(C) * B.distance(D));
            Console.WriteLine(A.distance(C) * B.distance(D) * sin * 0.5);
        }
        public void Type_of_figure()
        {
            if (A.Angle(B, D) == B.Angle(A, C) && A.Angle(B, D) == C.Angle(B, D) && A.Angle(B, D) == D.Angle(A, C))
            {
                if (A.distance(B) == B.distance(C) && A.distance(B) == C.distance(D) && A.distance(B) == A.distance(D))
                {
                    Console.WriteLine("Квадрат");
                }
                else
                {
                    Console.WriteLine("Прямоугольник");
                }
            }
            else
            {
                if (A.distance(B) == B.distance(C) && A.distance(B) == C.distance(D) && A.distance(B) == A.distance(D))
                    {
                    Console.WriteLine("Ромб");
                }
                else
                {
                    if (A.Angle(B, D) == C.Angle(B, D) && B.Angle(A, C) == D.Angle(A, C))
                    {
                        Console.WriteLine("Параллелограм");
                    }
                    else
                    {
                        Point AB = vector(A, B);
                        Point BC = vector(B, C);
                        Point CD = vector(C, D);
                        Point DA = vector(D, A);
                        if (AB.X * CD.Y == AB.Y * CD.X || DA.X * BC.Y == DA.Y * BC.X)
                        {
                            Console.WriteLine("Трапеция");
                        }
                        else
                        {
                            Console.WriteLine("Обычный выпуклый четырехугольник");
                        }
                    }
                }
            }
        }
    }
}
