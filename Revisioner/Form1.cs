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
using Inventor;


namespace Revisioner
{
    public partial class Form1 : Form
    {
        Inventor.Application _invApp;
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

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Full path of part/assembly
            var fullPath = _invApp.ActiveDocument.FullFileName;

            // Delimiter index
            var delimiterIndexPath = fullPath.LastIndexOf('\\');
            var delimiterIndexPoint = fullPath.LastIndexOf('.');

            // Directory
            var directory = fullPath.Substring(0,delimiterIndexPath);

            // Document name with path
            var pathWithDocument = fullPath.Substring(0,delimiterIndexPoint);

            // Document name with type 
            var documentNameWithType = fullPath.Substring(delimiterIndexPath + 1);

            // Document name without type
            var delimiterIndexName = documentNameWithType.LastIndexOf('.');
            var documentName = documentNameWithType.Substring(0,delimiterIndexName);

            // Label assignments
            docNameWithType.Text = documentNameWithType;
            docName.Text = documentName;
            path.Text = fullPath;
            this.directory.Text = directory;
            pathDocument.Text = pathWithDocument;
        }
    }
}
