using System;

namespace turChallenges
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] ops = new string[8]{
                "5", "-2", "4", "C", "D", "9", "+", "+"
            };

            int res = solution(ops);
            Console.WriteLine(String.Format("O valor retornado é de {0}", res));
        }

        static int solution(string[] ops)
        {
            int res = 0;
            RecordQueue queue = new RecordQueue();

            for (int i = 0; i < ops.Length; i++)
            {
                string op = ops[i];
                Record item;
                switch (op)
                {
                    case "C":
                        item = queue.Enqueue();
                        res -= item.value;
                        break;
                    case "D":
                        int doubleValue = 2 * queue.top.value;
                        res += doubleValue;
                        queue.Queue(doubleValue.ToString());
                        break;
                    case "+":
                        int sum = queue.getLastTwoValues();
                        res += sum;
                        queue.Queue(sum.ToString());
                        break;
                    default:
                        item = queue.Queue(op);
                        res += item.value;
                        break;
                }
            }

            return res;
        }
    }

    class RecordQueue
    {
        public Record top;

        public Record Queue(string value)
        {
            Record record = new Record(value);

            if (this.top != null)
            {
                record.last = this.top;
            }

            this.top = record;
            return record;
        }

        public int getLastTwoValues()
        {
            return top.value + top.last.value;
        }

        public Record Enqueue()
        {
            Record enqueued = this.top;
            this.top = enqueued.last;
            return enqueued;
        }
    }

    class Record
    {
        public Record last;
        public int value;

        public Record(string value)
        {
            this.value = int.Parse(value);
        }
    }
}
