using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

/*Козлов Руслан*/

namespace HomeWork8
{
    public partial class Form1 : Form
    {
        TrueFalse database;
        TrueFalseBirths birthsdatabase;
        List<Student> students;
        string currentPath;
        string birthsCurrentPath;
        string csvCurrentPath;
        public Form1()
        {
            InitializeComponent();
            GetDateTimeProperties();
        }

        private void EnableControls()
        {
            nudNumber.Enabled = true;
            cboxTrue.Enabled = true;
            nudNumber.Enabled = true;
            btnAdd.Enabled = true;
            btnDelete.Enabled = true;
            tboxQuestion.Enabled = true;
            btnOutput.Enabled = true;
            btnSave.Enabled = true;
        }
        


        public void GetDateTimeProperties()
        {
            Type type = typeof(DateTime);
            foreach (var property in type.GetProperties())
            {
                textBox1.Text += $"{property.Name}  \r\n";
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            textBox2.Text = numericUpDown1.Value.ToString();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            numericUpDown1.Value = Convert.ToInt32(textBox2.Text);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number))
                e.Handled = true;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage3)
                menuStrip1.Show();
            else menuStrip1.Hide();
        }

        private void miExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void miSave_Click(object sender, EventArgs e)
        {
            if (database != null)
            {
                database.fileName = currentPath;
                database.Save();
                console.AppendText($"\r\nБаза данных сохранена {database.fileName}\r\n");
            }
            else MessageBox.Show("База данных не создана");
        }

        private void miNew_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "База данных вопросов(*.qdb)|*.qdb";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                database = new TrueFalse(sfd.FileName);
                currentPath = sfd.FileName;
                database.Add("Ваш вопрос", true);
                database.Save();
                nudNumber.Minimum = 1;
                nudNumber.Maximum = 1;
                nudNumber.Value = 1;
                lInfo.Text = $"База данных: {sfd.FileName}";
                console.AppendText($"Создана новая база данных {sfd.FileName}\r\n");
                EnableControls();
            };
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (database == null)
            {
                MessageBox.Show("Создайте новую базу данных", "Сообщение");
                return;
            }
            if (tboxQuestion.Text.Length == 0)
            {
                MessageBox.Show("Поле вопроса не может быть пустым");
                return;
            }          
            tboxQuestion.Text = "Ваш вопрос";
            database.Add(tboxQuestion.Text, true);
            nudNumber.Maximum = database.Count;
            nudNumber.Value = database.Count;
            console.AppendText($"\r\nДобавлен вопрос №{nudNumber.Value}\r\n");  
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (nudNumber.Maximum == 1 || database == null)
            {
                console.AppendText("\r\nНевозможно удалить единственный элемент базы.");
                return;
            }
            console.AppendText($"\r\nВопрос №{nudNumber.Value} удалён\r\n\t ({database[(int)nudNumber.Value - 1].Text}) ({database[(int)nudNumber.Value - 1].TrueFalse})\r\n");
            database.Remove((int)nudNumber.Value-1);            
            nudNumber.Maximum--;
            tboxQuestion.Text = database[(int)nudNumber.Value - 1].Text;
            if (nudNumber.Value > 1) nudNumber.Value = nudNumber.Value;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
        }

        private void miOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "База данных вопросов(*.qdb)|*.qdb";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                database = new TrueFalse(ofd.FileName);
                currentPath = ofd.FileName;
                database.Load();
                nudNumber.Minimum = 1;
                nudNumber.Maximum = database.Count;
                nudNumber.Value = 1;
                tboxQuestion.Text = database[(int)nudNumber.Value - 1].Text;
                cboxTrue.Checked = database[(int)nudNumber.Value - 1].TrueFalse;
                lInfo.Text = $"База данных: {ofd.FileName}";
                console.AppendText($"\r\nОткрыта база данных {ofd.FileName}\r\n");
                EnableControls();
                if (database[0].Text.Length == 0) btnDelete.Enabled = false;
            }            
        }

        private void nudNumber_ValueChanged_1(object sender, EventArgs e)
        {            
            tboxQuestion.Text = database[(int)nudNumber.Value - 1].Text;
            cboxTrue.Checked = database[(int)nudNumber.Value - 1].TrueFalse;
            
        }

        private void miAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Руслан Козлов \r\nВерсия: v.1.0.1 \r\n{Convert.ToChar(169)} Ruslan Studio {DateTime.Now.Year}. ","О программе");
        }

        private void numericUpDown1_ValueChanged_1(object sender, EventArgs e)
        {
            textBox2.Text = numericUpDown1.Value.ToString();
        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            if (textBox2.Text.Length>0)
                numericUpDown1.Value = Convert.ToInt32(textBox2.Text);
            else
                numericUpDown1.Value = 0;        
        }

        private void textBox2_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else if (!Char.IsDigit(number))
            {
                e.Handled = true;
            }
        }

        private void miSaveAs_Click(object sender, EventArgs e)
        {
            if (database != null)
            {
                SaveFileDialog sfd2 = new SaveFileDialog();
                sfd2.Filter = "База данных вопросов(*.qdb)|*.qdb";
                if (sfd2.ShowDialog() == DialogResult.OK)
                {
                    database.SaveAs(sfd2.FileName);
                    currentPath = sfd2.FileName;
                    console.AppendText($"\r\nБаза данных {sfd2.FileName} сохранена\r\n");
                };
            }
            else MessageBox.Show("База данных не создана");

            

        }

        private void btnConsClear_Click(object sender, EventArgs e)
        {
            console.Clear();
        }

        private void btnOutput_Click(object sender, EventArgs e)
        {
            if (database != null && database[0].Text.Length>0)
            {
                console.AppendText($"\r\nПуть к базе: {database.fileName}\r\n--------------------------------------------");
                for (int i = 0; i < database.Count; i++)
                {
                    console.AppendText($"\r\n\t{database[i].Text} ({database[i].TrueFalse}) ");
                }
                console.AppendText("\r\n--------------------------------------------");
            } else console.AppendText("\r\nБаза данных пуста");

        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (database == null)
            {
                MessageBox.Show("Создайте новую базу данных", "Сообщение");
                return;
            }
            if (tboxQuestion.Text.Length == 0)
            {
                MessageBox.Show("Поле вопроса не может быть пустым");
                return;
            }
            btnDelete.Enabled = true;

            database[(int)nudNumber.Value - 1].Text = tboxQuestion.Text;
            database[(int)nudNumber.Value - 1].TrueFalse = cboxTrue.Checked;
            console.AppendText($"\r\nВопрос №{nudNumber.Value} сохранён\r\n\t ({database[(int)nudNumber.Value - 1].Text})({database[(int)nudNumber.Value - 1].TrueFalse})\r\n");
        }

        private void btnNewBirthBase_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Файлы дат дней рождений(*.births)|*.births";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                birthsdatabase = new TrueFalseBirths(sfd.FileName);
                birthsCurrentPath = sfd.FileName;
                birthsdatabase.Save();
                tbBirthsOutput.Clear();
            };
        }

        private void btnOpenBirthBase_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Файлы дат дней рождений(*.births)|*.births";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                birthsdatabase = new TrueFalseBirths(ofd.FileName);
                birthsCurrentPath = ofd.FileName;
                birthsdatabase.Load();
                tbBirthsOutput.Clear();
                for (int i = 0; i < birthsdatabase.Count; i++)
                {
                    tbBirthsOutput.AppendText($"\r\n{birthsdatabase[i].name} {birthsdatabase[i].date.ToString("dd/MM/yyyy")}\r\n");
                }

            }
        }

        private void btnSaveBirthBase_Click(object sender, EventArgs e)
        {
            if (birthsdatabase != null)
            {
                birthsdatabase.fileName = birthsCurrentPath;
                birthsdatabase.Save();
            }
            else MessageBox.Show("Файл дат не был создан");
        }

        private void btnAddBirth_Click(object sender, EventArgs e)
        {
            if (birthsdatabase == null)
            {
                MessageBox.Show("Создайте новый файл дат", "Сообщение");
                return;
            }
            if (tbName.Text.Length == 0)
            {
                MessageBox.Show("Поле имени не может быть пустым");
                return;
            }
            try
            {
                Convert.ToDateTime(mtbDate.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Дата введена некорректно");
                return;
            }
            birthsdatabase.Add(tbName.Text, Convert.ToDateTime(mtbDate.Text));
            tbBirthsOutput.AppendText($"\r\n{birthsdatabase[birthsdatabase.Count-1].name} {birthsdatabase[birthsdatabase.Count-1].date.ToString("dd/MM/yyyy")}\r\n");
        }

        private void btnOpenCSV_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Файлы коллекций(*.csv)|*.csv";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                students = new List<Student>();
                csvCurrentPath = tbCsvPath.Text = ofd.FileName;
                using (StreamReader sr = new StreamReader(csvCurrentPath))
                {
                    while (!sr.EndOfStream)
                    {
                        try
                        {
                            string[] s = sr.ReadLine().Split(';');
                            students.Add(new Student(s[0], s[1], s[2], s[3], s[4], int.Parse(s[5]), int.Parse(s[6]), int.Parse(s[7]), s[8]));

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        for (int i = 0; i < students.Count; i++)
                        {

                        }
                    }
                }               

            }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            if (students != null)
            {
                SaveFileDialog sfd2 = new SaveFileDialog();
                sfd2.Filter = "Файлы xml(*.xml)|*.xml";
                if (sfd2.ShowDialog() == DialogResult.OK)
                {
                    csvCurrentPath = sfd2.FileName;

                    XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Student>));
                    Stream fStream = new FileStream(csvCurrentPath, FileMode.Create, FileAccess.Write);
                    xmlFormat.Serialize(fStream, students);
                    fStream.Close();

                    
                    MessageBox.Show("Файл конвертирован");
                };
            }
            else MessageBox.Show("Файл не выбран");
        }
    }
}
