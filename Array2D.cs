namespace Task_31
{
    public class Array2D
    {
        private int[,] value;

        public int[,] Value
        {
            get { return value; }
        }

        public Array2D(int rows, int cols, bool fillByHand = false)
        {
            this.value = fillByHand ? this.FillByHand(rows, cols) : this.FillByRnd(rows, cols);
        }

        public int[,] FillByHand(int rows, int cols)
        {
            Console.WriteLine("Введите элементы матрицы построчно через пробел:");
            this.value = new int[rows, cols];
            string? input;
            string[] inputArray;
            for (int row = 0; row < rows; row++)
            {
                Console.Write($"Строка {row + 1}: ");
                input = Console.ReadLine() ?? "";
                inputArray = input.Split(" ");
                for (int col = 0; col < cols; col++)
                {
                    this.value[row, col] = col < inputArray.Length
                        ? Convert.ToInt32(inputArray[col]) : 0;
                }
            }
            return this.value;
        }

        public int[,] FillByRnd(int rows, int cols)
        {
            this.value = new int[rows, cols];
            Random rnd = new Random();
            for (int row = 0; row < this.value.GetLength(0); row++)
            {
                for (int col = 0; col < this.value.GetLength(1); col++)
                {
                    this.value[row, col] = rnd.Next(-100, 100);
                }
            }
            return this.value;
        }

        public void OutputArray(bool snakeMode = false)
        {
            for (int row = 0; row < this.value.GetLength(0); row++)
            {
                for (int col = 0; col < this.value.GetLength(1); col++)
                {
                    Console.Write(Leading(this.value[
                        row, 
                        snakeMode && row % 2 != 0 ? this.value.GetLength(1) - col - 1 : col
                    ]));
                }
                Console.WriteLine("");
            }
        }

        public static string Leading(int n)
        {
            string temp = ("     " + n);
            return temp.Substring(temp.Length - 6);
        }

        public double Average()
        {
            double sum = 0;
            for (int row = 0; row < this.value.GetLength(0); row++)
            {
                for (int col = 0; col < this.value.GetLength(1); col++)
                {
                    sum += this.value[row, col];
                }
            }
            return sum / (this.value.GetLength(0) * this.value.GetLength(1));
        }
    }
}