﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IrisContabilidad.clases
{
    public class FileFolderDialog
    {
        private OpenFileDialog dialog = new OpenFileDialog();

        public OpenFileDialog Dialog
        {
            get { return dialog; }
            set { dialog = value; }
        }

        public new DialogResult ShowDialog()
        {
            return this.ShowDialog(null);
        }

        public new DialogResult ShowDialog(IWin32Window owner)
        {
            // Set validate names to false otherwise windows will not let you select "Folder Selection."
            dialog.ValidateNames = false;
            dialog.CheckFileExists = false;
            dialog.CheckPathExists = true;

            try
            {
                // Set initial directory (used when dialog.FileName is set from outside)
                if (dialog.FileName != null && dialog.FileName != "")
                {
                    if (Directory.Exists(dialog.FileName))
                        dialog.InitialDirectory = Path.GetDirectoryName(dialog.FileName);
                    else
                        dialog.InitialDirectory = Path.GetDirectoryName(dialog.FileName);
                }
            }
            catch (Exception ex)
            {
                // Do nothing
            }

            // Always default to Folder Selection.
            dialog.FileName = "Seleccionar un Folder.";

            if (owner == null)
                return dialog.ShowDialog();
            else
                return dialog.ShowDialog(owner);
        }
        /// <summary>
        // Helper property. Parses FilePath into either folder path (if Folder Selection. is set)
        // or returns file path
        /// </summary>
        public string SelectedPath
        {
            get
            {
                try
                {
                    if (dialog.FileName != null &&
                        (dialog.FileName.EndsWith("Folder Selection.") || !File.Exists(dialog.FileName)) &&
                        !Directory.Exists(dialog.FileName))
                    {
                        return Path.GetDirectoryName(dialog.FileName);
                    }
                    else
                    {
                        return Path.GetDirectoryName(dialog.FileName);
                    }
                }
                catch (Exception ex)
                {
                    return dialog.FileName;
                }
            }
            set
            {
                if (value != null && value != "")
                {
                    dialog.FileName = value;
                }
            }
        }

        /// <summary>
        /// When multiple files are selected returns them as semi-colon seprated string
        /// </summary>
        public string SelectedPaths
        {
            get
            {
                if (dialog.FileNames != null && dialog.FileNames.Length > 1)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (string fileName in dialog.FileNames)
                    {
                        try
                        {
                            if (File.Exists(fileName))
                                sb.Append(fileName + ";");
                        }
                        catch (Exception ex)
                        {
                            // Go to next
                        }
                    }
                    return sb.ToString();
                }
                else
                {
                    return null;
                }
            }
        }

        public void Reset()
        {
            dialog.Reset();
        }
        protected bool RunDialog(IntPtr hwndOwner)
        {
            return true;
        }
    }
}