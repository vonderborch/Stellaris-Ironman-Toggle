namespace Toggler
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.select_btn = new System.Windows.Forms.Button();
            this.toggle_btn = new System.Windows.Forms.Button();
            this.file_txt = new System.Windows.Forms.TextBox();
            this.status_txt = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // select_btn
            // 
            this.select_btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.select_btn.Location = new System.Drawing.Point(0, 23);
            this.select_btn.Name = "select_btn";
            this.select_btn.Size = new System.Drawing.Size(712, 23);
            this.select_btn.TabIndex = 0;
            this.select_btn.Text = "Select File";
            this.select_btn.UseVisualStyleBackColor = true;
            this.select_btn.Click += new System.EventHandler(this.select_btn_Click);
            // 
            // toggle_btn
            // 
            this.toggle_btn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toggle_btn.Location = new System.Drawing.Point(0, 47);
            this.toggle_btn.Name = "toggle_btn";
            this.toggle_btn.Size = new System.Drawing.Size(712, 23);
            this.toggle_btn.TabIndex = 1;
            this.toggle_btn.Text = "Toggle Ironman";
            this.toggle_btn.UseVisualStyleBackColor = true;
            this.toggle_btn.Click += new System.EventHandler(this.toggle_btn_Click);
            // 
            // file_txt
            // 
            this.file_txt.Dock = System.Windows.Forms.DockStyle.Top;
            this.file_txt.Location = new System.Drawing.Point(0, 0);
            this.file_txt.Name = "file_txt";
            this.file_txt.ReadOnly = true;
            this.file_txt.Size = new System.Drawing.Size(712, 23);
            this.file_txt.TabIndex = 2;
            this.file_txt.Text = "Please Select a File";
            // 
            // status_txt
            // 
            this.status_txt.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.status_txt.Location = new System.Drawing.Point(0, 70);
            this.status_txt.Name = "status_txt";
            this.status_txt.ReadOnly = true;
            this.status_txt.Size = new System.Drawing.Size(712, 23);
            this.status_txt.TabIndex = 3;
            this.status_txt.Text = "Please Select a File";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.select_btn);
            this.panel1.Controls.Add(this.toggle_btn);
            this.panel1.Controls.Add(this.status_txt);
            this.panel1.Controls.Add(this.file_txt);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(712, 93);
            this.panel1.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 93);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Stellaris Ironman Save Toggler";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Button select_btn;
        private Button toggle_btn;
        private TextBox file_txt;
        private TextBox status_txt;
        private Panel panel1;
    }
}