
namespace ViSortGDI
{
    partial class ViForm
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
            this.panelBubble = new System.Windows.Forms.Panel();
            this.lblBubble = new System.Windows.Forms.Label();
            this.lblCompleteBubble = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnCancle = new System.Windows.Forms.Button();
            this.panelQuick = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCompleteQuick = new System.Windows.Forms.Label();
            this.backgroundWrkrQuick = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // panelBubble
            // 
            this.panelBubble.Location = new System.Drawing.Point(48, 27);
            this.panelBubble.Name = "panelBubble";
            this.panelBubble.Size = new System.Drawing.Size(400, 140);
            this.panelBubble.TabIndex = 0;
            // 
            // lblBubble
            // 
            this.lblBubble.AutoSize = true;
            this.lblBubble.Location = new System.Drawing.Point(45, 9);
            this.lblBubble.Name = "lblBubble";
            this.lblBubble.Size = new System.Drawing.Size(65, 15);
            this.lblBubble.TabIndex = 0;
            this.lblBubble.Text = "BubbleSort";
            // 
            // lblCompleteBubble
            // 
            this.lblCompleteBubble.AutoSize = true;
            this.lblCompleteBubble.Location = new System.Drawing.Point(381, 9);
            this.lblCompleteBubble.Name = "lblCompleteBubble";
            this.lblCompleteBubble.Size = new System.Drawing.Size(0, 15);
            this.lblCompleteBubble.TabIndex = 1;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(45, 382);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(91, 39);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start Sorting";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.Location = new System.Drawing.Point(357, 382);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(91, 39);
            this.btnCancle.TabIndex = 3;
            this.btnCancle.Text = "Cancel";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // panelQuick
            // 
            this.panelQuick.Location = new System.Drawing.Point(48, 225);
            this.panelQuick.Name = "panelQuick";
            this.panelQuick.Size = new System.Drawing.Size(400, 140);
            this.panelQuick.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 193);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "QuickSort";
            // 
            // lblCompleteQuick
            // 
            this.lblCompleteQuick.AutoSize = true;
            this.lblCompleteQuick.Location = new System.Drawing.Point(381, 193);
            this.lblCompleteQuick.Name = "lblCompleteQuick";
            this.lblCompleteQuick.Size = new System.Drawing.Size(0, 15);
            this.lblCompleteQuick.TabIndex = 6;
            // 
            // backgroundWrkrQuick
            // 
            this.backgroundWrkrQuick.WorkerReportsProgress = true;
            this.backgroundWrkrQuick.WorkerSupportsCancellation = true;
            this.backgroundWrkrQuick.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWrkrQuick_DoWork);
            this.backgroundWrkrQuick.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWrkrQuick_ProgressChanged);
            this.backgroundWrkrQuick.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWrkrQuick_RunWorkerCompleted);
            // 
            // ViForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblCompleteQuick);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelQuick);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblCompleteBubble);
            this.Controls.Add(this.lblBubble);
            this.Controls.Add(this.panelBubble);
            this.Name = "ViForm";
            this.Text = "ViForm";
            this.Load += new System.EventHandler(this.ViForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelBubble;
        private System.Windows.Forms.Label lblBubble;
        private System.Windows.Forms.Label lblCompleteBubble;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.Panel panelQuick;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCompleteQuick;
        private System.ComponentModel.BackgroundWorker backgroundWrkrQuick;
    }
}

