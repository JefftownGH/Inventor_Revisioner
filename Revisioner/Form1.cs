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
using System.Text.RegularExpressions;
using Inventor;
using File = System.IO.File;
using Path = System.IO.Path;


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

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            // Check if active document is of type assembly
            if (!DocumentChecker("Assembly"))
            {
                MessageBox.Show("Kann nur in einer Baugruppe ausgeführt werden.");
                return;
            }


            // Full path of part/assembly
            fullPath = _invApp.ActiveDocument.FullFileName;

            // Directory
            var directory = Path.GetDirectoryName(fullPath);

            // Document name without type
            var documentName = Path.GetFileNameWithoutExtension(fullPath);
            
            // Document name with path
            pathWithDocument = $@"{directory}\{documentName}";

            // Document name with type 
            var documentNameWithType = Path.GetFileName(fullPath);


            // Check if drawing exists
            var drawingPath = pathWithDocument + ".idw";
            hasDrawing = File.Exists(@drawingPath);

            // Check if file has revision
            var hasRevision = RevisionChecker(documentName);

            // Calculate next revision
            var nextRevision = hasRevision ? NummericRevision(documentName).ToString() : "1";

            // Show labels
            lblDocNameWithType.Visible = true;
            lblDocName.Visible = true;
            lblPath.Visible = true;
            lblDirectory.Visible = true;
            lblPathDocument.Visible = true;
            lblIsDrawing.Visible = true;
            lblHasRevision.Visible = true;
            lblNextRevision.Visible = true;

            // Label assignments
            lblDocNameWithType.Text = documentNameWithType;
            lblDocName.Text = documentName;
            lblPath.Text = fullPath;
            lblDirectory.Text = directory;
            lblPathDocument.Text = pathWithDocument;
            lblIsDrawing.Text = hasDrawing ? "Ja" : "Nein";
            lblHasRevision.Text = hasRevision ? "Ja" : "Nein";
            lblNextRevision.Text = nextRevision;
        }

        private void cmdRevisionize_Click(object sender, EventArgs e)
        {
            // Check if active document is of type assembly
            if (!DocumentChecker("Assembly"))
            {
                MessageBox.Show("Kann nur in einer Baugruppe ausgeführt werden.");
                return;
            }

            var documentName = Path.GetFileNameWithoutExtension(fullPath);
            var hasRevision = RevisionChecker(documentName);
            var prefix = hasRevision ? NummericRevision(documentName) : 1;
            if (hasRevision)
            {
                var delimiter = pathWithDocument.IndexOf(' ');
                pathWithDocument = pathWithDocument.Substring(0, delimiter);
            }

            // Setup
            var sourceFile = fullPath;
            var destFile = $"{pathWithDocument} Rev.{prefix}.iam";
            // Copy
            System.IO.File.Copy(sourceFile, destFile, true);

            // If drawing applicable
            if (hasDrawing)
            {
                // Setup
                var sourceFileIDW = $"{pathWithDocument}.idw";
                var destFileIDW = $"{pathWithDocument} Rev.{prefix}.idw";

                // Copy
                try
                {
                    System.IO.File.Copy(sourceFileIDW,destFileIDW,true);
                    MessageBox.Show("Erfolgreich revisioniert!");
                }
                catch (Exception error)
                {
                    MessageBox.Show("Da hat etwas nicht funktioniert..." + error);
                    throw;
                }
            }
        }

        private bool RevisionChecker(string documentName)
        {
            var rgx = new Regex(@"(?i)rev");
            return rgx.IsMatch(documentName);
        }

        private int NummericRevision(string documentName)
        {
            var delimiter = documentName.LastIndexOf('.');
            var currentRevision = int.Parse(documentName.Substring(delimiter + 1));
            return ++currentRevision;
        }

        private bool DocumentChecker(string allowedDocument)
        {
            bool isValid;
            switch (allowedDocument)
            {
                case "Assembly":
                    isValid = _invApp.ActiveDocumentType == DocumentTypeEnum.kAssemblyDocumentObject ? true : false;
                    break;
                case "Drawing":
                    isValid = _invApp.ActiveDocumentType == DocumentTypeEnum.kDrawingDocumentObject ? true : false;
                    break;
                case "Part":
                    isValid = _invApp.ActiveDocumentType == DocumentTypeEnum.kPartDocumentObject ? true : false;
                    break;
                default:
                    isValid = false;
                    break;
            }

            return isValid;
        }
    }
}
