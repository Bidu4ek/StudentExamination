using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SE
{
    public partial class Form1 : Form
    {
        StudentExamDB sxdb;
        RezDB rezult;
        String Name;
        String NumZK;
        String password;
        bool redactor;
        int numst;
        int numcur;
        int numcur1;
        int viewcur;
        public Form1()
        {
            InitializeComponent();
            sxdb = new StudentExamDB();
            rezult = new RezDB();
            numst = 0;
            numcur = 0;
            PasswordDialog.Visible = false;
            password = "admin";
            redactor = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int s = 0;
            int s1 = 0;
            Name = comboBoxNameS.Text;
            if (numst > 0)
            {
                while (s != numst)
                {
                    if (Name == sxdb.Db.ElementAt(s).Name)
                    {
                        s1++;
                    }
                    s++;
                }
                if (s1 == 0)
                {
                    comboBoxNameS.AutoCompleteCustomSource.Add(Name);
                    comboBoxNameS.Items.Add(Name);
                }
            }
            else
            {
                comboBoxNameS.AutoCompleteCustomSource.Add(Name);
                comboBoxNameS.Items.Add(Name);
            }
            NumZK = textBoxNZK.Text;
            String Faculty = comboBoxFac.Text;
            String Group = textBoxCur.Text;
            String Teacher = textBoxTeach.Text;
            String Subject = textBoxSub.Text;
            try
            {
                int Ament = Math.Abs(Convert.ToInt32(textBoxAs.Text));
                if (Ament > 5)
                {
                    MessageBox.Show("Оценка больше 5 баллов! Будет внесено по умолчанию 5 баллов");
                    Ament = 5;
                }
                Rez rz = new Rez(Teacher, Subject, Ament);
                rezult.Rb.Add(rz);
                Student st = new Student(Name,NumZK,Faculty, Group, rezult);
                sxdb.Db.Add(st);
                if (numst > 0)
                {
                    if (Name == sxdb.Db.ElementAt(numst - 1).Name)
                    {
                        String[] row = { "", "", "", "", "", Subject, Teacher, Convert.ToString(rezult.Rb.ElementAt(numst).Assessment) };
                        dataStudent.Rows.Add(row);
                    }
                    else if (Name != sxdb.Db.ElementAt(numst - 1).Name)
                    {
                        String[] row = { Convert.ToString(numcur + 1), Name, NumZK, Faculty, Group, Subject ,Teacher, Convert.ToString(rezult.Rb.ElementAt(numst).Assessment) };
                        numcur++;
                        dataStudent.Rows.Add(row);
                    }
                }
                else
                {
                    String[] row = { Convert.ToString(numcur + 1), Name, NumZK, Faculty, Group, Subject, Teacher, Convert.ToString(rezult.Rb.ElementAt(numst).Assessment) };
                    numcur++;
                    dataStudent.Rows.Add(row);
                }
               
                numst++;
            }
            catch
            {
                MessageBox.Show("Ошибка ввода оценки!");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked==true)
            {
                PasswordDialog.Visible = true;
                button1.Visible = false;
                tableLayoutPanel1.Visible = false;
            }
           else if(checkBox1.Checked == false)
            {
                PasswordDialog.Visible = false;
                redactor = false;
                button1.Visible = true;
                dataStudent.ReadOnly = true;
                tableLayoutPanel1.Visible = true;
            }
        }

        private void buttonPasFalse_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            PasswordDialog.Visible = false;
            dataStudent.ReadOnly = true;
            tableLayoutPanel1.Visible = true;
        }

        private void buttonPasTrue_Click(object sender, EventArgs e)
        {
            if (PasswordBox.Text == password)
            {
                PasswordDialog.Visible = false;
                PasswordBox.Text = null;
                redactor = true;
                dataStudent.ReadOnly = false;
                button1.Visible = false;
            }
            else
            {
                MessageBox.Show("Неверный ввод пароля!");
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void GoodStutents_CheckedChanged(object sender, EventArgs e)
        {
            viewcur = 0;
            numcur1 = 0;
            if (BadStudents.Checked == true)
            {
                BadStudents.Checked = false;
                dataGridView.Rows.Clear();
            }
            if (GoodStutents.Checked == true)
            {
                while (viewcur < sxdb.Db.Count)
                {

                    if (viewcur > 0)
                    {
                        if (sxdb.Db.ElementAt(viewcur).Name == sxdb.Db.ElementAt(viewcur - 1).Name)
                        {
                            String[] row = { "", "", "", "", "", sxdb.Db.ElementAt(viewcur).Rezult.Rb.ElementAt(viewcur).Sub, sxdb.Db.ElementAt(viewcur).Rezult.Rb.ElementAt(viewcur).Name, Convert.ToString(sxdb.Db.ElementAt(viewcur).Rezult.Rb.ElementAt(viewcur).Assessment) };
                            dataGridView.Rows.Add(row);
                        }
                        else if (Name != sxdb.Db.ElementAt(viewcur - 1).Name)
                        {
                            numcur1++;
                            String[] row = { Convert.ToString(numcur1 + 1), sxdb.Db.ElementAt(viewcur).Name, sxdb.Db.ElementAt(viewcur).NumZK, sxdb.Db.ElementAt(viewcur).Facul, sxdb.Db.ElementAt(viewcur).Group, sxdb.Db.ElementAt(viewcur).Rezult.Rb.ElementAt(viewcur).Sub, sxdb.Db.ElementAt(viewcur).Rezult.Rb.ElementAt(viewcur).Name, Convert.ToString(sxdb.Db.ElementAt(viewcur).Rezult.Rb.ElementAt(viewcur).Assessment) };
                            dataGridView.Rows.Add(row);
                        }
                    }
                    else
                    {
                        String[] row = { Convert.ToString(numcur1 + 1), sxdb.Db.ElementAt(viewcur).Name, sxdb.Db.ElementAt(viewcur).NumZK, sxdb.Db.ElementAt(viewcur).Facul, sxdb.Db.ElementAt(viewcur).Group, sxdb.Db.ElementAt(viewcur).Rezult.Rb.ElementAt(viewcur).Sub, sxdb.Db.ElementAt(viewcur).Rezult.Rb.ElementAt(viewcur).Name, Convert.ToString(sxdb.Db.ElementAt(viewcur).Rezult.Rb.ElementAt(viewcur).Assessment) };
                        dataGridView.Rows.Add(row);
                    }
                    viewcur++;
                }
            }
            else
            {
                dataGridView.Rows.Clear();
            }
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("База данных сессии. Beta (c)2018");
        }
    }
}
