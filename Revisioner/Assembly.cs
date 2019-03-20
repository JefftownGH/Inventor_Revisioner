using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Revisioner
{
    public class Assembly
    {
        private Inventor.Application _inventorObject;
        private Inventor._Document _assemblyObject;
        private string _fullPath;
        private string _pathWithDocument;
        private string _directory;
        private string _documentName;
        private string _documentNameWithType;
        private string _nextRevision;
        private bool _hasRevision;
        private bool _hasDrawing;

        // Constructor
        public Assembly(Inventor.Application inventorObject)
        {
            this._inventorObject = inventorObject;
            this._assemblyObject = inventorObject.ActiveDocument;
        }

        // Function for validating the current active document with the instance document
        private bool CurrentDocument(Inventor.Application currentDocument, Inventor.Application instanceDocument)
        {
            return currentDocument == instanceDocument;
        }

        // Update function
        public void UpdateInformation()
        {
            // Check if active document is of type assembly
            if (!Utility.DocumentChecker("Assembly", this._inventorObject))
            {
                MessageBox.Show("Kann nur in einer Baugruppe ausgeführt werden.");
                return;
            }

            // Check if the active document is the same as the instance document
            var currentDocument = (Inventor.Application)Marshal.GetActiveObject("Inventor.Application");
            if (!CurrentDocument(currentDocument, this._inventorObject))
            {
                MessageBox.Show("Die aktive Baugruppe ist nicht die gleiche wie die vorherige Baugruppe.");
                return;
            }

            // Full path of part/assembly
            this._fullPath = this._inventorObject.ActiveDocument.FullFileName;
            // Directory
            this._directory = Path.GetDirectoryName(this._fullPath);
            // Document name without type
            this._documentName = Path.GetFileNameWithoutExtension(this._fullPath);
            // Document name with path
            this._pathWithDocument = $@"{this._directory}\{this._documentName}";
            // Document name with type 
            this._documentNameWithType = Path.GetFileName(this._fullPath);


            // Check if drawing exists
            var drawingPath = this._pathWithDocument + ".idw";
            this._hasDrawing = File.Exists(@drawingPath);

            // Check if file has revision
            this._hasRevision = Utility.RevisionChecker(this._documentName);

            // Calculate next revision
            this._nextRevision = this._hasRevision ? Utility.NummericRevision(this._documentName).ToString() : "1";
        }

        // Copy function
        public void NextRevision()
        {
            UpdateInformation();

            // Setup
            var documentName = Path.GetFileNameWithoutExtension(this._fullPath);
            var hasRevision = Utility.RevisionChecker(documentName);
            var prefix = hasRevision ? Utility.NummericRevision(documentName) : 1;
            if (hasRevision)
            {
                var delimiter = this._pathWithDocument.IndexOf(' ');
                this._pathWithDocument = this._pathWithDocument.Substring(0, delimiter);
            }

            // Copy pre-setup
            var sourceFile = this._fullPath;
            var destFile = $"{this._pathWithDocument } Rev.{prefix}.iam";
            // Copy
            System.IO.File.Copy(sourceFile, destFile, true);

            // If drawing applicable
            if (this._hasDrawing)
            {
                // Setup
                var sourceFileIDW = $"{this._pathWithDocument }.idw";
                var destFileIDW = $"{this._pathWithDocument } Rev.{prefix}.idw";

                // Copy
                try
                {
                    System.IO.File.Copy(sourceFileIDW, destFileIDW, true);
                    MessageBox.Show("Erfolgreich revisioniert!");
                }
                catch (Exception error)
                {
                    MessageBox.Show("Da hat etwas nicht funktioniert..." + error);
                    throw;
                }
            }

        }
    }
}