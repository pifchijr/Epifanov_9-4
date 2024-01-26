namespace Task_31
{
    public class Array1D
    {
        private int[] value;

        public int[] Value
        {
            get { return value; }
        }

        public Array1D(int length, bool fillByHand = false)
        {
            this.value = fillByHand ? this.FillByHand(length) : this.FillByRnd(length);
        }

        public int[] FillByHand(int n)
        {
            Console.WriteLine("Пишите элементы по очереди");
            int[] array = new int[n];
            string? input;
            for (int i = 0; i < array.Length; i++)
            {
                input = Console.ReadLine();
                array[i] = string.IsNullOrEmpty(input) ? 0 : int.Parse(input);
            }
            return array;
        }

        private int[] FillByRnd(int n)
        {
            int[] array = new int[n];
            Random rnd = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(-100, 100);
            }
            return array;
        }

        public void OutputArray()
        {
            Console.WriteLine(string.Join(", ", this.value));
        }

        public double GetAverage()
        {
            double sum = 0;
            for (int i = 0; i < this.value.Length; i++)
            {
                sum += this.value[i];
            }
            return sum / this.value.Length;
        }

        public void DeleteElementsOver100()
        {
            List<int> list = [];
            foreach (int item in this.value)
            {
                if (item > -100 && item < 100)
                {
                    list.Add(item);
                }
            }
            this.value = list.ToArray();
        }

        public void Deduplicate()
        {
            List<int> list = [];
            foreach (int item in this.value)
            {
                if (!list.Contains(item))
                {
                    list.Add(item);
                }
            }
            this.value = list.ToArray();
        }
    }
}