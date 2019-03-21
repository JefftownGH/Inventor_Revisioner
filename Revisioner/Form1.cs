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
        private Assembly currentAssembly;
        bool _started = false;

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
            this.currentAssembly = new Assembly(_invApp);
            this.currentAssembly.UpdateInformation();

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
            lblDocNameWithType.Text = currentAssembly.DocumentNameWithType;
            lblDocName.Text = currentAssembly.DocumentName;
            lblPath.Text = currentAssembly.FullPath;
            lblDirectory.Text = currentAssembly.Directory;
            lblPathDocument.Text = currentAssembly.PathWithDocument;
            lblIsDrawing.Text = currentAssembly.HasDrawing ? "Ja" : "Nein";
            lblHasRevision.Text = currentAssembly.HasRevision ? "Ja" : "Nein";
            lblNextRevision.Text = currentAssembly.NextRevisionNumber;
        }

        private void cmdRevisionize_Click(object sender, EventArgs e)
        {
            if (this.currentAssembly == null)
            {
                MessageBox.Show("Baugruppe wurde noch nicht initialisiert.");
                return;
            }
            this.currentAssembly.NextRevision();
        }

        private void cmdOpenDrawing_Click(object sender, EventArgs e)
        {
            currentAssembly?.OpenDrawingAndReplace();
        }

        private void cmdThing_Click(object sender, EventArgs e)
        {
            this.currentAssembly = new Assembly(this._invApp);
            this.currentAssembly?.UpdateInformation();
            this.currentAssembly?.NextRevision();
            this.currentAssembly?.OpenDrawingAndReplace();
        }
    }
}
