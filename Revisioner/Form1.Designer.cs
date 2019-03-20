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
            this.lblDocNameWithType = new System.Windows.Forms.Label();
            this.cmdUpdate = new System.Windows.Forms.Button();
            this.lblPath = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblDocName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblIsDrawing = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDirectory = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblPathDocument = new System.Windows.Forms.Label();
            this.cmdRevisionize = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lblHasRevision = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblNextRevision = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblDocNameWithType
            // 
            this.lblDocNameWithType.AutoSize = true;
            this.lblDocNameWithType.Location = new System.Drawing.Point(186, 9);
            this.lblDocNameWithType.Name = "lblDocNameWithType";
            this.lblDocNameWithType.Size = new System.Drawing.Size(46, 17);
            this.lblDocNameWithType.TabIndex = 0;
            this.lblDocNameWithType.Text = "label1";
            this.lblDocNameWithType.Visible = false;
            // 
            // cmdUpdate
            // 
            this.cmdUpdate.Location = new System.Drawing.Point(82, 283);
            this.cmdUpdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdUpdate.Name = "cmdUpdate";
            this.cmdUpdate.Size = new System.Drawing.Size(227, 57);
            this.cmdUpdate.TabIndex = 1;
            this.cmdUpdate.Text = "Aktualisieren";
            this.cmdUpdate.UseVisualStyleBackColor = true;
            this.cmdUpdate.Click += new System.EventHandler(this.cmdUpdate_Click);
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(186, 77);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(46, 17);
            this.lblPath.TabIndex = 2;
            this.lblPath.Text = "label2";
            this.lblPath.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Dateiname mit Endung";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Pfad";
            // 
            // lblDocName
            // 
            this.lblDocName.AutoSize = true;
            this.lblDocName.Location = new System.Drawing.Point(186, 43);
            this.lblDocName.Name = "lblDocName";
            this.lblDocName.Size = new System.Drawing.Size(46, 17);
            this.lblDocName.TabIndex = 5;
            this.lblDocName.Text = "label5";
            this.lblDocName.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Dateiname";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 179);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(155, 17);
            this.label9.TabIndex = 7;
            this.label9.Text = "Zeichnung vorhanden?";
            // 
            // lblIsDrawing
            // 
            this.lblIsDrawing.AutoSize = true;
            this.lblIsDrawing.Location = new System.Drawing.Point(188, 179);
            this.lblIsDrawing.Name = "lblIsDrawing";
            this.lblIsDrawing.Size = new System.Drawing.Size(46, 17);
            this.lblIsDrawing.TabIndex = 8;
            this.lblIsDrawing.Text = "label5";
            this.lblIsDrawing.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Verzeichnis";
            // 
            // lblDirectory
            // 
            this.lblDirectory.AutoSize = true;
            this.lblDirectory.Location = new System.Drawing.Point(188, 111);
            this.lblDirectory.Name = "lblDirectory";
            this.lblDirectory.Size = new System.Drawing.Size(46, 17);
            this.lblDirectory.TabIndex = 10;
            this.lblDirectory.Text = "label6";
            this.lblDirectory.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 145);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Pfad und Dateiname";
            // 
            // lblPathDocument
            // 
            this.lblPathDocument.AutoSize = true;
            this.lblPathDocument.Location = new System.Drawing.Point(186, 145);
            this.lblPathDocument.Name = "lblPathDocument";
            this.lblPathDocument.Size = new System.Drawing.Size(46, 17);
            this.lblPathDocument.TabIndex = 12;
            this.lblPathDocument.Text = "label7";
            this.lblPathDocument.Visible = false;
            // 
            // cmdRevisionize
            // 
            this.cmdRevisionize.Location = new System.Drawing.Point(406, 283);
            this.cmdRevisionize.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdRevisionize.Name = "cmdRevisionize";
            this.cmdRevisionize.Size = new System.Drawing.Size(227, 57);
            this.cmdRevisionize.TabIndex = 13;
            this.cmdRevisionize.Text = "Revisionier!";
            this.cmdRevisionize.UseVisualStyleBackColor = true;
            this.cmdRevisionize.Click += new System.EventHandler(this.cmdRevisionize_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 213);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "Revision?";
            // 
            // lblHasRevision
            // 
            this.lblHasRevision.AutoSize = true;
            this.lblHasRevision.Location = new System.Drawing.Point(186, 213);
            this.lblHasRevision.Name = "lblHasRevision";
            this.lblHasRevision.Size = new System.Drawing.Size(46, 17);
            this.lblHasRevision.TabIndex = 15;
            this.lblHasRevision.Text = "label7";
            this.lblHasRevision.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 247);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 17);
            this.label7.TabIndex = 16;
            this.label7.Text = "Nächste Revision";
            // 
            // lblNextRevision
            // 
            this.lblNextRevision.AutoSize = true;
            this.lblNextRevision.Location = new System.Drawing.Point(186, 247);
            this.lblNextRevision.Name = "lblNextRevision";
            this.lblNextRevision.Size = new System.Drawing.Size(46, 17);
            this.lblNextRevision.TabIndex = 17;
            this.lblNextRevision.Text = "label8";
            this.lblNextRevision.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 368);
            this.Controls.Add(this.lblNextRevision);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblHasRevision);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmdRevisionize);
            this.Controls.Add(this.lblPathDocument);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblDirectory);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblIsDrawing);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblDocName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.cmdUpdate);
            this.Controls.Add(this.lblDocNameWithType);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDocNameWithType;
        private System.Windows.Forms.Button cmdUpdate;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblDocName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblIsDrawing;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblDirectory;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblPathDocument;
        private System.Windows.Forms.Button cmdRevisionize;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblHasRevision;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblNextRevision;
    }
}

