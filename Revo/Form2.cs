using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Revo
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public static Form1 form1 = new Form1();
        ListBox listbox1 = new ListBox();
        ListBox listbox2 = new ListBox();
        ListBox listbox3 = new ListBox();

        private void Form2_Load(object sender, EventArgs e)
        {
            if (!File.Exists("lan1.txt"))
            {
                File.WriteAllText("lan1.txt", "");
            }
            if (!File.Exists("lan2.txt"))
            {
                File.WriteAllText("lan2.txt", "");
            }
            form1.llan1 = File.ReadAllText("lan1.txt").Split('$').ToList();
            form1.llan2 = File.ReadAllText("lan2.txt").Split('$').ToList();
            form1.illan1 = File.ReadAllText("ilan1.txt").Split('$').ToList();
            form1.illan2 = File.ReadAllText("ilan2.txt").Split('$').ToList();
            lai.Clear();
            for (int f1 = 0; f1 < form1.llan1.Count - 1; f1++)
            {
                listBox1.Items.Add(form1.llan1[f1]);
            }
            for (int f2 = 0; f2 < form1.llan2.Count - 1; f2++)
            {             
                listBox2.Items.Add(form1.llan2[f2]);
            }
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            form1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                listBox1.Items.Add(textBox1.Text);
                listBox2.Items.Add(textBox2.Text);
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                label4.ForeColor = Color.Red;
            if (textBox1.Text != "")
                label4.ForeColor = Color.Green;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
                label5.ForeColor = Color.Red;
            if (textBox2.Text != "")
                label5.ForeColor = Color.Green;
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                if (listBox1.SelectedItems.IndexOf(listBox1.Items[i]) != -1)
                {
                    listBox1.Items.Remove(listBox1.Items[i]);
                    listBox2.Items.Remove(listBox2.Items[i]);
                    i--;
                }
            }
        }
        public string slan1;
        public string slan2;
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            form1.llan1.Clear();
            form1.llan2.Clear();
            slan1 = "";
            slan2 = "";

            for (int f1 = 0; f1 < listBox1.Items.Count; f1++)
            {
                slan1 = slan1 + listBox1.Items[f1].ToString() + "$";
            }
            for (int f2 = 0; f2 < listBox2.Items.Count; f2++)
            {
                slan2 = slan2 + listBox2.Items[f2].ToString() + "$";
            }
            File.WriteAllText("lan1.txt", slan1);
            File.WriteAllText("lan2.txt", slan2);
            form1.llan1 = File.ReadAllText("lan1.txt").Split('$').ToList();
            form1.llan2 = File.ReadAllText("lan2.txt").Split('$').ToList();

        }
        int x1=0, x2=0, x3=0;
        public string blan1;
        public string blan2;
        public List<string> bblan1 = new List<string>();
        public List<string> bblan2 = new List<string>();
        string sai;
        public List<string> lai = new List<string>();
        private void button3_Click(object sender, EventArgs e)
        {
            blan1 = "";
            blan2 = "";

            for (int f1 = 0; f1 < listBox1.Items.Count; f1++)
            {
                blan1 = blan1 + listBox1.Items[f1].ToString() + "$";
            }
            for (int f2 = 0; f2 < listBox2.Items.Count; f2++)
            {
                blan2 = blan2 + listBox2.Items[f2].ToString() + "$";
            }
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox1.Refresh();
            listBox2.Refresh();
            bblan1 = blan1.Split('$').ToList();
            bblan2 = blan2.Split('$').ToList();
            for (int f1 = 0; f1 < bblan1.Count - 1; f1++)
            {
                x1++;
                listBox2.Items.Add(bblan1[f1]);
            }
            for (int f2 = 0; f2 < bblan2.Count - 1; f2++)
            {
                x2++;
                listBox1.Items.Add(bblan2[f2]);
            }
            //----------------------------------marked
            lai = form1.illan1;
            form1.illan1 = form1.illan2;
            form1.illan2 = lai;
            //-
            form1.islan1 = "";
            form1.islan2 = "";
            if (form1.illan1[0] == "")
                form1.illan1.RemoveAt(0);
            if (form1.illan2[0] == "")
                form1.illan2.RemoveAt(0);
            try
            {
                if (form1.illan1[form1.illan1.Count - 1] == "")
                    form1.illan1.RemoveAt(form1.illan1.Count - 1);
                if (form1.illan2[form1.illan2.Count - 1] == "")
                    form1.illan2.RemoveAt(form1.illan2.Count - 1);
            }
            catch { }
            for (int f1 = 0; f1 < form1.illan1.Count; f1++)
            {
                form1.islan1 = form1.islan1 + form1.illan1[f1].ToString() + "$";
            }
            for (int f2 = 0; f2 < form1.illan2.Count; f2++)
            {
                form1.islan2 = form1.islan2 + form1.illan2[f2].ToString() + "$";
            }

            File.WriteAllText("ilan1.txt", form1.islan1);
            File.WriteAllText("ilan2.txt", form1.islan2);

        }
    }
}
