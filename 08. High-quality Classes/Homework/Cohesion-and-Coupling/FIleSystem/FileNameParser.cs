namespace CohesionAndCoupling.FileSystem
{
    using System;

    public static class FileNameParser
    {
        public static string GetFileExtension(string fileName)
        {
            int indexOfLastDot = fileName.LastIndexOf(".");
            if (indexOfLastDot == -1)
            {
                throw new ArgumentException("Invalid file name (no extention)");
            }

            string extension = fileName.Substring(indexOfLastDot + 1);
            return extension;
        }

        public static string GetFileNameWithoutExtension(string fileName)
        {
            int indexOfLastDot = fileName.LastIndexOf(".");
            if (indexOfLastDot == -1)
            {
                throw new ArgumentException("Invalid file name (no extention)");
            }

            string baseName = fileName.Substring(0, indexOfLastDot);
            return baseName;
        }
    }
}
