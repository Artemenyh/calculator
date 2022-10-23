using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Calculator
{
    public class logik
    {
        string a ="", b="", c="";
        int Num = 0;
        int count;
        int opt = -1;
        bool minus = false;
        bool minus2 = false;
        bool znak = true;
        public void reading(string num, TextBox textBox1)
        {
            if (Num == 0 && a.Length < 9)
            {
                a += num;
                textBox1.Text = a;
            }
            if (Num == 1 && b.Length < 9)
            {
                b += num;
                textBox1.Text = b;
            }
        }
        public void ZnakChisla(TextBox textBox1)
        {
            if (znak == true)
            {
                textBox1.Text = "-" + textBox1.Text;
                znak = false;
            }
            else if (znak == false)
            {
                textBox1.Text = textBox1.Text.Replace("-", "");
                znak = true;
            }
        }
        public void Tochka(TextBox textBox1)
        {
            if (textBox1.Text.IndexOf(',') == -1)
            {
                textBox1.Text += ",";
            }
        }
        public void Solushion(TextBox textBox1, Label label1)
        {
            double sum = 0;
            {
                if ((a != "0" && b != "0") || opt != 3)
                {
                    try
                    {
                        if (minus)
                        {
                            int buf;
                            buf = -1 * Convert.ToInt32(a);
                            a = Convert.ToString(buf);
                        }
                        if (minus2)
                        {
                            int buf;
                            buf = -1 * Convert.ToInt32(b);
                            b = Convert.ToString(buf);
                        }
                        switch (opt)
                        {
                            case 1:
                                sum = Convert.ToDouble(a) + float.Parse(textBox1.Text);
                                textBox1.Text = b.ToString();
                                break;

                            case 2:
                                sum = Convert.ToDouble(a) - float.Parse(textBox1.Text);
                                textBox1.Text = b.ToString();
                                break;
                            case 3:
                                sum = Convert.ToDouble(a) * float.Parse(textBox1.Text);
                                textBox1.Text = b.ToString();
                                break;
                            case 4:
                                sum = Convert.ToDouble(a) / float.Parse(textBox1.Text);
                                textBox1.Text = b.ToString();
                                break;

                            default:
                                break;
                        }
                    
                        if (sum <= 999999999 && sum >= -999999999)
                        {
                            if (sum < 0)
                            {
                                label1.Text = "-";
                            }
                            c = Convert.ToString(sum);
                            c = c.Replace("-", "");
                            
                            textBox1.Text = c;
                        }
                        else
                        {
                            textBox1.Text = "EXCEEDED";
                        }
                        a = c;
                        b = "";
                        c = "";
                        Num = 0;
                    }
                    catch (Exception)
                    {
                        //MessageBox.Show("Error, check the data");
                    }
                }
                else
                {
                    textBox1.Text = "NOT / 0";
                    a = "";
                    b = "";
                    c = "";
                    Num = 0;
                }
            }
        }        public void ClearSimvol(TextBox textBox1)
        {
            int lenght = textBox1.Text.Length - 1;
            string text = textBox1.Text;
            textBox1.Clear();
            for (int i = 0; i < lenght; i++)
            {
                textBox1.Text = textBox1.Text + text[i];
            }
        }
        //public void Clear(TextBox textBox1, Label label1)
        //{
        //    textBox1.Text = "";
        //    label1.Text = "";
        //}
        
        public void Operation(TextBox textBox1, int option, Label label1)
        {
            if (a != "")
            {
                if (b != "")
                {
                    Solushion(textBox1, label1);
                }
                Num = 1;
                label1.Text = "";
            }
            opt = option;

        }
         public void Clear(TextBox textBox1, Label label1)
        {
            textBox1.Text = c;
            a = "";
            b = "";
            c = "";
            textBox1.Text = "";
            Num = 0;
            label1.Text = "";
            minus = false;
            minus2 = false;
        }
        public void ReverseMinus(Label label1)
        {
            if (Num == 0)
            {
                if (label1.Text == "")
                {
                    label1.Text = "-";
                    minus = true;
                }
                else
                {
                    label1.Text = "";
                    minus = false;
                }
            }
            if (Num == 1)
            {
                if (label1.Text == "")
                {
                    label1.Text = "-";
                    minus2 = true;
                }
                else
                {
                    label1.Text = "";
                    minus2 = false;
                }
            }
        }
    
}
     
}
