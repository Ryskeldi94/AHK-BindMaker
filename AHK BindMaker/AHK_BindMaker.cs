using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace AHK_BindMaker
{
    public partial class MainForm : Form
    {
        private string BindForAHK = "";
        private string GenerateAHK = "";

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnGenerateAHK_Click(object sender, EventArgs e)
        {
            GenerateAHK = "";

            if (string.IsNullOrWhiteSpace(txtHotkey.Text))
            {
                MessageBox.Show("No binds to generate.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(PathForApp.Text))
            {
                MessageBox.Show("No application selected to generate.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lstBinds.Items.Clear();
            AddString("#SingleInstance Force");
            AddString(" ");
            AddString(BindForAHK + ":: { ; " + txtHotkey.Text);
            AddString("    Run " + PathForApp.Text);
            AddString("}");
        }

        private void AddString(string newString)
        {
            if (string.IsNullOrEmpty(GenerateAHK))
            {
                GenerateAHK = newString;
            }
            else
            {
                GenerateAHK += "\n" + newString;
            }

            lstBinds.Items.Add(newString);
        }

        private void txtHotkey_KeyDown(object sender, KeyEventArgs e)
        {
            List<string> mods = new List<string>();
            BindForAHK = "";

            if (e.Control && !mods.Contains("Ctrl"))
            {
                mods.Add("Ctrl");
                BindForAHK += "^";
            }

            if (e.Alt && !mods.Contains("Alt"))
            {
                mods.Add("Alt");
                BindForAHK += "!";
            }

            if (e.Shift && !mods.Contains("Shift"))
            {
                mods.Add("Shift");
                BindForAHK += "+";
            }

            if ((e.KeyCode == Keys.LWin || e.KeyCode == Keys.RWin) && !mods.Contains("Win"))
            {
                mods.Add("Win");
                BindForAHK += "#";
            }

            string key = e.KeyCode.ToString();

            if (key == "ControlKey" || key == "ShiftKey" || key == "Menu" || key.Contains("Win"))
                key = "";

            if (!string.IsNullOrEmpty(key))
            {
                mods.Add(key);
                BindForAHK += key;
            }

            txtHotkey.Text = string.Join(" + ", mods);

            e.SuppressKeyPress = true;
        }

        private void PathForApp_TextChanged(object sender, EventArgs e)
        {
        }

        private void Browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Executable Files (*.exe)|*.exe|Shortcut Files (*.lnk)|*.lnk";
            openFileDialog.Title = "Select a file";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = $"\"{openFileDialog.FileName}\"";
                PathForApp.Text = selectedFilePath;
            }
        }

        private void btnSaveAHK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(GenerateAHK))
            {
                MessageBox.Show("No generated text to save.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "AHK Files (*.ahk)|*.ahk";
            saveFileDialog.Title = "Save AHK script";
            saveFileDialog.FileName = "NewBind.ahk";

            string defaultFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "BindMaker");

            if (!Directory.Exists(defaultFolder))
                Directory.CreateDirectory(defaultFolder);

            saveFileDialog.InitialDirectory = defaultFolder;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllText(saveFileDialog.FileName, GenerateAHK, Encoding.UTF8);
                    MessageBox.Show("Script successfully saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving file:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}