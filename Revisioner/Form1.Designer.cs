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
            this.docNameWithType = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.path = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.docName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.isDrawing = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.directory = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pathDocument = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // docNameWithType
            // 
            this.docNameWithType.AutoSize = true;
            this.docNameWithType.Location = new System.Drawing.Point(217, 53);
            this.docNameWithType.Name = "docNameWithType";
            this.docNameWithType.Size = new System.Drawing.Size(46, 17);
            this.docNameWithType.TabIndex = 0;
            this.docNameWithType.Text = "label1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(474, 248);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(229, 56);
            this.button1.TabIndex = 1;
            this.button1.Text = "Aktualisieren";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // path
            // 
            this.path.AutoSize = true;
            this.path.Location = new System.Drawing.Point(217, 119);
            this.path.Name = "path";
            this.path.Size = new System.Drawing.Size(46, 17);
            this.path.TabIndex = 2;
            this.path.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Dateiname mit Endung";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Pfad";
            // 
            // docName
            // 
            this.docName.AutoSize = true;
            this.docName.Location = new System.Drawing.Point(217, 83);
            this.docName.Name = "docName";
            this.docName.Size = new System.Drawing.Size(46, 17);
            this.docName.TabIndex = 5;
            this.docName.Text = "label5";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Dateiname";
            // 
            // isDrawing
            // 
            this.isDrawing.AutoSize = true;
            this.isDrawing.Location = new System.Drawing.Point(42, 210);
            this.isDrawing.Name = "isDrawing";
            this.isDrawing.Size = new System.Drawing.Size(155, 17);
            this.isDrawing.TabIndex = 7;
            this.isDrawing.Text = "Zeichnung vorhanden?";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(219, 209);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "label5";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Verzeichnis";
            // 
            // directory
            // 
            this.directory.AutoSize = true;
            this.directory.Location = new System.Drawing.Point(218, 151);
            this.directory.Name = "directory";
            this.directory.Size = new System.Drawing.Size(46, 17);
            this.directory.TabIndex = 10;
            this.directory.Text = "label6";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(44, 182);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Pfad und Dateiname";
            // 
            // pathDocument
            // 
            this.pathDocument.AutoSize = true;
            this.pathDocument.Location = new System.Drawing.Point(217, 182);
            this.pathDocument.Name = "pathDocument";
            this.pathDocument.Size = new System.Drawing.Size(46, 17);
            this.pathDocument.TabIndex = 12;
            this.pathDocument.Text = "label7";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 316);
            this.Controls.Add(this.pathDocument);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.directory);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.isDrawing);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.docName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.path);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.docNameWithType);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label docNameWithType;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label path;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label docName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label isDrawing;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label directory;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label pathDocument;
    }
}

