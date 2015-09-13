namespace CohesionAndCoupling
{
    using System;
    using CoordinateSystems;
    using FileSystem;

    using log4net;
    using log4net.Config;

    class UtilsExamples
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(UtilsExamples));

        static void Main()
        {

            BasicConfigurator.Configure();

            //Console.WriteLine(FileNameParser.GetFileExtension("example"));
            //Console.WriteLine(FileNameParser.GetFileNameWithoutExtension("example"));
            //Both cases throw Exeption due to invalid file name

            Console.WriteLine(FileNameParser.GetFileExtension("example.pdf"));
            Console.WriteLine(FileNameParser.GetFileExtension("example.new.pdf"));
            Console.WriteLine(FileNameParser.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileNameParser.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine("Distance in the 2D space = {0:f2}",
                CoordinateSystem.CalcDistanceBetweenTwoPointsIn2D(1, -2, 3, 4));
            Console.WriteLine("Distance in the 3D space = {0:f2}",
                CoordinateSystem.CalcDistanceBetweenTwoPointsIn3D(5, 2, -1, 3, -6, 4));

            Console.WriteLine("Volume = {0:f2}", CoordinateSystem.CalcVolume(3, 4, 5));
            Console.WriteLine("Diagonal XYZ = {0:f2}", CoordinateSystem.CalcDiagonalIn3DSpace(3, 4, 5));
            Console.WriteLine("Diagonal XY = {0:f2}", CoordinateSystem.CalcDiagonalIn2DSpace(3, 4));
            Console.WriteLine("Diagonal XZ = {0:f2}", CoordinateSystem.CalcDiagonalIn2DSpace(3, 5));
            Console.WriteLine("Diagonal YZ = {0:f2}", CoordinateSystem.CalcDiagonalIn2DSpace(4, 5));
            Console.ReadKey();

            logger.Debug("Here is a debug log.");
            logger.Info("... and an Info log.");
            logger.Warn("... and a warning.");
            logger.Error("... and an error.");
            logger.Fatal("... and a fatal error.");
        }
    }
}
