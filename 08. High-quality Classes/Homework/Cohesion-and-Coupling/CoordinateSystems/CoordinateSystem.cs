namespace CohesionAndCoupling.CoordinateSystems
{
    using System;

    public class CoordinateSystem
    {
        public static double CalcDistanceBetweenTwoPointsIn2D(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            return distance;
        }

        public static double CalcDistanceBetweenTwoPointsIn3D(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1) + (z2 - z1) * (z2 - z1));
            return distance;
        }

        public static double CalcVolume(double x, double y, double z)
        {
            double volume = x * y * z;
            return volume;
        }

        public static double CalcDiagonalIn3DSpace(double x, double y, double z)
        {
            double diagonalLength = Math.Sqrt((x * x) + (y * y) + (z * z));
            return diagonalLength;
        }

        public static double CalcDiagonalIn2DSpace(double x, double y)
        {
            double distance = Math.Sqrt((x * x) + (y * y));
            return distance;
        }
    }
}
