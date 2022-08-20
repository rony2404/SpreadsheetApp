using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;


namespace SpreadsheetApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            loadButton.Visible = false;
            textBox1.Visible = false;
            label1.Visible = false;
            button2.Visible = false;
            rows.Visible = false;
            columns.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            back.Visible = false;
        }

        private void newSheet_Click(object sender, EventArgs e)
        {
            newSheet.Visible = false;
            button1.Visible = false;
            label2.Visible = true;
            label3.Visible=true;
            rows.Visible = true;
            columns.Visible = true;
            button2.Visible=true;
            back.Visible=true;
        }

        private void openForm2(int rows, int columns)
        {
            Form2 form = new Form2(rows,columns);
            form.ShowDialog();
        }

        //load existing file buuton
        private void button1_Click(object sender, EventArgs e)
        {
            newSheet.Visible = false;
            button1.Visible = false;
            loadButton.Visible = true;
            textBox1.Visible = true;
            label1.Visible = true;
            back.Visible = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            bool flag = false;
            string path = textBox1.Text;
            if (String.IsNullOrEmpty(path))
            {
                MessageBox.Show("path needs to be filled.");
                flag = true;
            }
            if (!flag)
            {
                this.Close();
                Thread th = new Thread(() => openForm2path(path));
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            }
        }

        private void openForm2path(string path)
        {
            Form2 form = new Form2(path);
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool flag=false;
            String rowsText = rows.Text;
            String columnsText = columns.Text;
            if (String.IsNullOrEmpty(rowsText)||String.IsNullOrEmpty(columnsText))
            {
                MessageBox.Show("Both rows and columns parameters needs to be filled.");
                flag = true;
            }
            int rowNum;
            int columnNum;
            bool rowFlag = int.TryParse(rowsText, out rowNum);
            bool columnFlag = int.TryParse(columnsText, out columnNum);
            if (!flag)
            {
                if (!rowFlag || !columnFlag)
                {
                    MessageBox.Show("Both rows and columns parameters needs to be integers bigger than 0.");
                    flag = true;
                }
            }
            if (!flag)
            {
                if (rowNum <= 0 || columnNum <= 0)
                {
                    MessageBox.Show("Both rows and columns parameters needs to be bigger than 0.");
                    flag = true;
                }
            }

            if (!flag)
            {
                this.Close();
                Thread th = new Thread(() => openForm2(rowNum, columnNum));
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            loadButton.Visible = false;
            textBox1.Visible = false;
            label1.Visible = false;
            button2.Visible = false;
            rows.Visible = false;
            columns.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            back.Visible = false;
            newSheet.Visible = true;
            button1.Visible = true;
        }
    }
}
