using System;
using static System.Console;

namespace Exo1 {
    class Program {
        static void Main() {
            Point3D p1 = new Point3D(45, 45.6, 6);
            Point3D p2 = new Point3D(4, 213.5, 41);
            p1.WriteInfo("p1");
            p2.WriteInfo("p2");
            WriteLine("--------------------------------SWAP--------------------------------");
            Point3D.SwapPoints(ref p1, ref p2);
            p1.WriteInfo("p1");
            p2.WriteInfo("p2");
        }
        struct Point3D {
            private double X { get; }
            private double Y { get; }
            private double Z { get; }
            public Point3D(double x, double y, double z) {
                X = x;
                Y = y;
                Z = z;
            }
            public double DistanceToOrigin() {
                return Math.Sqrt(X * X + Y * Y + Z * Z);
            }
            public static void SwapPoints(ref Point3D p1, ref Point3D p2) {
                Point3D p = new Point3D(p1.X, p1.Y, p1.Z);
                p1 = new Point3D(p2.X, p2.Y, p2.Z);
                p2 = new Point3D(p.X, p.Y, p.Z);
            }
            public void WriteInfo(string name){
                WriteLine("Coord of " + name + " are : X = "+X+" Y = "+Y+" Z = "+Z);
                WriteLine("Distance of " + name + " from Origin is " + DistanceToOrigin());
            }
        }
    }
}
