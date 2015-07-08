namespace Mines
{
    using System;
    using System.Collections.Generic;

    public class Minesweeper
    {
        static void Main()
        {

            string currentCommand = string.Empty;
            char[,] field = GeneratePlayFiled();
            char[,] mines = AddMines();
            int counter = 0;
            bool isExploded = false;
            List<Player> players = new List<Player>(6);
            int row = 0;
            int col = 0;
            bool inGame = true;
            const int Max = 35;
            bool maxScoreCapReached = false;

            do
            {
                if (inGame)
                {
                    Console.WriteLine("Hajde da igraem na “Mini4KI”. Probvaj si kasmeta da otkriesh poleteta bez mini4ki." +
                    " Komanda 'top' pokazva klasiraneto, 'restart' po4va nova igra, 'exit' izliza i hajde 4ao!");
                    PrintField(field);
                    inGame = false;
                }

                Console.Write("Daj red i kolona : ");
                currentCommand = Console.ReadLine().Trim();
                if (currentCommand.Length >= 3)
                {
                    if (int.TryParse(currentCommand[0].ToString(), out row) &&
                    int.TryParse(currentCommand[2].ToString(), out col) &&
                        row <= field.GetLength(0) && col <= field.GetLength(1))
                    {
                        currentCommand = "turn";
                    }
                }

                switch (currentCommand)
                {
                    case "top":
                        TopScores(players);
                        break;
                    case "restart":
                        field = GeneratePlayFiled();
                        mines = AddMines();
                        PrintField(field);
                        isExploded = false;
                        inGame = false;
                        break;
                    case "exit":
                        Console.WriteLine("4a0, 4a0, 4a0!");
                        break;
                    case "turn":
                        if (mines[row, col] != '*')
                        {
                            if (mines[row, col] == '-')
                            {
                                tisinahod(field, mines, row, col);
                                counter++;
                            }

                            if (Max == counter)
                            {
                                maxScoreCapReached = true;
                            }
                            else
                            {
                                PrintField(field);
                            }
                        }
                        else
                        {
                            isExploded = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nGreshka! nevalidna Komanda\n");
                        break;
                }

                if (isExploded)
                {
                    PrintField(mines);
                    Console.Write(
                        "\nHrrrrrr! Umria gerojski s {0} to4ki. " + //I found the messages funny so I decided to leave them as they are :D
                        "Daj si niknejm: ",
                        counter);
                    string nickname = Console.ReadLine();
                    Player player = new Player(nickname, counter);
                    if (players.Count < 5)
                    {
                        players.Add(player);
                    }
                    else
                    {
                        for (int i = 0; i < players.Count; i++)
                        {
                            if (players[i].Points < player.Points)
                            {
                                players.Insert(i, player);
                                players.RemoveAt(players.Count - 1);
                                break;
                            }

                        }
                    }
                    players.Sort((Player r1, Player r2) => r2.Name.CompareTo(r1.Name));
                    players.Sort((Player r1, Player r2) => r2.Points.CompareTo(r1.Points));
                    TopScores(players);

                    field = GeneratePlayFiled();
                    mines = AddMines();
                    counter = 0;
                    isExploded = false;
                    inGame = true;
                }

                if (maxScoreCapReached)
                {
                    Console.WriteLine("\nBRAVOOOS! Otvri 35 kletki bez kapka kryv.");
                    PrintField(mines);
                    Console.WriteLine("Daj si imeto, batka: ");
                    string name = Console.ReadLine();
                    Player points = new Player(name, counter);
                    players.Add(points);
                    TopScores(players);
                    field = GeneratePlayFiled();
                    mines = AddMines();
                    counter = 0;
                    maxScoreCapReached = false;
                    inGame = true;
                }
            }
            while (currentCommand != "exit");
            Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
            Console.WriteLine("AREEEEEEeeeeeee.");
            Console.Read();
        }

        private static void TopScores(List<Player> players)
        {
            Console.WriteLine("\nTo4KI:");
            if (players.Count > 0)
            {
                for (int i = 0; i < players.Count; i++)
                {
                    Console.WriteLine(
                        "{0}. {1} --> {2} kutii",
                        i + 1,
                        players[i].Name,
                        players[i].Points);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("prazna klasaciq!\n");
            }
        }

        private static void tisinahod(char[,] filed, char[,] mines, int row, int col)
        {
            char mineCount = GetAmmountOfRevealedCells(mines, row, col);
            mines[row, col] = mineCount;
            filed[row, col] = mineCount;
        }

        private static void PrintField(char[,] board)
        {
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < rows; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }
                Console.Write("|");
                Console.WriteLine();
            }
            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] GeneratePlayFiled()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];
            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] AddMines()
        {
            int rows = 5;
            int cols = 10;
            char[,] playFiled = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    playFiled[i, j] = '-';
                }
            }

            List<int> mines = new List<int>();
            while (mines.Count < 15)
            {
                Random random = new Random();
                int mine = random.Next(50);
                if (!mines.Contains(mine))
                {
                    mines.Add(mine);
                }
            }

            foreach (int mine in mines)
            {
                int col = mine / cols;
                int row = mine % cols;
                if (row == 0 && mine != 0)
                {
                    col--;
                    row = cols;
                }
                else
                {
                    row++;
                }
                playFiled[col, row - 1] = '*';
            }

            return playFiled;
        }

        private static void CheckCells(char[,] filed)
        {
            int row = filed.GetLength(0);
            int col = filed.GetLength(1);

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (filed[i, j] != '*')
                    {
                        char cells = GetAmmountOfRevealedCells(filed, i, j);
                        filed[i, j] = cells;
                    }
                }
            }
        }

        private static char GetAmmountOfRevealedCells(char[,] filed, int row, int col)
        {
            int count = 0;
            int rows = filed.GetLength(0);
            int cols = filed.GetLength(1);

            if (row - 1 >= 0)
            {
                if (filed[row - 1, col] == '*')
                {
                    count++;
                }
            }

            if (row + 1 < rows)
            {
                if (filed[row + 1, col] == '*')
                {
                    count++;
                }
            }
            if (col - 1 >= 0)
            {
                if (filed[row, col - 1] == '*')
                {
                    count++;
                }
            }

            if (col + 1 < cols)
            {
                if (filed[row, col + 1] == '*')
                {
                    count++;
                }
            }

            if ((row - 1 >= 0) && (col - 1 >= 0))
            {
                if (filed[row - 1, col - 1] == '*')
                {
                    count++;
                }
            }

            if ((row - 1 >= 0) && (col + 1 < cols))
            {
                if (filed[row - 1, col + 1] == '*')
                {
                    count++;
                }
            }
            if ((row + 1 < rows) && (col - 1 >= 0))
            {
                if (filed[row + 1, col - 1] == '*')
                {
                    count++;
                }
            }

            if ((row + 1 < rows) && (col + 1 < cols))
            {
                if (filed[row + 1, col + 1] == '*')
                {
                    count++;
                }
            }

            return char.Parse(count.ToString());
        }
    }
}
