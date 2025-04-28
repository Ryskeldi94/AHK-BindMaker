// BindMaker - минимальный стартовый шаблон
// Windows Forms (.NET Framework) проект

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
        private List<BindItem> binds = new List<BindItem>();

        public MainForm()
        {
            InitializeComponent();
        }


        private void btnGenerateAHK_Click(object sender, EventArgs e)
        {
            GenerateAHK = "";

            if (string.IsNullOrWhiteSpace(txtHotkey.Text))
            {
                MessageBox.Show("Нет биндов для сгенерирования.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(PathForApp.Text))
            {
                MessageBox.Show("Не выбрано приложения для сгенерирования.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            BindForAHK = ""; // Сбрасываем `BindForAHK` при каждом вызове

            // Проверяем модификаторы и добавляем их в список и строку AutoHotkey
            if (e.Control && !mods.Contains("Ctrl"))
            {
                mods.Add("Ctrl");
                BindForAHK += "^"; // Добавляем символ AutoHotkey
            }

            if (e.Alt && !mods.Contains("Alt"))
            {
                mods.Add("Alt");
                BindForAHK += "!"; // Добавляем символ AutoHotkey
            }

            if (e.Shift && !mods.Contains("Shift"))
            {
                mods.Add("Shift");
                BindForAHK += "+"; // Добавляем символ AutoHotkey
            }

            if ((e.KeyCode == Keys.LWin || e.KeyCode == Keys.RWin) && !mods.Contains("Win"))
            {
                mods.Add("Win");
                BindForAHK += "#"; // Добавляем символ AutoHotkey
            }

            // Основная клавиша
            string key = e.KeyCode.ToString();

            // Убираем системные служебные клавиши
            if (key == "ControlKey" || key == "ShiftKey" || key == "Menu" || key.Contains("Win"))
                key = "";

            // Добавляем основную клавишу
            if (!string.IsNullOrEmpty(key))
            {
                mods.Add(key); // Добавляем в список модификаторов
                BindForAHK += key; // Добавляем в строку AutoHotkey
            }

            // Обновляем текстовое поле
            txtHotkey.Text = string.Join(" + ", mods);

            e.SuppressKeyPress = true; // Отключаем стандартное поведение клавиш
        }


        private void PathForApp_TextChanged(object sender, EventArgs e)
        {

        }

        private void Browse_Click(object sender, EventArgs e)
        {
            // Создаем диалоговое окно
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Настраиваем фильтр для выбора только .exe и .lnk файлов
            openFileDialog.Filter = "Executable Files (*.exe)|*.exe|Shortcut Files (*.lnk)|*.lnk";
            openFileDialog.Title = "Выберите файл";

            // Проверяем, что пользователь нажал OK
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Получаем путь к выбранному файлу и добавляем кавычки
                string selectedFilePath = $"\"{openFileDialog.FileName}\"";

                // Записываем путь с кавычками в текстовое поле
                PathForApp.Text = selectedFilePath;
            }
        }

        private void btnSaveAHK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(GenerateAHK))
            {
                MessageBox.Show("Нет сгенерированного текста для сохранения.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "AHK Files (*.ahk)|*.ahk";
            saveFileDialog.Title = "Сохранить AHK скрипт";
            saveFileDialog.FileName = "NewBind.ahk";

            // Устанавливаем папку по умолчанию
            string defaultFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "BindMaker");

            if (!Directory.Exists(defaultFolder))
                Directory.CreateDirectory(defaultFolder); // Создать папку если её нет

            saveFileDialog.InitialDirectory = defaultFolder;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllText(saveFileDialog.FileName, GenerateAHK, Encoding.UTF8);
                    MessageBox.Show("Скрипт успешно сохранен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при сохранении файла:\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


    }

    public class BindItem
    {
        public string GenerateAHK = "";
    }
}
