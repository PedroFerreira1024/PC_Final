namespace Ex4
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
            this.ProgressTextBox = new System.Windows.Forms.TextBox();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.WordTextBox = new System.Windows.Forms.TextBox();
            this.ExtensionTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Search = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.ProgressTextBox.Location = new System.Drawing.Point(12, 85);
            this.ProgressTextBox.Multiline = true;
            this.ProgressTextBox.Name = "textBox1";
            this.ProgressTextBox.Size = new System.Drawing.Size(708, 315);
            this.ProgressTextBox.TabIndex = 0;
            // 
            // textBox2
            // 
            this.SearchTextBox.Location = new System.Drawing.Point(196, 59);
            this.SearchTextBox.Name = "textBox2";
            this.SearchTextBox.Size = new System.Drawing.Size(524, 20);
            this.SearchTextBox.TabIndex = 1;
            // 
            // textBox3
            // 
            this.WordTextBox.Location = new System.Drawing.Point(249, 24);
            this.WordTextBox.Name = "textBox3";
            this.WordTextBox.Size = new System.Drawing.Size(170, 20);
            this.WordTextBox.TabIndex = 2;
            // 
            // textBox4
            // 
            this.ExtensionTextBox.Location = new System.Drawing.Point(550, 24);
            this.ExtensionTextBox.Name = "textBox4";
            this.ExtensionTextBox.Size = new System.Drawing.Size(104, 20);
            this.ExtensionTextBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(491, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Extension";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(208, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Word";
            // 
            // button1
            // 
            this.Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Search.Location = new System.Drawing.Point(22, 15);
            this.Search.Name = "button1";
            this.Search.Size = new System.Drawing.Size(151, 37);
            this.Search.TabIndex = 6;
            this.Search.Text = "Search";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_click);
            // 
            // button2
            // 
            this.Cancel.Location = new System.Drawing.Point(57, 56);
            this.Cancel.Name = "button2";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 7;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 411);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ExtensionTextBox);
            this.Controls.Add(this.WordTextBox);
            this.Controls.Add(this.SearchTextBox);
            this.Controls.Add(this.ProgressTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ProgressTextBox;
        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.TextBox WordTextBox;
        private System.Windows.Forms.TextBox ExtensionTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Search;
        private System.Windows.Forms.Button Cancel;
    }
}

