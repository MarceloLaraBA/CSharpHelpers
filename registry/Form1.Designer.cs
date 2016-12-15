namespace registry
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
            this.ConfigValue = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnRead = new System.Windows.Forms.Button();
            this.enumItems = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.ConfigValue.Location = new System.Drawing.Point(22, 56);
            this.ConfigValue.Name = "textBox1";
            this.ConfigValue.Size = new System.Drawing.Size(198, 20);
            this.ConfigValue.TabIndex = 1;
            // 
            // button2
            // 
            this.btnSave.Location = new System.Drawing.Point(145, 82);
            this.btnSave.Name = "button2";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.save);
            // 
            // button1
            // 
            this.btnRead.Location = new System.Drawing.Point(22, 82);
            this.btnRead.Name = "button1";
            this.btnRead.Size = new System.Drawing.Size(75, 23);
            this.btnRead.TabIndex = 2;
            this.btnRead.Text = "read";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.readKey);
            // 
            // enumItems
            // 
            this.enumItems.FormattingEnabled = true;
            this.enumItems.Location = new System.Drawing.Point(22, 29);
            this.enumItems.Name = "enumItems";
            this.enumItems.Size = new System.Drawing.Size(198, 21);
            this.enumItems.TabIndex = 4;
            this.enumItems.SelectedIndexChanged += new System.EventHandler(this.enumItems_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(245, 121);
            this.Controls.Add(this.enumItems);
            this.Controls.Add(this.btnRead);
            this.Controls.Add(this.ConfigValue);
            this.Controls.Add(this.btnSave);
            this.Name = "Form1";
            this.Text = "RegistryConfiguration";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox ConfigValue;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.ComboBox enumItems;
    }
}

