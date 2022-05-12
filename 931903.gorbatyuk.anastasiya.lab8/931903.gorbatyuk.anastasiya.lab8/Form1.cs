using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _931903.gorbatyuk.anastasiya.lab8
{
    public partial class Form1 : Form
    {
        double[] pfreq = new double[5] {0,0,0,0,0 };
        double prob5;
        public Form1()
        {
            InitializeComponent();
            lbAnswer2.Text = "";
            ndProb1.ValueChanged += new System.EventHandler(this.ndProb1_ValueChanged);
            ndProb2.ValueChanged += new System.EventHandler(this.ndProb2_ValueChanged);
            ndProb3.ValueChanged += new System.EventHandler(this.ndProb3_ValueChanged);
            ndProb4.ValueChanged += new System.EventHandler(this.ndProb4_ValueChanged);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            lbAnswer.Text = "";
            double p = 0.5;
            Random rnd = new Random();
            double a = rnd.NextDouble();
            if (textBox1.Text != "")
            {
                if(a<p)
            {
                lbAnswer.Text = "Да!";
            }
            else
            {
                lbAnswer.Text = "Нет!";
            }

            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lbAnswer2.Text = "";

            double [] p = new double[6] {0.1,0.2,0.1,0.2,0.2,0.2};

            Random rnd = new Random();
            double a = rnd.NextDouble();
            if (textBox2.Text != "")
            {
                if ((0 <= a) && (a < p[0]))
                {
                    lbAnswer2.Text = "Нет!";
                }

                if ((p[0] <= a) && (a < (p[0]+p[1])))
                {
                    lbAnswer2.Text = "Лучше не стоит";
                }

                if (((p[0] + p[1]) <= a) && (a < (p[0] + p[1]+ p[2])) )
                {
                    lbAnswer2.Text = "Возможно";
                }

                if (((p[0] + p[1] + p[2]) <= a) && (a < (p[0] + p[1] + p[2]+ p[3])))
                {
                    lbAnswer2.Text = "Стоит пытаться";
                }

                if (((p[0] + p[1] + p[2] + p[3]) <= a) && (a < (p[0] + p[1] + p[2] + p[3]+p[4])))
                {
                    lbAnswer2.Text = "Скорее да";
                }

                if (((p[0] + p[1] + p[2] + p[3] + p[4]) <= a) && (a <= (p[0] + p[1] + p[2] + p[3] + p[4]+p[5])))
                {
                    lbAnswer2.Text = "Да!";
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int number = (int)ndNumExp.Value;
            int[] events = new int[5] {0,0,0,0,0 };
            double[] freq = new double [5] { 0, 0, 0, 0, 0 };

            Random rnd = new Random();

            for (int i=0; i<number;i++)
            {  
                
                double s = rnd.NextDouble();


                if ((0 <= s) && (s < pfreq[0]))
                {
                    events[0]=events[0]+1;
                }

                if ((pfreq[0] <= s) && (s < (pfreq[0] + pfreq[1])))
                {
                    events[1] = events[1] + 1;
                }

                if (((pfreq[0] + pfreq[1]) <= s) && (s < (pfreq[0] + pfreq[1] + pfreq[2])))
                {
                    events[2] = events[2] + 1;
                }

                if (((pfreq[0] + pfreq[1] + pfreq[2]) <= s) && (s < (pfreq[0] + pfreq[1] + pfreq[2] + pfreq[3])))
                {
                    events[3] = events[3] + 1;
                }

                if (((pfreq[0] + pfreq[1] + pfreq[2] + pfreq[3]) <= s) && (s < (pfreq[0] + pfreq[1] + pfreq[2] + pfreq[3] + pfreq[4])))
                {
                    events[4] = events[4] + 1;
                }

            }
            //for (int i = 0; i < 5; i++)
            //{
            //    Console.WriteLine(events[i]);
            //}

            for (int i = 0; i < 5; i++)
            {
                freq[i] = (double) events[i] / number;
                Console.WriteLine(freq[i]);
                chart1.Series[0].Points.AddXY(i, freq[i]);
            }
        }

        private void ndProb1_ValueChanged(Object sender, EventArgs e)
        {
            pfreq[0]=(double)ndProb1.Value;
            prob5 = 1- (pfreq[0] + pfreq[1] + pfreq[2] + pfreq[3]);
            lbProb5.Text = Math.Round(prob5, 3).ToString();
            if(prob5<0)
            {
                lbProb5.ForeColor = Color.Red;
                button3.Enabled = false;
            }
            else
            {
                lbProb5.ForeColor = Color.Black;
                button3.Enabled = true;
            }
            pfreq[4] = prob5;
        }

        private void ndProb2_ValueChanged(Object sender, EventArgs e)
        {
            pfreq[1] = (double)ndProb2.Value;
            prob5 = 1 -( pfreq[0] + pfreq[1] + pfreq[2] + pfreq[3]);
            lbProb5.Text = Math.Round(prob5, 3).ToString();
            if (prob5 < 0)
            {
                lbProb5.ForeColor = Color.Red;
                button3.Enabled = false;
            }
            else
            {
                lbProb5.ForeColor = Color.Black;
                button3.Enabled = true;
            }
            pfreq[4] = prob5;
        }

        private void ndProb3_ValueChanged(Object sender, EventArgs e)
        {
            pfreq[2] = (double)ndProb3.Value;
            prob5 = 1 - (pfreq[0] + pfreq[1] + pfreq[2] + pfreq[3]);
            lbProb5.Text = Math.Round(prob5, 3).ToString();
            if (prob5 < 0)
            {
                lbProb5.ForeColor = Color.Red;
                button3.Enabled = false;
            }
            else
            {
                lbProb5.ForeColor = Color.Black;
                button3.Enabled = true;
            }
            pfreq[4] = prob5;
        }

        private void ndProb4_ValueChanged(Object sender, EventArgs e)
        {
            pfreq[3] = (double)ndProb4.Value;
            prob5 = 1 - (pfreq[0] + pfreq[1] + pfreq[2] + pfreq[3]);
            lbProb5.Text = Math.Round(prob5, 3).ToString();
            if (prob5 < 0)
            {
                lbProb5.ForeColor = Color.Red;
                button3.Enabled = false;
            }
            else
            {
                lbProb5.ForeColor = Color.Black;
                button3.Enabled = true;
            }
            pfreq[4] = prob5;
        }
    }
}
