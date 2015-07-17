namespace Abstraction
{
    using System;

   internal abstract class Figure
    {
        public Figure()
        {
        }

        public virtual double CalcPerimeter()
        {
            throw new NotImplementedException();
        }

        public virtual double CalcSurface()
        {
            throw new NotImplementedException();
        }

        public void ValidateNumricValue(double value, string errorMessage)
        {
            if (value <= 0)
            {
                throw new ArgumentException(errorMessage);
            }
        }
    }
}
