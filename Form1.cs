using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.樂透
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Button button1 = new Button();
            //button1.Text = "1";
            //button1.Size = new Size(30, 30);
            //this.Controls.Add(button1);

            //Button button2 = new Button();
            //button2.Text = "2";
            //button2.Size = new Size(30, 30);
            //button2.Location = new Point(40, 0);
            //this.Controls.Add(button2);

            //int y = 0;
            //for (int i = 0; i <= 4; i++)
            //{
            //    for(int j = 1; j <= 10; j++)
            //    {
            //        Button button = new Button();
            //        button.Text = (i*10+j).ToString();
            //        button.Size = new Size(30, 30);
            //        button.Location = new Point(40 * (j - 1), y);


            //        if ((i * 10 + j)<50)
            //        {
            //            this.Controls.Add(button);
            //        }
            //    }
            //    y += 40;
            //}

            // 動態生成 Button
            for (int i = 1; i <= 42; i++)
            {
                Button button = new Button();
                button.Text = i.ToString();
                button.Width = 40;
                button.Height = 40;
                button.Click += Button_Click;
                flowLayoutPanel1.Controls.Add(button);
            }

        }

        List<Button> numbers = new List<Button>();
        List<String> answers = new List<String>();

        // 號碼按鈕
        private void Button_Click(object sender, EventArgs e)
        {
            if (numbers.Count < 7)
            {
                Button button = (Button)sender;
                textBox1.Text += button.Text + " ";
                button.Enabled = false;
                numbers.Add(button);
            }
            else
            {
                MessageBox.Show("最多只能選七個數字");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = " ";
            answers.Clear();
            Random random = new Random();


            //for (int i = 0; i < 7; i++)
            //{
            //    int check = random.Next(1, 10);
            //    while (answers.Contains(check.ToString()))
            //    {
            //        check = random.Next(1, 10);       
            //    }
            //    answers.Add(check.ToString());
            //}

            Lottoy lottoy = new Lottoy();
            if (numbers.Count == 7)
            {
                // 產生七個開獎號碼
                answers = lottoy.RandomNumbers();


                textBox2.shownumber(answers);
                //foreach (var answers in answers)
                //{
                //    textBox2.Text += answers + " ";
                //}


                List<String> number_str = new List<String>();
                foreach(var number in numbers)
                {
                    number_str.Add(number.Text);
                }
                // 比對開獎結果
                int count = lottoy.CheckNumber(number_str,answers);


                switch (count)
                {
                    case 7:
                        MessageBox.Show("恭喜中頭獎!");
                        break;
                    case 6:
                        MessageBox.Show("恭喜中頭二獎!");
                        break;
                    case 5:
                        MessageBox.Show("恭喜中頭三獎!");
                        break;
                    case 4:
                        MessageBox.Show("恭喜中四獎!");
                        break;
                    default:
                        MessageBox.Show("沒中獎! 只中" + count + "個號碼");
                        break;

                }
            }
            else
            {
                MessageBox.Show("請先選擇七個號碼");
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (numbers.Count > 0)
            {
                Button last = numbers.Last();
                last.Enabled = true;
                numbers.Remove(last);

                textBox1.Text = "";
                foreach (Button button in numbers)
                {
                    textBox1.Text += button.Text + " ";
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
            answers.Clear();
  

            Lottoy lottoy = new Lottoy();
            List<String> temps = lottoy.RandomNumbers();

            textBox1.shownumber(temps);
            //foreach (var temp in temps)
            //{
            //    textBox1.Text += temp + " ";
            //}

            answers = lottoy.RandomNumbers();
            textBox2.shownumber(answers);
           


            int count = lottoy.CheckNumber(temps, answers);

            switch (count)
            {
                case 7:
                    MessageBox.Show("恭喜中頭獎!");
                    break;
                case 6:
                    MessageBox.Show("恭喜中頭二獎!");
                    break;
                case 5:
                    MessageBox.Show("恭喜中頭三獎!");
                    break;
                case 4:
                    MessageBox.Show("恭喜中四獎!");
                    break;
                default:
                    MessageBox.Show("沒中獎! 只中" + count + "個號碼");
                    break;

            }

        }
    }
}
