using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics;
using System.Text;
using System.Threading.Tasks;

namespace Класс_точек_и_четырехугольников
{
    internal class Point
    {
        private double x;
        private double y;
        public double X { get { return x; } set { x = value; } }
        public double Y { get { return y; } set { y = value; } }
        public Point()
        {
            this.x = 0;
            this.y = 0;
        }
        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public static Point vector(Point A, Point B)
        {
            return new Point(B.x - A.x, B.y - A.y);
        }
        public static Point operator +(Point A, Point B)
        {
            return new Point(A.x + B.x, A.y + B.y);
        }
        public double distance(Point B)
        {
             return Math.Sqrt(Math.Pow(this.x - B.x, 2) + Math.Pow(this.y - B.y, 2));
        }
        public double Angle(Point B, Point C)
        {
            Point V1 = vector(this, B);
            Point V2 = vector(this, C);
            double cos = (V1.x * V2.x + V1.y * V2.y)  / (this.distance(B) * this.distance(C));
            return cos;
        }
        public int Sign_of_Point(Point start, Point end)
        {
            if ((this.x - start.x) * (end.y - start.y) - (end.x - start.x) * (this.y - start.y) >= 0)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
    }
}
