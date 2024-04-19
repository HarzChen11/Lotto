using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.樂透
{
    internal static class Extension
    {
        public static void shownumber(this TextBox textBox,List<String> list)
        {
            foreach (var answers in list)
            {
                textBox.Text += answers + " ";
            }
        }
    }
}
