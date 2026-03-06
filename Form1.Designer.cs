namespace Library_Management_App_v2
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numDial = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.isbnBx = new System.Windows.Forms.RichTextBox();
            this.addBtn = new System.Windows.Forms.Button();
            this.genreCombo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.authorBx = new System.Windows.Forms.RichTextBox();
            this.descrBx = new System.Windows.Forms.RichTextBox();
            this.titleBx = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.srchCombo1 = new System.Windows.Forms.ComboBox();
            this.srchParam = new System.Windows.Forms.RichTextBox();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.searchBtn1 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.borrowMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewMemberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataDisplay = new System.Windows.Forms.DataGridView();
            this.updateBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDial)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox1.Controls.Add(this.updateBtn);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.numDial);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.isbnBx);
            this.groupBox1.Controls.Add(this.addBtn);
            this.groupBox1.Controls.Add(this.genreCombo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.authorBx);
            this.groupBox1.Controls.Add(this.descrBx);
            this.groupBox1.Controls.Add(this.titleBx);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(462, 349);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add Books";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(10, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Hardcopies";
            // 
            // numDial
            // 
            this.numDial.Location = new System.Drawing.Point(87, 127);
            this.numDial.Name = "numDial";
            this.numDial.Size = new System.Drawing.Size(45, 20);
            this.numDial.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(260, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "ISBN";
            // 
            // isbnBx
            // 
            this.isbnBx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.isbnBx.Location = new System.Drawing.Point(263, 80);
            this.isbnBx.Name = "isbnBx";
            this.isbnBx.Size = new System.Drawing.Size(180, 35);
            this.isbnBx.TabIndex = 9;
            this.isbnBx.Text = "";
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(62, 285);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(117, 50);
            this.addBtn.TabIndex = 8;
            this.addBtn.Text = "Add";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // genreCombo
            // 
            this.genreCombo.FormattingEnabled = true;
            this.genreCombo.Location = new System.Drawing.Point(304, 36);
            this.genreCombo.Name = "genreCombo";
            this.genreCombo.Size = new System.Drawing.Size(121, 21);
            this.genreCombo.TabIndex = 7;
            this.genreCombo.Text = "Select Genre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Description";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Author";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Title";
            // 
            // authorBx
            // 
            this.authorBx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.authorBx.Location = new System.Drawing.Point(62, 80);
            this.authorBx.Name = "authorBx";
            this.authorBx.Size = new System.Drawing.Size(180, 35);
            this.authorBx.TabIndex = 3;
            this.authorBx.Text = "";
            // 
            // descrBx
            // 
            this.descrBx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.descrBx.Location = new System.Drawing.Point(13, 186);
            this.descrBx.Name = "descrBx";
            this.descrBx.Size = new System.Drawing.Size(353, 79);
            this.descrBx.TabIndex = 2;
            this.descrBx.Text = "";
            // 
            // titleBx
            // 
            this.titleBx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.titleBx.Location = new System.Drawing.Point(62, 33);
            this.titleBx.Name = "titleBx";
            this.titleBx.Size = new System.Drawing.Size(180, 35);
            this.titleBx.TabIndex = 1;
            this.titleBx.Text = "";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.srchCombo1);
            this.groupBox2.Controls.Add(this.srchParam);
            this.groupBox2.Controls.Add(this.deleteBtn);
            this.groupBox2.Controls.Add(this.searchBtn1);
            this.groupBox2.Location = new System.Drawing.Point(653, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(462, 349);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search And Delete";
            // 
            // srchCombo1
            // 
            this.srchCombo1.FormattingEnabled = true;
            this.srchCombo1.Items.AddRange(new object[] {
            "Book ID",
            "Title",
            "Author",
            "Genre"});
            this.srchCombo1.Location = new System.Drawing.Point(22, 36);
            this.srchCombo1.Name = "srchCombo1";
            this.srchCombo1.Size = new System.Drawing.Size(121, 21);
            this.srchCombo1.TabIndex = 7;
            this.srchCombo1.Text = "Search By:";
            // 
            // srchParam
            // 
            this.srchParam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.srchParam.Location = new System.Drawing.Point(22, 101);
            this.srchParam.Name = "srchParam";
            this.srchParam.Size = new System.Drawing.Size(303, 46);
            this.srchParam.TabIndex = 4;
            this.srchParam.Text = "";
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(208, 231);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(117, 50);
            this.deleteBtn.TabIndex = 2;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // searchBtn1
            // 
            this.searchBtn1.Location = new System.Drawing.Point(22, 231);
            this.searchBtn1.Name = "searchBtn1";
            this.searchBtn1.Size = new System.Drawing.Size(117, 50);
            this.searchBtn1.TabIndex = 1;
            this.searchBtn1.Text = "Search";
            this.searchBtn1.UseVisualStyleBackColor = true;
            this.searchBtn1.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.borrowMenu,
            this.addNewMemberToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1143, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // borrowMenu
            // 
            this.borrowMenu.BackColor = System.Drawing.Color.Transparent;
            this.borrowMenu.BackgroundImage = global::Library_Management_App_v2.Properties.Resources._27d9f760978c30b9118665485f8f82b5;
            this.borrowMenu.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.borrowMenu.Name = "borrowMenu";
            this.borrowMenu.Size = new System.Drawing.Size(107, 20);
            this.borrowMenu.Text = "Lend to Member";
            this.borrowMenu.Click += new System.EventHandler(this.borrowMenu_Click);
            // 
            // addNewMemberToolStripMenuItem
            // 
            this.addNewMemberToolStripMenuItem.BackgroundImage = global::Library_Management_App_v2.Properties.Resources._27d9f760978c30b9118665485f8f82b5;
            this.addNewMemberToolStripMenuItem.Name = "addNewMemberToolStripMenuItem";
            this.addNewMemberToolStripMenuItem.Size = new System.Drawing.Size(116, 20);
            this.addNewMemberToolStripMenuItem.Text = "Add New Member";
            this.addNewMemberToolStripMenuItem.Click += new System.EventHandler(this.addNewMemberToolStripMenuItem_Click);
            // 
            // dataDisplay
            // 
            this.dataDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataDisplay.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataDisplay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataDisplay.Location = new System.Drawing.Point(103, 447);
            this.dataDisplay.MultiSelect = false;
            this.dataDisplay.Name = "dataDisplay";
            this.dataDisplay.ReadOnly = true;
            this.dataDisplay.Size = new System.Drawing.Size(884, 32);
            this.dataDisplay.TabIndex = 4;
            this.dataDisplay.TabStop = false;
            this.dataDisplay.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataDisplay_DataBindingComplete);
            // 
            // updateBtn
            // 
            this.updateBtn.Location = new System.Drawing.Point(221, 285);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(117, 50);
            this.updateBtn.TabIndex = 13;
            this.updateBtn.Text = "Update";
            this.updateBtn.UseVisualStyleBackColor = true;
            this.updateBtn.Click += new System.EventHandler(this.updateBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BackgroundImage = global::Library_Management_App_v2.Properties.Resources._27d9f760978c30b9118665485f8f82b5;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1143, 602);
            this.Controls.Add(this.dataDisplay);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Library Management v2";
            this.TransparencyKey = System.Drawing.Color.Silver;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDial)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataDisplay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button searchBtn1;
        private System.Windows.Forms.RichTextBox authorBx;
        private System.Windows.Forms.RichTextBox descrBx;
        private System.Windows.Forms.RichTextBox titleBx;
        private System.Windows.Forms.RichTextBox srchParam;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox genreCombo;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox isbnBx;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem borrowMenu;
        private System.Windows.Forms.ToolStripMenuItem addNewMemberToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataDisplay;
        private System.Windows.Forms.ComboBox srchCombo1;
        private System.Windows.Forms.NumericUpDown numDial;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button updateBtn;
    }
}

