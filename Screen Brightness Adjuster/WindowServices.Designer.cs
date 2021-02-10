
namespace Screen_Brightness_Adjuster
{
    partial class WindowsServices
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
            this.roundButton1 = new Screen_Brightness_Adjuster.RoundButton();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // roundButton1
            // 
            this.roundButton1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.roundButton1.Location = new System.Drawing.Point(145, 49);
            this.roundButton1.Name = "roundButton1";
            this.roundButton1.Size = new System.Drawing.Size(237, 231);
            this.roundButton1.TabIndex = 2;
            this.roundButton1.Text = "roundButton1";
            this.roundButton1.UseVisualStyleBackColor = false;
            this.roundButton1.Click += new System.EventHandler(this.roundButton1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 23);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // WindowsServices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 388);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.roundButton1);
            this.Name = "WindowsServices";
            this.Text = "Screen Brightness Adjuster";
            this.ResumeLayout(false);

        }

        #endregion
        private RoundButton roundButton1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

