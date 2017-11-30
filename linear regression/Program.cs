using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace linear_regression
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public MeanList DataPoints { get; set; }
        
        public double XminXBar => (X - DataPoints.MeanX);
        public double YminYBar => (Y - DataPoints.MeanY);
    }
    public class MeanList : List<Point>
    {
        public double MeanX => (double)this?.Sum(x => x.X) / this.Count;
        public double MeanY => (double)this?.Sum(x => x.Y) / this.Count;
        public double b0 => this.Sum(a=>a.XminXBar*a.YminYBar)/this.Sum(a=>Math.Pow(a.XminXBar,2));
        public double b1 => MeanY - b0 * MeanX;
    }
    class Program
    {
        static void Main(string[] args)
        {
            MeanList P = new MeanList();
            int N = 5;

            P.Add(new Point
            {
                X = 0,
                Y = 2,
                DataPoints = P
            });
            P.Add(new Point
            {
                X = 1,
                Y = 3,
                DataPoints = P
            });
            P.Add(new Point
            {
                X = 2,
                Y = 5,
                DataPoints = P
            });
            P.Add(new Point
            {
                X = 3,
                Y = 4,
                DataPoints = P
            });
            P.Add(new Point
            {
                X = 4,
                Y = 6,
                DataPoints = P
            });

            int X = 10 ;

            double Y = P.b0*X + P.b1;

            Console.WriteLine(Y);
            Console.WriteLine("Hello World!");

        }
    }
}
