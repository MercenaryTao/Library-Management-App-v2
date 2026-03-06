namespace Library_Management_App_v2
{
    partial class AddMember
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddMember));
            this.fNameBx = new System.Windows.Forms.RichTextBox();
            this.lNameBx = new System.Windows.Forms.RichTextBox();
            this.emailBx = new System.Windows.Forms.RichTextBox();
            this.addBtn = new System.Windows.Forms.Button();
            this.memberView = new System.Windows.Forms.DataGridView();
            this.dltBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.memberView)).BeginInit();
            this.SuspendLayout();
            // 
            // fNameBx
            // 
            this.fNameBx.Location = new System.Drawing.Point(112, 45);
            this.fNameBx.Name = "fNameBx";
            this.fNameBx.Size = new System.Drawing.Size(133, 41);
            this.fNameBx.TabIndex = 0;
            this.fNameBx.Text = "";
            // 
            // lNameBx
            // 
            this.lNameBx.Location = new System.Drawing.Point(112, 120);
            this.lNameBx.Name = "lNameBx";
            this.lNameBx.Size = new System.Drawing.Size(133, 41);
            this.lNameBx.TabIndex = 1;
            this.lNameBx.Text = "";
            // 
            // emailBx
            // 
            this.emailBx.Location = new System.Drawing.Point(112, 195);
            this.emailBx.Name = "emailBx";
            this.emailBx.Size = new System.Drawing.Size(133, 41);
            this.emailBx.TabIndex = 3;
            this.emailBx.Text = "";
            // 
            // addBtn
            // 
            this.addBtn.BackColor = System.Drawing.Color.Sienna;
            this.addBtn.Location = new System.Drawing.Point(12, 321);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(92, 42);
            this.addBtn.TabIndex = 4;
            this.addBtn.Text = "Add";
            this.addBtn.UseVisualStyleBackColor = false;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // memberView
            // 
            this.memberView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.memberView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.memberView.Location = new System.Drawing.Point(269, 45);
            this.memberView.Name = "memberView";
            this.memberView.Size = new System.Drawing.Size(474, 318);
            this.memberView.TabIndex = 5;
            // 
            // dltBtn
            // 
            this.dltBtn.BackColor = System.Drawing.Color.Sienna;
            this.dltBtn.Location = new System.Drawing.Point(129, 321);
            this.dltBtn.Name = "dltBtn";
            this.dltBtn.Size = new System.Drawing.Size(92, 42);
            this.dltBtn.TabIndex = 6;
            this.dltBtn.Text = "Delete";
            this.dltBtn.UseVisualStyleBackColor = false;
            this.dltBtn.Click += new System.EventHandler(this.dltBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(12, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(9, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Surname";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(12, 198);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Email";
            // 
            // AddMember
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Library_Management_App_v2.Properties.Resources.BookImages;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dltBtn);
            this.Controls.Add(this.memberView);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.emailBx);
            this.Controls.Add(this.lNameBx);
            this.Controls.Add(this.fNameBx);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AddMember";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddMember";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AddMember_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.memberView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox fNameBx;
        private System.Windows.Forms.RichTextBox lNameBx;
        private System.Windows.Forms.RichTextBox emailBx;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.DataGridView memberView;
        private System.Windows.Forms.Button dltBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}