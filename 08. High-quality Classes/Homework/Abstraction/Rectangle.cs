namespace Abstraction
{
    using System;

    public class Rectangle : Figure
    {
        private double width;
        private double height;

        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            private set
            {
                ValidateNumricValue(value, "Width cannot be less then or equal to 0");
                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            private set
            {
                ValidateNumricValue(value, "Height cannot be less then or equal to 0");
                this.height = value;
            }
        }

        public override double CalcSurface()
        {
            double surface = this.Width * this.Height;
            return surface;
        }

        public override double CalcPerimeter()
        {
            double perimeter = 2 * (this.Width + this.Height);
            return perimeter;
        }
    }
}
