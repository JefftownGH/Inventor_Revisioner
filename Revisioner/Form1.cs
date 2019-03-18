using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Inventor;
using File = System.IO.File;


namespace Revisioner
{
    public partial class Form1 : Form
    {
        Inventor.Application _invApp;
        bool _started = false;
        private string fullPath;
        private string pathWithDocument;
        private bool hasDrawing;

        public Form1()
        {
            InitializeComponent();
            try
            {
                _invApp = (Inventor.Application)Marshal.GetActiveObject("Inventor.Application");

            }
            catch (Exception ex)
            {
                try
                {
                    Type invAppType = Type.GetTypeFromProgID("Inventor.Application");

                    _invApp = (Inventor.Application)System.Activator.CreateInstance(invAppType);
                    _invApp.Visible = true;

                    //Note: if the Inventor session is left running after this
                    //form is closed, there will still an be and Inventor.exe 
                    //running. We will use this Boolean to test in Form1.Designer.cs 
                    //in the dispose method whether or not the Inventor App should
                    //be shut down when the form is closed.
                    _started = true;

                }
                catch (Exception ex2)
                {
                    MessageBox.Show(ex2.ToString());
                    MessageBox.Show("Unable to get or start Inventor");
                }
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Full path of part/assembly
            fullPath = _invApp.ActiveDocument.FullFileName;

            // Delimiter index
            var delimiterIndexPath = fullPath.LastIndexOf('\\');
            var delimiterIndexPoint = fullPath.LastIndexOf('.');

            // Directory
            var directory = fullPath.Substring(0,delimiterIndexPath);

            // Document name with path
            pathWithDocument = fullPath.Substring(0,delimiterIndexPoint);

            // Document name with type 
            var documentNameWithType = fullPath.Substring(delimiterIndexPath + 1);

            // Document name without type
            var delimiterIndexName = documentNameWithType.LastIndexOf('.');
            var documentName = documentNameWithType.Substring(0,delimiterIndexName);

            // Check if drawing exists
            var drawingPath = pathWithDocument + ".idw";
            hasDrawing = File.Exists(@drawingPath);

            // Show labels
            docNameWithType.Visible = true;
            docName.Visible = true;
            path.Visible = true;
            this.directory.Visible = true;
            pathDocument.Visible = true;
            isDrawing.Visible = true;

            // Label assignments
            docNameWithType.Text = documentNameWithType;
            docName.Text = documentName;
            path.Text = fullPath;
            this.directory.Text = directory;
            pathDocument.Text = pathWithDocument;
            isDrawing.Text = hasDrawing ? "Ja" : "Nein";
        }

        private void revisionize_Click(object sender, EventArgs e)
        {
            // Setup
            var prefix = "Rev.A";
            var sourceFile = fullPath;
            var destFile = $"{pathWithDocument} {prefix}.iam";
            // Copy
            System.IO.File.Copy(sourceFile, destFile, true);

            // If drawing applicable
            if (hasDrawing)
            {
                // Setup
                var sourceFileIDW = $"{pathWithDocument}.idw";
                var destFileIDW = $"{pathWithDocument} {prefix}.idw";
                // Copy
                System.IO.File.Copy(sourceFileIDW,destFileIDW,true);
            }
            MessageBox.Show("Erfolgreich revisioniert!");
        }
    }
}
