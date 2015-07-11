namespace Figure
{
    using System;

    public class Figure
    {
        public Figure(double width, double heigth)
        {
            this.Width = width;
            this.Heigth = heigth;
        }

        public double Width { get; private set; }

        public double Heigth { get; private set; }

        public static Figure GetRotatedFigure(Figure size, double angleOfTheFigureThatWillBeRotated)
        {
            double cos = Math.Abs(Math.Cos(angleOfTheFigureThatWillBeRotated));
            double sin = Math.Abs(Math.Sin(angleOfTheFigureThatWillBeRotated));

            double newWidth = (cos * size.Width) + (sin * size.Heigth);
            double newHeigth = (sin * size.Width) + (cos * size.Heigth);

            Figure newFigure = new Figure(newWidth, newHeigth);

            return newFigure;
        }
    }
}