using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpreadsheetApp
{
    public partial class Form2 : Form
    {
        private SharableSpreadSheet sheet;
        public Form2(int rows, int columns)
        {
            InitializeComponent();
            sheet = new SharableSpreadSheet(rows, columns);  
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            dataGridView1.RowCount = sheet.rows;
            dataGridView1.ColumnCount = sheet.columns;
            for (int i = 0; i < sheet.columns; i++)
            { 
                dataGridView1.Columns[i].Name = i.ToString();
                dataGridView1.Columns[i.ToString()].ReadOnly = true;
            }
            for (int i = 0; i < sheet.rows; i++)
                for (int j = 0; j < sheet.columns; j++)
                    dataGridView1.Rows[i].Cells[j].Value = sheet.sheet[i][j];

            row.Visible = false;
            column.Visible = false;
            str.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label3.Visible = false; 
            back.Visible = false;
            searchForColumn.Visible = false;
            searchForRow.Visible = false;
            searchForString.Visible = false;
            add.Visible = false;
            path.Visible = false;
            label5.Visible = false;
            load2.Visible = false;
            save2.Visible = false;
            rows2.Visible = true;
            cols2.Visible = true;
            str2.Visible = true;
            setCell.Visible = true;
            label4.Visible = false;

        }

        public Form2(string path)
        {
            InitializeComponent();
            sheet = new SharableSpreadSheet(1, 1);
            path = path.Trim();
            sheet.load(path);
        }

        private void searchString_Click(object sender, EventArgs e)
        {
            load.Visible = false;
            save.Visible = false;
            searchInColumn.Visible = false;
            searchInRow.Visible = false;
            searchString.Visible = false;
            row.Visible = false;
            column.Visible =false;
            label1.Visible = false;
            label2.Visible = false;
            searchForRow.Visible = false;
            searchForColumn.Visible = false;
            searchForString.Visible = true;
            str.Visible=true;
            back.Visible=true;
            back.Visible = true;
            label3.Visible = true;
            addColumn.Visible = false;
            path.Visible = false;
            label5.Visible = false;
            load2.Visible = false;
            rows2.Visible = false;
            cols2.Visible = false;
            str2.Visible = false;
            setCell.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
        }

        private void searchForString_Click(object sender, EventArgs e)
        {
            string text = str.Text;
            bool flag = false;
            if(String.IsNullOrEmpty(text))
            {
                flag = true;
                MessageBox.Show("You must give out a string to search for");
            }
            if(!flag)
            {
                Tuple<int, int> answer= sheet.searchString(text);
                if (answer.Item1 != -1 && answer.Item2 != -1)
                    MessageBox.Show("The string was fount at cell: " + "[" + answer.Item1 + "," + answer.Item2 + "].");
                else
                    MessageBox.Show("The string wasn't found.");
                str.Clear();
            }     
        }

        private void searchInRow_Click(object sender, EventArgs e)
        {
            searchString.Visible = false;
            searchInColumn.Visible=false;
            load.Visible = false;
            save.Visible=false; 
            searchInRow.Visible=false;
            column.Visible=false;
            label2.Visible=false;
            label1.Visible = true;
            searchForColumn.Visible=false;
            searchForString.Visible=false;
            row.Visible=true;
            str.Visible=true;
            searchForRow.Visible=true;
            back.Visible=true;
            label3.Visible=true;
            add.Visible=false;
            addColumn.Visible =false;
            path.Visible=false;
            label5.Visible = false;
            load2.Visible = false;
            rows2.Visible = false;
            cols2.Visible = false;
            str2.Visible = false;
            setCell.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;

        }

        private void searchInColumn_Click(object sender, EventArgs e)
        {
            searchForColumn.Visible = true;
            searchString.Visible = false;
            load.Visible = false;
            save.Visible = false;
            searchInRow.Visible = false;
            searchString.Visible=false;
            searchInColumn.Visible = false;
            label1.Visible = false;
            back.Visible=true;
            column.Visible=true;
            str.Visible =true;
            label2.Visible=true;
            label3.Visible =true;
            label4.Visible = false;
            add.Visible=false;
            addColumn.Visible=false;
            path.Visible = false;
            label5.Visible = false;
            load2.Visible = false;
            rows2.Visible = false;
            cols2.Visible = false;
            str2.Visible = false;
            setCell.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
        }

        private void searchForRow_Click(object sender, EventArgs e)
        {
            string text = str.Text;
            string rowText = row.Text;
            bool flag = false;
            int rowNum = 0;
            if (String.IsNullOrEmpty(text) || String.IsNullOrEmpty(rowText))
            {
                flag = true;
                MessageBox.Show("You need to fill out both parameters.");
            }
            if (!flag && !Int32.TryParse(rowText, out rowNum))
            {
                flag = true;
                MessageBox.Show("You need to give a valid row num.");
            }
            if (!flag && rowNum >= sheet.rows)
            {
                flag = true;
                MessageBox.Show("There isn't a row with this number.");
            }

            if (!flag)
            {
                int answer = sheet.searchInRow(rowNum, text);
                if (answer != -1)
                    MessageBox.Show("The string was fount at column: " + answer + " in this row");
                else
                    MessageBox.Show("The string wasn't found in this row.");
                str.Clear();
                row.Clear();
            }
        }

        private void searchForColumn_Click(object sender, EventArgs e)
        {
            string text = str.Text;
            string columnText = column.Text;
            bool flag = false;
            int columnNum = 0;
            if (String.IsNullOrEmpty(text) || String.IsNullOrEmpty(columnText))
            {
                flag = true;
                MessageBox.Show("You need to fill out both parameters.");
            }
            if (!flag && !Int32.TryParse(columnText, out columnNum))
            {
                flag = true;
                MessageBox.Show("You need to give a valid row num.");
            }
            if (!flag && columnNum >= sheet.columns)
            {
                flag = true;
                MessageBox.Show("There isn't a row with this number.");
            }

            if (!flag)
            {
                int answer = sheet.searchInCol(columnNum, text);
                if (answer != -1)
                    MessageBox.Show("The string was fount at row: " + answer + " in this column");
                else
                    MessageBox.Show("The string wasn't found in this column.");
                str.Clear();
                column.Clear();
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            searchString.Visible = true;
            searchInColumn.Visible = true;
            searchInRow.Visible = true;
            load.Visible = true;
            save.Visible = true;
            row.Visible = false;
            column.Visible = false;
            str.Visible = false;
            searchForColumn.Visible = false;
            searchForRow.Visible = false;
            searchForString.Visible = false;
            back.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            add.Visible  = false;
            addColumn.Visible = true;
            path.Visible = false;
            label5.Visible = false;
            load2.Visible = false;
            save2.Visible = false;
            rows2.Visible = true;
            cols2.Visible = true;
            str2.Visible = true;
            setCell.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void addColumn_Click(object sender, EventArgs e)
        {
            load.Visible = false;
            save.Visible = false;
            searchInColumn.Visible = false;
            searchInRow.Visible = false;
            searchString.Visible = false;
            row.Visible = false;
            column.Visible = true;
            label1.Visible = false;
            label2.Visible = false;
            searchForRow.Visible = false;
            searchForColumn.Visible = false;
            searchForString.Visible = false;
            addColumn.Visible = false;
            str.Visible = false;
            back.Visible = true;
            label3.Visible = false;
            label4.Visible = true;
            add.Visible = true;
            path.Visible=false;
            label5.Visible = false;
            load2.Visible = false;
            rows2.Visible = false;
            cols2.Visible = false;
            str2.Visible = false;
            setCell.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
        }

        private void add_Click(object sender, EventArgs e)
        {
            int columnNum;
            bool columnFlag = int.TryParse(column.Text, out columnNum);
            if (!columnFlag)
            {
                MessageBox.Show("columns parameters needs to be integers bigger than 0.");
            }
            else
            {
                for (int i = 0; i < sheet.rows; i++)
                    for (int j = 0; j < sheet.columns; j++)
                        sheet.sheet[i][j] = dataGridView1.Rows[i].Cells[j].Value.ToString();

                sheet.addCol(columnNum);
                dataGridView1.Columns.Add(sheet.columns.ToString(), sheet.columns.ToString());
                for (int i = 0; i < sheet.rows; i++)
                    for (int j = 0; j < sheet.columns; j++)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = sheet.sheet[i][j];
                    }
            }
            column.Clear();
        }

        private void save_Click(object sender, EventArgs e)
        {
            load.Visible = false;
            save.Visible = false;
            searchInColumn.Visible = false;
            searchInRow.Visible = false;
            searchString.Visible = false;
            row.Visible = false;
            column.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            searchForRow.Visible = false;
            searchForColumn.Visible = false;
            searchForString.Visible = false;
            addColumn.Visible = false;
            str.Visible = false;
            back.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            add.Visible = false;
            path.Visible = false;
            path.Visible = true;
            back.Visible = true;
            path.Visible = true;
            label5.Visible = true;
            load2.Visible = false;
            save2.Visible = true;
            rows2.Visible = false;
            cols2.Visible = false;
            str2.Visible = false;
            setCell.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
        }

        private void load_Click(object sender, EventArgs e)
        {
            load.Visible = false;
            save.Visible = false;
            searchInColumn.Visible = false;
            searchInRow.Visible = false;
            searchString.Visible = false;
            row.Visible = false;
            column.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            searchForRow.Visible = false;
            searchForColumn.Visible = false;
            searchForString.Visible = false;
            addColumn.Visible = false;
            str.Visible = false;
            back.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            add.Visible = false;
            path.Visible = false;
            path.Visible = true;
            back.Visible = true;
            path.Visible = true;
            label5.Visible = true;
            load2.Visible = true;
            save2.Visible = false;
            rows2.Visible = false;
            cols2.Visible = false;
            str2.Visible = false;
            setCell.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void load2_Click(object sender, EventArgs e)
        {
            string p= path.Text;
            bool flag = false;
            if(string.IsNullOrEmpty(p))
            {
                flag = true;
                MessageBox.Show("You must enter a file path");
            }
            if(!flag)
            {
                try
                {
                    p = p.Trim();
                    dataGridView1.RowCount = sheet.rows;
                    dataGridView1.ColumnCount = sheet.columns;
                    for (int i = 0; i < sheet.columns; i++)
                        dataGridView1.Columns[i].Name = i.ToString();
                    for (int i = 0; i < sheet.rows; i++)
                        for (int j = 0; j < sheet.columns; j++)
                            dataGridView1.Rows[i].Cells[j].Value = sheet.sheet[i][j];
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                path.Clear();
            }
        }

        private void save2_Click(object sender, EventArgs e)
        {
            string p = path.Text;
            bool flag = false;
            if (string.IsNullOrEmpty(p))
            {
                flag = true;
                MessageBox.Show("You must enter a file path");
            }
            if (!flag)
            {
                try
                {
                    p = p.Trim();
                    sheet.save(p);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                path.Clear();
            }
        }

        private void setCell_Click(object sender, EventArgs e)
        {
            string rowText = rows2.Text;
            string colText = cols2.Text;
            string txt = str2.Text;
            bool flag = false;

            if (string.IsNullOrEmpty(txt) || string.IsNullOrEmpty(rowText) || string.IsNullOrEmpty(colText))
            {
                MessageBox.Show("All parameners must be filled");
                flag = true;
            }

            int rowNum = 0;
            int colNum = 0;
            if (!flag && (!int.TryParse(rowText, out rowNum) || !int.TryParse(colText, out colNum)))
            {
                MessageBox.Show("rows and columns needs to be integers.");
                flag = true;
            }

            if(!flag)
            {
                try
                {
                    sheet.setCell(rowNum, colNum, txt);
                    dataGridView1.Rows[rowNum].Cells[colNum].Value = txt;
                    rows2.Clear();
                    cols2.Clear();
                    str2.Clear();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
            
    }

}
