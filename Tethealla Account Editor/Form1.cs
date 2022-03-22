/*
    Tethealla account.dat Editor
    Copyright 2022 Michelle Powers

    Icon assets from the Tethealla project (https://pioneer2.net) were used in this project.
    This project is reliant on Tethealla, but is not affiliated in any way with its developers.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tethealla_Account_Editor
{
    public partial class Form1 : Form
    {
        // Class global for user-chosen .dat file.
        string fileName;

        public Form1()
        {
            InitializeComponent();
        }

        // Exit context menu option.
        private void mnuExit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        // Save context menu option. Write contents from the datatable to our file.
        private void mnuSave_Click(object sender, EventArgs e)
        {
            int name_offset = 0x0, gcn_offset = 0x150, gm_offset = 0x154;
            byte[] name_bytes, gcn_bytes;
            string name_temp;
            uint gcn_temp;
            int num_to_pad;

            using (FileStream fs = File.Open(fileName, FileMode.Open, FileAccess.Write, FileShare.None))
            {
                using (BinaryWriter reader = new BinaryWriter(fs))
                {
                    for (int i = 0; i < dataTable.RowCount; i++)
                    {
                        try
                        {
                            // Write account names.
                            name_temp = dataTable.Rows[i].Cells[0].Value.ToString();
                            name_temp = String.Concat(name_temp.Where(c => !Char.IsWhiteSpace(c)));
                            name_temp = name_temp.Replace("\0", string.Empty);
                            num_to_pad = 18 - name_temp.Length;
                            name_temp += "\0";
                            name_bytes = Encoding.Default.GetBytes(name_temp);
                            for (int j = 1; j < num_to_pad; j++)
                            {
                                Array.Resize(ref name_bytes, name_bytes.Length + 1);
                                name_bytes[name_bytes.Length - 1] = 0xCC;
                            }
                            fs.Seek(name_offset + (0x188 * i), 0);
                            fs.Write(name_bytes, 0, 0x12);

                            // Write Guild Card numbers.
                            gcn_temp = UInt32.Parse(dataTable.Rows[i].Cells[1].Value.ToString());
                            gcn_bytes = BitConverter.GetBytes(gcn_temp);
                            fs.Seek(gcn_offset + (0x188 * i), 0);
                            fs.Write(gcn_bytes, 0, 4);

                            // Write global GM flags.
                            fs.Seek(gm_offset + (0x188 * i), 0);
                            if (dataTable.Rows[i].Cells[2].Value.ToString() == "Yes")
                                fs.WriteByte(1);
                            else fs.WriteByte(0);
                        }
                        catch
                        {
                            continue;
                        }
                    }
                    fs.Close();
                }
            }
        }

        // Parse/re-parse the account list.
        private void parseAccounts()
        {
            dataTable.Rows.Clear(); // Clear all data when opening a new file.

            using (FileStream fs = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                using (BinaryReader reader = new BinaryReader(fs))
                {
                    byte[] nameTemp = new byte[0x12];
                    byte[] gcNum = new byte[0x04];
                    bool isGlobalGM = false;
                    int offset = 0;
                    int eof = 0;

                    while (eof != -1)
                    {
                        try
                        {
                            // Read account names.
                            fs.Seek(offset, 0);
                            fs.Read(nameTemp, 0, 0x12);

                            // Read Guild Card numbers.
                            offset += 0x150;
                            fs.Seek(offset, 0);
                            fs.Read(gcNum, 0, 0x04);

                            // Read global GM flags.
                            offset += 4;
                            fs.Seek(offset, 0);
                            isGlobalGM = Convert.ToBoolean(fs.ReadByte());

                            // Need to strip name of all padded chars before adding to our text boxes!
                            for (int i = 0; i < nameTemp.Length; i++)
                            {
                                if (nameTemp[i] == 0xCC)
                                    nameTemp[i] = 0x0;
                            }

                            dataTable.Rows.Add(Encoding.Default.GetString(nameTemp), BitConverter.ToUInt32(gcNum, 0), isGlobalGM ? "Yes" : "No");
                            offset += 0x34;
                            fs.Seek(offset, 0);
                            eof = fs.ReadByte(); // EOF check.
                        }
                        catch
                        {
                            fs.Close();
                            return;
                        }
                    }

                    fs.Close();
                }
            }
        }

        // Open context menu handler. Clear the table, then parse the accounts.
        private void mnuOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = ".dat files (*.dat)|*.dat|All files (*.*)|*.*";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                fileName = dlg.FileName;
                dataTable.Enabled = true;
                mnuAddAccount.Enabled = true;
                mnuSave.Enabled = true;
                parseAccounts();               
            }
        }

        private void dataTable_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            // Needed in order to fully save edits to our data table in case the the user doesn't leave a cell before saving!      
            dataTable.CommitEdit(DataGridViewDataErrorContexts.Commit);

            // Convert to UInt32 for easy sorting.
            try
            {
                if (dataTable.CurrentCell.ColumnIndex == 1)
                    dataTable.CurrentCell.Value = UInt32.Parse(dataTable.CurrentCell.Value.ToString());
            }
            catch
            {
                dataTable.CurrentCell.Value = UInt32.MaxValue;
                return;
            }
        }

        private void dataTable_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);

            // Don't allow spaces in account names.
            if (dataTable.CurrentCell.ColumnIndex == 0)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }

            e.Control.KeyPress -= new KeyPressEventHandler(Column2_KeyPress);

            // We also only want to allow number input for Guild Card numbers!
            if (dataTable.CurrentCell.ColumnIndex == 1)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column2_KeyPress);
                }
            }
        }
        private void Column1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void Column2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Add account handler - start external "account_add.exe" process, then re-parse the account table if one is added.
        private void addAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {       
                Process process = new Process();
                process.StartInfo.FileName = "account_add.exe";
                process.Start();
                process.WaitForExit();
            }
            catch
            {
                MessageBox.Show("account_add.exe was not found. Ensure that it is in the same directory as this program in order to use this option.", 
                    "account_add.exe not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }           
            parseAccounts();
        }           
    }
}
