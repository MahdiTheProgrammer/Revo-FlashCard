using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace Revo
{
    public partial class Form3 : Form
    {
        public static Form1 form1 = new Form1();
        ListBox listbox1 = new ListBox();
        ListBox listbox2 = new ListBox();
        ListBox listbox3 = new ListBox();
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            form1.Show();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            if (!File.Exists("ilan1.txt"))
            {
                File.WriteAllText("ilan1.txt", "");
            }
            if (!File.Exists("ilan2.txt"))
            {
                File.WriteAllText("ilan2.txt", "");
            }
            form1.illan1 = File.ReadAllText("ilan1.txt").Split('$').ToList();
            form1.illan2 = File.ReadAllText("ilan2.txt").Split('$').ToList();
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
                listBox1.Items.Add(form1.illan1[f1]);
            }
            for (int f2 = 0; f2 < form1.illan2.Count; f2++)
            {
                listBox2.Items.Add(form1.illan2[f2]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            form1.illan1.Clear();
            form1.illan2.Clear();
            form1.islan1 = "";
            form1.islan2 = "";

            for (int f1 = 0; f1 < listBox1.Items.Count; f1++)
            {
                form1.islan1 = form1.islan1 + listBox1.Items[f1].ToString() + "$";
            }
            for (int f2 = 0; f2 < listBox2.Items.Count; f2++)
            {
                form1.islan2 = form1.islan2 + listBox2.Items[f2].ToString() + "$";
            }
            File.WriteAllText("ilan1.txt", form1.islan1);
            File.WriteAllText("ilan2.txt", form1.islan2);
            form1.illan1 = File.ReadAllText("ilan1.txt").Split('$').ToList();
            form1.illan2 = File.ReadAllText("ilan2.txt").Split('$').ToList();
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
        }
    }
}
