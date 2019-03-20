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
        public string FullPath { get; private set; }
        public string PathWithDocument { get; private set; }
        public string Directory { get; private set; }
        public string DocumentName { get; private set; }
        public string DocumentNameWithType { get; private set; }
        public string NextRevisionNumber { get; private set; }
        public bool HasRevision { get; private set; }
        public bool HasDrawing { get; private set; }

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
            this.FullPath = this._inventorObject.ActiveDocument.FullFileName;
            // Directory
            this.Directory = Path.GetDirectoryName(this.FullPath);
            // Document name without type
            this.DocumentName = Path.GetFileNameWithoutExtension(this.FullPath);
            // Document name with path
            this.PathWithDocument = $@"{this.Directory}\{this.DocumentName}";
            // Document name with type 
            this.DocumentNameWithType = Path.GetFileName(this.FullPath);


            // Check if drawing exists
            var drawingPath = this.PathWithDocument + ".idw";
            this.HasDrawing = File.Exists(@drawingPath);

            // Check if file has revision
            this.HasRevision = Utility.RevisionChecker(this.DocumentName);

            // Calculate next revision
            this.NextRevisionNumber = this.HasRevision ? Utility.NummericRevision(this.DocumentName).ToString() : "1";
        }

        // Copy function
        public void NextRevision()
        {
            UpdateInformation();

            // Setup
            var documentName = Path.GetFileNameWithoutExtension(this.FullPath);
            var hasRevision = Utility.RevisionChecker(documentName);
            var prefix = hasRevision ? Utility.NummericRevision(documentName) : 1;
            if (hasRevision)
            {
                var delimiter = this.PathWithDocument.IndexOf(' ');
                this.PathWithDocument = this.PathWithDocument.Substring(0, delimiter);
            }

            // Copy pre-setup
            var sourceFile = this.FullPath;
            var destFile = $"{this.PathWithDocument } Rev.{prefix}.iam";
            // Copy
            System.IO.File.Copy(sourceFile, destFile, true);

            // If drawing applicable
            if (this.HasDrawing)
            {
                // Setup
                var sourceFileIDW = $"{this.PathWithDocument }.idw";
                var destFileIDW = $"{this.PathWithDocument } Rev.{prefix}.idw";

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