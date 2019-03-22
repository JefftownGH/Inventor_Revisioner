namespace Revisioner
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
            this.lblPath = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblIsDrawing = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblHasRevision = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblNextRevision = new System.Windows.Forms.Label();
            this.cmdRevisionize = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(186, 9);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(46, 17);
            this.lblPath.TabIndex = 2;
            this.lblPath.Text = "label2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Pfad";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(155, 17);
            this.label9.TabIndex = 7;
            this.label9.Text = "Zeichnung vorhanden?";
            // 
            // lblIsDrawing
            // 
            this.lblIsDrawing.AutoSize = true;
            this.lblIsDrawing.Location = new System.Drawing.Point(186, 49);
            this.lblIsDrawing.Name = "lblIsDrawing";
            this.lblIsDrawing.Size = new System.Drawing.Size(46, 17);
            this.lblIsDrawing.TabIndex = 8;
            this.lblIsDrawing.Text = "label5";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "Revision?";
            // 
            // lblHasRevision
            // 
            this.lblHasRevision.AutoSize = true;
            this.lblHasRevision.Location = new System.Drawing.Point(186, 89);
            this.lblHasRevision.Name = "lblHasRevision";
            this.lblHasRevision.Size = new System.Drawing.Size(46, 17);
            this.lblHasRevision.TabIndex = 15;
            this.lblHasRevision.Text = "label7";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 129);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 17);
            this.label7.TabIndex = 16;
            this.label7.Text = "Nächste Revision";
            // 
            // lblNextRevision
            // 
            this.lblNextRevision.AutoSize = true;
            this.lblNextRevision.Location = new System.Drawing.Point(186, 129);
            this.lblNextRevision.Name = "lblNextRevision";
            this.lblNextRevision.Size = new System.Drawing.Size(46, 17);
            this.lblNextRevision.TabIndex = 17;
            this.lblNextRevision.Text = "label8";
            // 
            // cmdRevisionize
            // 
            this.cmdRevisionize.Location = new System.Drawing.Point(20, 162);
            this.cmdRevisionize.Name = "cmdRevisionize";
            this.cmdRevisionize.Size = new System.Drawing.Size(323, 57);
            this.cmdRevisionize.TabIndex = 19;
            this.cmdRevisionize.Text = "Revisionier Baugruppe / Bauteil";
            this.cmdRevisionize.UseVisualStyleBackColor = true;
            this.cmdRevisionize.Click += new System.EventHandler(this.cmdRevisionize_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 241);
            this.Controls.Add(this.cmdRevisionize);
            this.Controls.Add(this.lblNextRevision);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblHasRevision);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblIsDrawing);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblPath);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Inventor Revisioner";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblIsDrawing;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblHasRevision;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblNextRevision;
        private System.Windows.Forms.Button cmdRevisionize;
    }
}

