using System;
using System.Numerics;
using System.Windows.Forms;

namespace Revo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public List<string> llan1 = new List<string>();
        public List<string> llan2 = new List<string>();
        public List<string> illan1 = new List<string>();
        public List<string> illan2 = new List<string>();

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!File.Exists("lan1.txt"))
            {
                File.WriteAllText("lan1.txt", "");
            }
            if (!File.Exists("lan2.txt"))
            {
                File.WriteAllText("lan2.txt", "");
            }
            llan1 = File.ReadAllText("lan1.txt").Split('$').ToList();
            llan2 = File.ReadAllText("lan2.txt").Split('$').ToList();
            //-------------------------------------------------------
            //-------------------------------------------------------
            if (!File.Exists("ilan1.txt"))
            {
                File.WriteAllText("ilan1.txt", "");
            }
            if (!File.Exists("ilan2.txt"))
            {
                File.WriteAllText("ilan2.txt", "");
            }
            illan1 = File.ReadAllText("ilan1.txt").Split('$').ToList();
            illan2 = File.ReadAllText("ilan2.txt").Split('$').ToList();
            if (illan1[0]=="")
                illan1.RemoveAt(0);
            if (illan2[0]=="")
                illan2.RemoveAt(0);
            try
            {
                if (illan1[illan1.Count - 1] == "")
                    illan1.RemoveAt(illan1.Count - 1);
                if (illan2[illan2.Count - 1] == "")
                    illan2.RemoveAt(illan2.Count - 1);
            }
            catch { }
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void wordManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            button2.Visible = true;
            form2.Show();
            this.Hide();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("©️2022 MahdiTheProgrammer\n Mahdi Panahpour","About us",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void contactUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Email address:\n panahpourmohamadmahdi62@gmail.com", "Contact us", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        int kk;
        int kkg=0;
        public void next()
        {
            Random rnd = new Random();
            while (kk == kkg && llan1.Count>2)
            {
                kk = rnd.Next(0, llan1.Count - 1);
            }
            label1.Text = llan1[kk];
            if (illan1.Contains(label1.Text))
            {
                label2.Text = "Click here to unmark this word";
            }
            else
            {
                label2.Text = "Click here to mark this word";
            }
            kkg = kk;
            AcceptButton = button1;
            
            
        }
        int ikk;
        int ikkg;
        public void inext()
        {
            Random rnd = new Random();
            while (ikk == ikkg && illan1.Count > 1)
            {
                ikk = rnd.Next(0, illan1.Count);
            }
            if (illan1.Count == 1)
            {
                ikk = rnd.Next(0, illan1.Count);
            }

            label1.Text = illan1[ikk];
            if (illan1.Contains(label1.Text))
            {
                label2.Text = "Click here to unmark this word";
            }
            else
            {
                label2.Text = "Click here to mark this word";
            }
            ikkg = ikk;
            AcceptButton = button1;
        }
        public bool i;
        private void button1_Click(object sender, EventArgs e)
        {
            if (i == true)
            {
                if (textBox1.Text == illan2[ikk])
                {
                    textBox1.Text = "";
                    AcceptButton = button1;
                    inext();

                }
                else
                {
                    MessageBox.Show("Your answer is wrong\n Right answer is: " + illan2[ikk], "Wrong answer", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            else
            {
                if (textBox1.Text == llan2[kk])
                {
                    textBox1.Text = "";
                    AcceptButton = button1;
                    next();

                }
                else
                {
                    MessageBox.Show("Your answer is wrong\n Right answer is: " + llan2[kk], "Wrong answer", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (llan1.Count==1)
            {
                MessageBox.Show("Please add a vocabulary", "No vocabulary", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                button2.Visible = false;
                i = false;
                label3.Text = "Click here to only ask marked words";
                next();
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        public string islan1;
        public string islan2;
        private void label2_Click(object sender, EventArgs e)
        {
            if (illan1.Contains(label1.Text))
            {
                illan2.Remove(illan2[illan1.IndexOf(label1.Text)]);
                illan1.Remove(label1.Text);
                label2.Text = "Click here to mark this word";
                if(i==true)
                {
                    if (illan1.Count == 0)
                    {
                        MessageBox.Show("There is no more marked word", "No marked word", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        label3.Text = "Click here to only ask marked words";
                        i = false;
                        next();
                    }
                    else
                    {
                        inext();
                    }
                }
            }
            else
            {
                illan1.Add(label1.Text);
                illan2.Add(llan2[llan1.IndexOf(label1.Text)]);
                label2.Text = "Click here to unmark this word";
            }
            //------------------------------------------------------
            islan1 = "";
            islan2 = "";

            for (int f1 = 0; f1 < illan1.Count; f1++)
            {
                islan1 = islan1 + illan1[f1].ToString() + "$";
            }
            for (int f2 = 0; f2 < illan2.Count; f2++)
            {
                islan2 = islan2 + illan2[f2].ToString() + "$";
            }
            File.WriteAllText("ilan1.txt", islan1);
            File.WriteAllText("ilan2.txt", islan2);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            if (label3.Text == "Click here to only ask marked words")
            {
                if (illan1.Count == 0)
                {
                    MessageBox.Show("You don't have any marked word", "No marked word", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    label3.Text = "Click here to ask all words";
                    i = true;
                    inext();
                }
            }
            else
            {
                if (label3.Text == "Click here to ask all words")
                {
                    label3.Text = "Click here to only ask marked words";
                    i = false;
                    next();
                }
            }
        }

        private void markedWordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            button2.Visible = true;
            form3.Show();
            this.Hide();
        }
    }
}