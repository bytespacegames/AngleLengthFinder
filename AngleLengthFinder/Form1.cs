using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AngleLengthFinder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                label2.Text = "What is B?";
                label3.Text = "What is C?";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                label2.Text = "What is A?";
                label3.Text = "What is C?";
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                label2.Text = "What is A?";
                label3.Text = "What is B?";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double missing = 0;
            string missingPref = "if you see this the program is b roken";
            double tbOne = double.Parse(richTextBox1.Text);
            double tbTwo = double.Parse(richTextBox2.Text);
            if (radioButton3.Checked)
            {
                missingPref = "c";
                missing = Math.Sqrt((tbOne * tbOne) + (tbTwo * tbTwo));
            }
            if (radioButton2.Checked)
            {
                missingPref = "b";
                missing = Math.Sqrt((tbTwo * tbTwo) - (tbOne * tbOne));
            }
            if (radioButton1.Checked)
            {
                missingPref = "a";
                missing = Math.Sqrt((tbTwo * tbTwo) - (tbOne * tbOne));
            }
            label4.Text = missingPref + " = " + missing;
            if (checkBox1.Checked)
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\MathOutputs";

                // If directory does not exist, create it. 
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                using (StreamWriter streamWriter = new StreamWriter(Path.Combine(path, DateTimeOffset.Now.ToUnixTimeMilliseconds() + ".txt")))
                {
                    streamWriter.WriteLine("a^2 + b^2 = c^2");
                    if (radioButton3.Checked)
                    {
                        streamWriter.WriteLine(tbOne + "^2 + " + tbTwo + "^2 = c^2");
                        streamWriter.WriteLine((tbOne * tbOne) + " + " + (tbTwo * tbTwo) + " = c^2");
                        streamWriter.WriteLine((tbOne * tbOne) + (tbTwo * tbTwo) + " = c^2");
                        streamWriter.WriteLine("Sqrt " + (tbOne * tbOne) + (tbTwo * tbTwo) + " = " + Math.Sqrt((tbOne * tbOne) + (tbTwo * tbTwo)));
                    }
                    if (radioButton2.Checked)
                    {
                        streamWriter.WriteLine(tbTwo + "^2 - " + tbOne + "^2 = b^2");
                        streamWriter.WriteLine((tbTwo * tbTwo) + " - " + (tbOne * tbOne) + " = b^2");
                        streamWriter.WriteLine((tbTwo * tbTwo) - (tbOne * tbOne) + " = b^2");
                        streamWriter.WriteLine("Sqrt " + ((tbTwo * tbTwo) - (tbOne * tbOne)) + " = " + Math.Sqrt((tbTwo * tbTwo) - (tbOne * tbOne)));
                    }
                    if (radioButton1.Checked)
                    {
                        streamWriter.WriteLine(tbTwo + "^2 - " + tbOne + "^2 = a^2");
                        streamWriter.WriteLine((tbTwo * tbTwo) + " - " + (tbOne * tbOne) + " = a^2");
                        streamWriter.WriteLine((tbTwo * tbTwo) - (tbOne * tbOne) + " = a^2");
                        streamWriter.WriteLine("Sqrt " + ((tbTwo * tbTwo) - (tbOne * tbOne)) + " = " + Math.Sqrt((tbTwo * tbTwo) - (tbOne * tbOne)));
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
