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
            var x = Regex.Matches(this.textBox1.Text, "(?:public\\s|private\\s|protected\\s)\\s*(?:readonly\\s+)?(?<type>\\w+)\\s+(?<name>\\w+)");
            string input = this.textBox1.Text;
            string finalClass = $"export class {Regex.Match(input, "(?<=public class )(.*)(?=)").ToString()}";
            finalClass += "{" + Environment.NewLine;
            finalClass += "constructor(){}" + Environment.NewLine; ;
            finalClass += "toJson(){" + Environment.NewLine; ;
            string[] inputLines = input.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            string newList = "{";
            foreach (string currentLine in inputLines)
            {
                string identifier = Regex.Match(currentLine, "(?<=this.)(.*)(?=;)").ToString();
                newList += $"{identifier} : this.{identifier},";
            }
            newList += "}";
            finalClass += "}";
            this.textBox2.Text = finalClass;

        }
    }
}
