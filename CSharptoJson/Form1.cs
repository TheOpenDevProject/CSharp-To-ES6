using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharptoJson
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = this.textBox1.Text;
            string[] inputLines = input.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            string newList = "{";
            foreach (string currentLine in inputLines)
            {
                string identifier = Regex.Match(currentLine, "(?<=this.)(.*)(?=;)").ToString();
                newList += $"{identifier} : this.{identifier},";
            }
            newList += "}";
            this.textBox2.Text = newList;
        }
    }
}
