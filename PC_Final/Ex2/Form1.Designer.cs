namespace Ex2
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
            this.Register = new System.Windows.Forms.Button();
            this.showResultBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.UnRegister = new System.Windows.Forms.Button();
            this.ListFiles = new System.Windows.Forms.Button();
            this.ListLocation = new System.Windows.Forms.Button();
            this.regTextBox = new System.Windows.Forms.TextBox();
            this.unRegTextBox = new System.Windows.Forms.TextBox();
            this.locationToList = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Register
            // 
            this.Register.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Register.Location = new System.Drawing.Point(32, 56);
            this.Register.Name = "Register";
            this.Register.Size = new System.Drawing.Size(116, 42);
            this.Register.TabIndex = 0;
            this.Register.Text = "Register";
            this.Register.UseVisualStyleBackColor = true;
            this.Register.Click += new System.EventHandler(this.Register_Click);
            // 
            // showResultBox
            // 
            this.showResultBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showResultBox.Location = new System.Drawing.Point(194, 39);
            this.showResultBox.Multiline = true;
            this.showResultBox.Name = "showResultBox";
            this.showResultBox.ReadOnly = true;
            this.showResultBox.Size = new System.Drawing.Size(261, 410);
            this.showResultBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(241, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Show result";
            // 
            // UnRegister
            // 
            this.UnRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UnRegister.Location = new System.Drawing.Point(32, 138);
            this.UnRegister.Name = "UnRegister";
            this.UnRegister.Size = new System.Drawing.Size(116, 42);
            this.UnRegister.TabIndex = 3;
            this.UnRegister.Text = "UnRegister";
            this.UnRegister.UseVisualStyleBackColor = true;
            this.UnRegister.Click += new System.EventHandler(this.UnRegister_Click);
            // 
            // ListFiles
            // 
            this.ListFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListFiles.Location = new System.Drawing.Point(32, 186);
            this.ListFiles.Name = "ListFiles";
            this.ListFiles.Size = new System.Drawing.Size(116, 42);
            this.ListFiles.TabIndex = 4;
            this.ListFiles.Text = "ListFiles";
            this.ListFiles.UseVisualStyleBackColor = true;
            this.ListFiles.Click += new System.EventHandler(this.ListFiles_Click);
            // 
            // ListLocation
            // 
            this.ListLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListLocation.Location = new System.Drawing.Point(32, 273);
            this.ListLocation.Name = "ListLocation";
            this.ListLocation.Size = new System.Drawing.Size(116, 42);
            this.ListLocation.TabIndex = 5;
            this.ListLocation.Text = "ListLocation";
            this.ListLocation.UseVisualStyleBackColor = true;
            this.ListLocation.Click += new System.EventHandler(this.ListLocation_Click);
            // 
            // regTextBox
            // 
            this.regTextBox.Location = new System.Drawing.Point(32, 30);
            this.regTextBox.Name = "regTextBox";
            this.regTextBox.Size = new System.Drawing.Size(116, 20);
            this.regTextBox.TabIndex = 6;
            // 
            // unRegTextBox
            // 
            this.unRegTextBox.Location = new System.Drawing.Point(32, 112);
            this.unRegTextBox.Name = "unRegTextBox";
            this.unRegTextBox.Size = new System.Drawing.Size(116, 20);
            this.unRegTextBox.TabIndex = 7;
            // 
            // locationToList
            // 
            this.locationToList.Location = new System.Drawing.Point(32, 243);
            this.locationToList.Name = "locationToList";
            this.locationToList.Size = new System.Drawing.Size(116, 20);
            this.locationToList.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 461);
            this.Controls.Add(this.locationToList);
            this.Controls.Add(this.unRegTextBox);
            this.Controls.Add(this.regTextBox);
            this.Controls.Add(this.ListLocation);
            this.Controls.Add(this.ListFiles);
            this.Controls.Add(this.UnRegister);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.showResultBox);
            this.Controls.Add(this.Register);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Register;
        private System.Windows.Forms.TextBox showResultBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button UnRegister;
        private System.Windows.Forms.Button ListFiles;
        private System.Windows.Forms.Button ListLocation;
        private System.Windows.Forms.TextBox regTextBox;
        private System.Windows.Forms.TextBox unRegTextBox;
        private System.Windows.Forms.TextBox locationToList;
    }
}

