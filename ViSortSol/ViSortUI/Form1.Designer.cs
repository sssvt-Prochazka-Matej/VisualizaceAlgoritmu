
namespace ViSortUI
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
            this.initial = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // initial
            // 
            this.initial.Location = new System.Drawing.Point(123, 147);
            this.initial.Name = "initial";
            this.initial.Size = new System.Drawing.Size(135, 70);
            this.initial.TabIndex = 0;
            this.initial.Text = "Start";
            this.initial.UseVisualStyleBackColor = true;
            this.initial.Click += new System.EventHandler(this.initial_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 393);
            this.Controls.Add(this.initial);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button initial;
    }
}

