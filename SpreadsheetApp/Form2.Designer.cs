namespace SpreadsheetApp
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.searchString = new System.Windows.Forms.Button();
            this.searchInRow = new System.Windows.Forms.Button();
            this.searchInColumn = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.load = new System.Windows.Forms.Button();
            this.row = new System.Windows.Forms.TextBox();
            this.column = new System.Windows.Forms.TextBox();
            this.str = new System.Windows.Forms.TextBox();
            this.searchForString = new System.Windows.Forms.Button();
            this.back = new System.Windows.Forms.Button();
            this.searchForRow = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.searchForColumn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.addColumn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.add = new System.Windows.Forms.Button();
            this.path = new System.Windows.Forms.TextBox();
            this.load2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.save2 = new System.Windows.Forms.Button();
            this.rows2 = new System.Windows.Forms.TextBox();
            this.cols2 = new System.Windows.Forms.TextBox();
            this.str2 = new System.Windows.Forms.TextBox();
            this.setCell = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(25, 149);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1136, 526);
            this.dataGridView1.TabIndex = 0;
            // 
            // searchString
            // 
            this.searchString.BackColor = System.Drawing.Color.White;
            this.searchString.Font = new System.Drawing.Font("Aharoni", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.searchString.Location = new System.Drawing.Point(12, 42);
            this.searchString.Name = "searchString";
            this.searchString.Size = new System.Drawing.Size(220, 35);
            this.searchString.TabIndex = 1;
            this.searchString.Text = "Search String";
            this.searchString.UseVisualStyleBackColor = false;
            this.searchString.Click += new System.EventHandler(this.searchString_Click);
            // 
            // searchInRow
            // 
            this.searchInRow.BackColor = System.Drawing.Color.White;
            this.searchInRow.Font = new System.Drawing.Font("Aharoni", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.searchInRow.Location = new System.Drawing.Point(251, 42);
            this.searchInRow.Name = "searchInRow";
            this.searchInRow.Size = new System.Drawing.Size(196, 36);
            this.searchInRow.TabIndex = 2;
            this.searchInRow.Text = "Search In Row";
            this.searchInRow.UseVisualStyleBackColor = false;
            this.searchInRow.Click += new System.EventHandler(this.searchInRow_Click);
            // 
            // searchInColumn
            // 
            this.searchInColumn.BackColor = System.Drawing.Color.White;
            this.searchInColumn.Font = new System.Drawing.Font("Aharoni", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.searchInColumn.Location = new System.Drawing.Point(467, 42);
            this.searchInColumn.Name = "searchInColumn";
            this.searchInColumn.Size = new System.Drawing.Size(226, 36);
            this.searchInColumn.TabIndex = 3;
            this.searchInColumn.Text = "Search In Column";
            this.searchInColumn.UseVisualStyleBackColor = false;
            this.searchInColumn.Click += new System.EventHandler(this.searchInColumn_Click);
            // 
            // save
            // 
            this.save.BackColor = System.Drawing.Color.White;
            this.save.Font = new System.Drawing.Font("Aharoni", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.save.Location = new System.Drawing.Point(1082, 42);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(87, 36);
            this.save.TabIndex = 4;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = false;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // load
            // 
            this.load.BackColor = System.Drawing.Color.White;
            this.load.Font = new System.Drawing.Font("Aharoni", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.load.Location = new System.Drawing.Point(981, 41);
            this.load.Name = "load";
            this.load.Size = new System.Drawing.Size(95, 36);
            this.load.TabIndex = 5;
            this.load.Text = "Load";
            this.load.UseVisualStyleBackColor = false;
            this.load.Click += new System.EventHandler(this.load_Click);
            // 
            // row
            // 
            this.row.Font = new System.Drawing.Font("Aharoni", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.row.Location = new System.Drawing.Point(53, 44);
            this.row.Name = "row";
            this.row.Size = new System.Drawing.Size(68, 31);
            this.row.TabIndex = 6;
            this.row.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // column
            // 
            this.column.BackColor = System.Drawing.Color.White;
            this.column.Font = new System.Drawing.Font("Aharoni", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.column.Location = new System.Drawing.Point(142, 44);
            this.column.Name = "column";
            this.column.Size = new System.Drawing.Size(70, 31);
            this.column.TabIndex = 7;
            this.column.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // str
            // 
            this.str.Font = new System.Drawing.Font("Aharoni", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.str.Location = new System.Drawing.Point(265, 44);
            this.str.Name = "str";
            this.str.Size = new System.Drawing.Size(196, 31);
            this.str.TabIndex = 8;
            this.str.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // searchForString
            // 
            this.searchForString.BackColor = System.Drawing.Color.White;
            this.searchForString.Font = new System.Drawing.Font("Aharoni", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.searchForString.Location = new System.Drawing.Point(557, 41);
            this.searchForString.Name = "searchForString";
            this.searchForString.Size = new System.Drawing.Size(226, 42);
            this.searchForString.TabIndex = 9;
            this.searchForString.Text = "Search";
            this.searchForString.UseVisualStyleBackColor = false;
            this.searchForString.Click += new System.EventHandler(this.searchForString_Click);
            // 
            // back
            // 
            this.back.BackColor = System.Drawing.Color.White;
            this.back.Font = new System.Drawing.Font("Aharoni", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.back.Location = new System.Drawing.Point(981, 13);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(188, 33);
            this.back.TabIndex = 10;
            this.back.Text = "Back to menu";
            this.back.UseVisualStyleBackColor = false;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // searchForRow
            // 
            this.searchForRow.BackColor = System.Drawing.Color.White;
            this.searchForRow.Font = new System.Drawing.Font("Aharoni", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.searchForRow.Location = new System.Drawing.Point(557, 41);
            this.searchForRow.Name = "searchForRow";
            this.searchForRow.Size = new System.Drawing.Size(226, 42);
            this.searchForRow.TabIndex = 11;
            this.searchForRow.Text = "Search";
            this.searchForRow.UseVisualStyleBackColor = false;
            this.searchForRow.Click += new System.EventHandler(this.searchForRow_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Aharoni", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(60, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "Row";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Aharoni", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(151, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "Column";
            // 
            // searchForColumn
            // 
            this.searchForColumn.BackColor = System.Drawing.Color.White;
            this.searchForColumn.Font = new System.Drawing.Font("Aharoni", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.searchForColumn.Location = new System.Drawing.Point(557, 41);
            this.searchForColumn.Name = "searchForColumn";
            this.searchForColumn.Size = new System.Drawing.Size(226, 42);
            this.searchForColumn.TabIndex = 14;
            this.searchForColumn.Text = "Search";
            this.searchForColumn.UseVisualStyleBackColor = false;
            this.searchForColumn.Click += new System.EventHandler(this.searchForColumn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Aharoni", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.Location = new System.Drawing.Point(324, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "String";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // addColumn
            // 
            this.addColumn.BackColor = System.Drawing.Color.White;
            this.addColumn.Font = new System.Drawing.Font("Aharoni", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.addColumn.Location = new System.Drawing.Point(721, 41);
            this.addColumn.Name = "addColumn";
            this.addColumn.Size = new System.Drawing.Size(218, 36);
            this.addColumn.TabIndex = 16;
            this.addColumn.Text = "Add new Column";
            this.addColumn.UseVisualStyleBackColor = false;
            this.addColumn.Click += new System.EventHandler(this.addColumn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Aharoni", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label4.Location = new System.Drawing.Point(21, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(379, 20);
            this.label4.TabIndex = 17;
            this.label4.Text = "The column will be added after column:";
            // 
            // add
            // 
            this.add.BackColor = System.Drawing.Color.White;
            this.add.Font = new System.Drawing.Font("Aharoni", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.add.Location = new System.Drawing.Point(557, 40);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(226, 40);
            this.add.TabIndex = 18;
            this.add.Text = "Add";
            this.add.UseVisualStyleBackColor = false;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // path
            // 
            this.path.Font = new System.Drawing.Font("Aharoni", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.path.Location = new System.Drawing.Point(431, 49);
            this.path.Name = "path";
            this.path.Size = new System.Drawing.Size(508, 31);
            this.path.TabIndex = 20;
            // 
            // load2
            // 
            this.load2.BackColor = System.Drawing.Color.White;
            this.load2.Font = new System.Drawing.Font("Aharoni", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.load2.Location = new System.Drawing.Point(981, 54);
            this.load2.Name = "load2";
            this.load2.Size = new System.Drawing.Size(95, 35);
            this.load2.TabIndex = 21;
            this.load2.Text = "Load";
            this.load2.UseVisualStyleBackColor = false;
            this.load2.Click += new System.EventHandler(this.load2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Aharoni", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(514, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(321, 20);
            this.label5.TabIndex = 22;
            this.label5.Text = "Enter file path with \\\\ in place of \\";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // save2
            // 
            this.save2.BackColor = System.Drawing.Color.White;
            this.save2.Font = new System.Drawing.Font("Aharoni", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.save2.Location = new System.Drawing.Point(1082, 54);
            this.save2.Name = "save2";
            this.save2.Size = new System.Drawing.Size(95, 35);
            this.save2.TabIndex = 23;
            this.save2.Text = "Save";
            this.save2.UseVisualStyleBackColor = false;
            this.save2.Click += new System.EventHandler(this.save2_Click);
            // 
            // rows2
            // 
            this.rows2.Font = new System.Drawing.Font("Aharoni", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.rows2.Location = new System.Drawing.Point(53, 108);
            this.rows2.Name = "rows2";
            this.rows2.Size = new System.Drawing.Size(70, 31);
            this.rows2.TabIndex = 24;
            // 
            // cols2
            // 
            this.cols2.Font = new System.Drawing.Font("Aharoni", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.cols2.Location = new System.Drawing.Point(155, 108);
            this.cols2.Name = "cols2";
            this.cols2.Size = new System.Drawing.Size(69, 31);
            this.cols2.TabIndex = 25;
            // 
            // str2
            // 
            this.str2.Font = new System.Drawing.Font("Aharoni", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.str2.Location = new System.Drawing.Point(265, 108);
            this.str2.Name = "str2";
            this.str2.Size = new System.Drawing.Size(196, 31);
            this.str2.TabIndex = 26;
            // 
            // setCell
            // 
            this.setCell.BackColor = System.Drawing.Color.White;
            this.setCell.Font = new System.Drawing.Font("Aharoni", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.setCell.Location = new System.Drawing.Point(488, 107);
            this.setCell.Name = "setCell";
            this.setCell.Size = new System.Drawing.Size(219, 32);
            this.setCell.TabIndex = 27;
            this.setCell.Text = "Set Cell";
            this.setCell.UseVisualStyleBackColor = false;
            this.setCell.Click += new System.EventHandler(this.setCell_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Aharoni", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label6.Location = new System.Drawing.Point(65, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 20);
            this.label6.TabIndex = 28;
            this.label6.Text = "row";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Aharoni", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(151, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 20);
            this.label7.TabIndex = 29;
            this.label7.Text = "column";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Aharoni", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label8.Location = new System.Drawing.Point(324, 81);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 20);
            this.label8.TabIndex = 30;
            this.label8.Text = "string";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1173, 748);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.setCell);
            this.Controls.Add(this.str2);
            this.Controls.Add(this.cols2);
            this.Controls.Add(this.rows2);
            this.Controls.Add(this.save2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.load2);
            this.Controls.Add(this.path);
            this.Controls.Add(this.add);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.addColumn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.searchForColumn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.searchForRow);
            this.Controls.Add(this.back);
            this.Controls.Add(this.searchForString);
            this.Controls.Add(this.str);
            this.Controls.Add(this.column);
            this.Controls.Add(this.row);
            this.Controls.Add(this.load);
            this.Controls.Add(this.save);
            this.Controls.Add(this.searchInColumn);
            this.Controls.Add(this.searchInRow);
            this.Controls.Add(this.searchString);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button searchString;
        private System.Windows.Forms.Button searchInRow;
        private System.Windows.Forms.Button searchInColumn;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button load;
        private System.Windows.Forms.TextBox row;
        private System.Windows.Forms.TextBox column;
        private System.Windows.Forms.TextBox str;
        private System.Windows.Forms.Button searchForString;
        private System.Windows.Forms.Button back;
        private System.Windows.Forms.Button searchForRow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button searchForColumn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button addColumn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.TextBox path;
        private System.Windows.Forms.Button load2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button save2;
        private System.Windows.Forms.TextBox rows2;
        private System.Windows.Forms.TextBox cols2;
        private System.Windows.Forms.TextBox str2;
        private System.Windows.Forms.Button setCell;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}