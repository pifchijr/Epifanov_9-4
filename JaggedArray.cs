namespace Task_31
{
    public class JaggedArray
    {
        private int[][] value;

        public int[][] Value
        {
            get { return value; }
        }

        public JaggedArray(int rows, bool fillByHand = false)
        {
            this.value = fillByHand ? this.FillByHand(rows) : this.FillByRnd(rows);
        }

        private int[][] FillByHand(int rows)
        {
            this.value = new int[rows][];
            string? input;
            string[] stringArray;
            for (int row = 0; row < rows; row++)
            {
                Console.Write($"Строка {row + 1}: ");
                input = Console.ReadLine() ?? "";
                stringArray = input.Split(" ");
                this.value[row] = Array.ConvertAll(stringArray, int.Parse);
            }
            return this.value;
        }

        private int[][] FillByRnd(int rows)
        {
            this.value = new int[rows][];
            Random rnd = new Random();
            int cols;
            int[] rowArray;
            for (int row = 0; row < rows; row++)
            {
                cols = rnd.Next(3, 10);
                rowArray = new int[cols];
                for (int col = 0; col < cols; col++)
                {
                    rowArray[col] = rnd.Next(-100, 100);
                }
                this.value[row] = rowArray;
            }
            return this.value;
        }

        public void Output()
        {
            for (int row = 0; row < this.value.GetLength(0); row++)
            {
                for (int col = 0; col < this.value[row].Length; col++)
                {
                    Console.Write(Array2D.Leading(this.value[row][col]));
                }
                Console.WriteLine("");
            }
        }

        public float Average()
        {
            float sum = 0;
            int counter = 0;
            for (int row = 0; row < this.value.Length; row++)
            {
                for (int col = 0; col < this.value[row].Length; col++)
                {
                    sum += this.value[row][col];
                    counter++;
                }
            }
            return sum / counter;
        }

        public void PrintAverageByRows()
        {
            float sum;
            Console.WriteLine("Average by rows:");
            for (int row = 0; row < this.value.Length; row++)
            {
                sum = 0;
                for (int col = 0; col < this.value[row].Length; col++)
                {
                    sum += this.value[row][col];
                }
                Console.WriteLine(sum / this.value[row].Length);
            }
        }

        public void ChangeEvenElements()
        {
            for (int row = 0; row < this.value.Length; row++)
            {
                for (int col = 0; col < this.value[row].Length; col++)
                {
                    if (this.value[row][col] % 2 == 0)
                    {
                        this.value[row][col] = row * col;
                    }
                }
            }
        }
    }
}