namespace Task_2.Refactor_the_following_if_st
{
    using System;

    internal class CellValidator
    {
        public static void VisitCellIfPossible(double x, double y, bool canVisitCell)
        {
            const double MinX = 0;
            const double MaxX = 23;
            const double MinY = 0;
            const double MaxY = 25;
            bool isWithinRange = x >= MinX && y >= MinY && x <= MaxX && y <= MaxY; 
            
            if (canVisitCell && isWithinRange)
            {
                VisitCell();
            }
        }

        private static void VisitCell()
        {
            Console.WriteLine("Visits cell*... and dies of boredom");
        }
    }
}
