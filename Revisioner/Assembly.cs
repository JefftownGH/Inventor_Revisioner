using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Inventor;
using File = System.IO.File;
using Path = System.IO.Path;

namespace Revisioner
{
    public class Assembly
    {
        private Inventor.Application _inventorObject;
        private Inventor._Document _assemblyObject;
        public string FullPath { get; private set; }
        public string FullPathWithRev { get; private set; }
        public string PathWithDocument { get; private set; }
        public string Directory { get; private set; }
        public string DocumentName { get; private set; }
        public string DocumentNameWithType { get; private set; }
        public string NextRevisionNumber { get; private set; }
        public string DrawingPathWithRev { get; private set; }
        public string FileExtension { get; private set; }
        public string Part { get; private set; }
        public bool HasRevision { get; private set; }
        public bool HasDrawing { get; private set; }

        // Constructor
        public Assembly(Inventor.Application inventorObject)
        {
            this._inventorObject = inventorObject;
            this._assemblyObject = inventorObject.ActiveDocument;
        }


        // Update function
        public void UpdateInformation()
        {
            // Check if active document is of type assembly
            if (!Utility.DocumentChecker("Assembly", this._inventorObject) && !Utility.DocumentChecker("Part", this._inventorObject))
            {
                MessageBox.Show("Kann nur in einer Baugruppe oder Bauteil ausgeführt werden.");
                return;
            }

            // Check if the active document is the same as the instance document
            var currentDocument = (Inventor.Application)Marshal.GetActiveObject("Inventor.Application");
            if (!Utility.CurrentDocument(currentDocument, this._inventorObject))
            {
                MessageBox.Show("Die aktive Baugruppe / Bauteil ist nicht die gleiche wie die vorherige Baugruppe.");
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
            // Extension
            this.FileExtension = Path.GetExtension(this.FullPath);
            // Partname
            this.Part = this.FileExtension == ".iam" ? "Baugruppe" : "Bauteil";


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
            // Setup
            var documentName = Path.GetFileNameWithoutExtension(this.FullPath);
            var hasRevision = Utility.RevisionChecker(documentName);
            var prefix = hasRevision ? Utility.NummericRevision(documentName) : "01";
            if (hasRevision)
            {
                var delimiter = this.PathWithDocument.IndexOf(' ');
                this.PathWithDocument = this.PathWithDocument.Substring(0, delimiter);
            }

            // Copy pre-setup
            var sourceFile = this.FullPath;
            this.FullPathWithRev = $"{this.PathWithDocument } Rev.{prefix}{this.FileExtension}";
            var destFile = this.FullPathWithRev;

            // If drawing applicable
            if (this.HasDrawing)
            {
                // Setup
                var sourceFileIDW = $"{this.PathWithDocument }.idw";
                this.DrawingPathWithRev = $"{this.PathWithDocument } Rev.{prefix}.idw";

                // Copy of drawing and assembly / part
                try
                {
                    System.IO.File.Copy(sourceFile, destFile, true);
                    System.IO.File.Copy(sourceFileIDW, this.DrawingPathWithRev, true);
                    MessageBox.Show($"{this.Part} und Zeichnung erfolgreich revisioniert!");
                }
                catch (Exception error)
                {
                    MessageBox.Show("Da hat etwas nicht funktioniert..." + error);
                    throw;
                }
            }
            else
            {
                // Copy of assembly / part
                try
                {
                    System.IO.File.Copy(sourceFile, destFile, true);
                    MessageBox.Show($"{this.Part} erfolgreich revisioniert!");
                }
                catch (Exception error)
                {
                    MessageBox.Show("Da hat etwas nicht funktioniert: " + error.Message);
                    throw;
                }

            }

        }

        public void OpenDrawingAndReplace()
        {
            // Opens the copied drawing (with new revision)
            if (this.DrawingPathWithRev != null)
            {
                // Silent Inventor on
                this._inventorObject.SilentOperation = true;
                // Open drawing
                this._inventorObject.Documents.Open(this.DrawingPathWithRev, true);
                var revisedDrawing = this._inventorObject.ActiveDocument.File;
                // Replace all references
                var allDrawingReferences = revisedDrawing.ReferencedFileDescriptors;
                var part = this.FileExtension == ".iam" ? "Baugruppe" : "Bauteil";
                try
                {
                    foreach (FileDescriptor reference in allDrawingReferences)
                    {
                        if (reference.FullFileName == this.FullPath)
                        {
                            reference.ReplaceReference(this.FullPathWithRev);
                            MessageBox.Show($"{this.Part}referenz ersetzt.");
                        }
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show("Da hat etwas nicht funktioniert: " + error.Message);
                    throw;
                }

                // Save drawing
                this._inventorObject.ActiveDocument.Save();
                // Close drawing
                this._inventorObject.ActiveDocument.Close();

                // Silent Inventor off
                this._inventorObject.SilentOperation = false;
            }
        }
    }
}