using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.樂透
{
    internal class Lottoy
    {
        public List<String> RandomNumbers()
        {
            List<String> list = new List<String>();
            Random random = new Random(Guid.NewGuid().GetHashCode());
            for (int i = 0; i < 7; i++)
            {
                int check = random.Next(1, 43);
                list.Add(check.ToString());

                for (int j = 0; j < i; j++)
                {
                    while (list[j] == list[i])
                    {
                        list[i] = random.Next(1, 43).ToString();
                        j = 0;
                    }
                }
            }
            return list;
        }

        public int CheckNumber(List<String> numbers, List<String> answers)
        {
            int count = 0;
            foreach (var number in numbers)
            {
                foreach (var answer in answers)
                {
                    if (number == answer)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        
    }
}
