using System;
using static System.Console;

namespace Exo1 {
    class Program {
        static void Main() {
            Point3D p1 = new Point3D(45, 45.6, 6);
            Point3D p2 = new Point3D(4, 213.5, 41);
            WriteLine(p1 + "\n" + p2);
            WriteLine("--------------------------------SWAP--------------------------------");
            Point3D.SwapPoints(ref p1, ref p2);
            WriteLine(p1 + "\n" + p2);
        }
        struct Point3D {
            private double X { get; set; }
            private double Y { get; set; }
            private double Z { get; set; }
            public Point3D(double x, double y, double z) {
                X = x;
                Y = y;
                Z = z;
            }
            public double DistanceToOrigin() {
                return Math.Sqrt(X * X + Y * Y + Z * Z);
            }
            public static void SwapPoints(ref Point3D p1, ref Point3D p2) {
                double tempX = p1.X, tempY = p1.Y, tempZ = p2.Z;
                p1.X = p2.X;
                p1.Y = p2.Y;
                p1.Z = p2.Z;
                p2.X = tempX;
                p2.Y = tempY;
                p2.Z = tempZ;
            }
            public override string ToString(){
                return $"Distance of ({X},{Y},{Z}) from Origin is {DistanceToOrigin()}";
            }
        }
    }
}
