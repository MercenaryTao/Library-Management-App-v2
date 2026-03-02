namespace Library_Management_App_v2
{
    partial class Borrow
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.Returnbtn = new System.Windows.Forms.Button();
            this.BorrowBtn = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.bookDgv = new System.Windows.Forms.DataGridView();
            this.srchParam = new System.Windows.Forms.RichTextBox();
            this.srchCombo = new System.Windows.Forms.ComboBox();
            this.searchBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.Silver;
            this.splitContainer1.Panel1.BackgroundImage = global::Library_Management_App_v2.Properties.Resources.BookImages;
            this.splitContainer1.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.splitContainer1.Panel1.Controls.Add(this.srchParam);
            this.splitContainer1.Panel1.Controls.Add(this.srchCombo);
            this.splitContainer1.Panel1.Controls.Add(this.searchBtn);
            this.splitContainer1.Panel1.Controls.Add(this.Returnbtn);
            this.splitContainer1.Panel1.Controls.Add(this.BorrowBtn);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.Black;
            this.splitContainer1.Panel2.BackgroundImage = global::Library_Management_App_v2.Properties.Resources._27d9f760978c30b9118665485f8f82b5;
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView2);
            this.splitContainer1.Panel2.Controls.Add(this.bookDgv);
            this.splitContainer1.Size = new System.Drawing.Size(1104, 652);
            this.splitContainer1.SplitterDistance = 367;
            this.splitContainer1.TabIndex = 0;
            // 
            // Returnbtn
            // 
            this.Returnbtn.BackColor = System.Drawing.Color.Sienna;
            this.Returnbtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Returnbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Returnbtn.Location = new System.Drawing.Point(190, 483);
            this.Returnbtn.Name = "Returnbtn";
            this.Returnbtn.Size = new System.Drawing.Size(174, 77);
            this.Returnbtn.TabIndex = 1;
            this.Returnbtn.Text = "Return Book";
            this.Returnbtn.UseVisualStyleBackColor = false;
            // 
            // BorrowBtn
            // 
            this.BorrowBtn.BackColor = System.Drawing.Color.Sienna;
            this.BorrowBtn.Location = new System.Drawing.Point(12, 483);
            this.BorrowBtn.Name = "BorrowBtn";
            this.BorrowBtn.Size = new System.Drawing.Size(174, 77);
            this.BorrowBtn.TabIndex = 0;
            this.BorrowBtn.Text = "Borrow Book";
            this.BorrowBtn.UseVisualStyleBackColor = false;
            // 
            // dataGridView2
            // 
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(3, 362);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(727, 287);
            this.dataGridView2.TabIndex = 1;
            // 
            // bookDgv
            // 
            this.bookDgv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bookDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.bookDgv.Location = new System.Drawing.Point(3, 38);
            this.bookDgv.Name = "bookDgv";
            this.bookDgv.Size = new System.Drawing.Size(727, 318);
            this.bookDgv.TabIndex = 0;
            // 
            // srchParam
            // 
            this.srchParam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.srchParam.Location = new System.Drawing.Point(12, 89);
            this.srchParam.Name = "srchParam";
            this.srchParam.Size = new System.Drawing.Size(303, 46);
            this.srchParam.TabIndex = 7;
            this.srchParam.Text = "";
            // 
            // srchCombo
            // 
            this.srchCombo.FormattingEnabled = true;
            this.srchCombo.Items.AddRange(new object[] {
            "Book ID",
            "Title",
            "Author",
            "Genre"});
            this.srchCombo.Location = new System.Drawing.Point(12, 38);
            this.srchCombo.Name = "srchCombo";
            this.srchCombo.Size = new System.Drawing.Size(121, 21);
            this.srchCombo.TabIndex = 6;
            this.srchCombo.Text = "Search By:";
            // 
            // searchBtn
            // 
            this.searchBtn.Location = new System.Drawing.Point(12, 219);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(117, 50);
            this.searchBtn.TabIndex = 5;
            this.searchBtn.Text = "Search";
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // Borrow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Library_Management_App_v2.Properties.Resources._27d9f760978c30b9118665485f8f82b5;
            this.ClientSize = new System.Drawing.Size(1104, 652);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
            this.MaximizeBox = false;
            this.Name = "Borrow";
            this.Text = "Borrow To Member";
            this.TransparencyKey = System.Drawing.Color.DimGray;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Borrow_FormClosed);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookDgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button Returnbtn;
        private System.Windows.Forms.Button BorrowBtn;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridView bookDgv;
        private System.Windows.Forms.RichTextBox srchParam;
        private System.Windows.Forms.ComboBox srchCombo;
        private System.Windows.Forms.Button searchBtn;
    }
}