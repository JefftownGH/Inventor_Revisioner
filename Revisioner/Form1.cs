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
        readonly Inventor.Application _invApp;
        private InventorObject _currentInventorObject;

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
            if (Utility.DocumentChecker("Assembly", _invApp))
            {
                this._currentInventorObject = new Assembly(_invApp);
                cmdRevisionize.Text = "Revisionier Baugruppe";
            } else if (Utility.DocumentChecker("Part", _invApp))
            {
                this._currentInventorObject = new Part(_invApp);
                cmdRevisionize.Text = "Revisionier Bauteil";
            }
            else
            {
                MessageBox.Show("Kann nur in einer Baugruppe oder Bauteil ausgeführt werden.");
                return;
            }
            this._currentInventorObject.UpdateInformation();

            // Label assignments
            lblDocumentName.Text = _currentInventorObject.DocumentName;
            lblIsDrawing.Text = _currentInventorObject.HasDrawing ? "Ja" : "Nein";
            lblHasRevision.Text = _currentInventorObject.HasRevision ? "Ja" : "Nein";
            lblNextRevision.Text = _currentInventorObject.NextRevisionNumber;
        }

        private void cmdRevisionize_Click(object sender, EventArgs e)
        {
            this._currentInventorObject?.CopyAndReplace();
            this.Close();
        }
    }
}
