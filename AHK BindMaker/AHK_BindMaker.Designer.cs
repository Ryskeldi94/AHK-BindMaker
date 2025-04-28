namespace AHK_BindMaker
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnGenerateAHK;
        private System.Windows.Forms.TextBox txtHotkey;
        private System.Windows.Forms.ListBox lstBinds;
        private System.Windows.Forms.Label lblHotkey;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            btnGenerateAHK = new Button();
            txtHotkey = new TextBox();
            lstBinds = new ListBox();
            lblHotkey = new Label();
            label1 = new Label();
            label2 = new Label();
            PathForApp = new TextBox();
            Browse = new Button();
            btnSaveAHK = new Button();
            SuspendLayout();
            // 
            // btnGenerateAHK
            // 
            btnGenerateAHK.Location = new Point(776, 766);
            btnGenerateAHK.Margin = new Padding(4, 5, 4, 5);
            btnGenerateAHK.Name = "btnGenerateAHK";
            btnGenerateAHK.Size = new Size(188, 47);
            btnGenerateAHK.TabIndex = 1;
            btnGenerateAHK.Text = "сгенерировать .ahk";
            btnGenerateAHK.UseVisualStyleBackColor = true;
            btnGenerateAHK.Click += btnGenerateAHK_Click;
            // 
            // txtHotkey
            // 
            txtHotkey.Location = new Point(705, 75);
            txtHotkey.Margin = new Padding(4, 5, 4, 5);
            txtHotkey.Name = "txtHotkey";
            txtHotkey.Size = new Size(249, 31);
            txtHotkey.TabIndex = 2;
            txtHotkey.KeyDown += txtHotkey_KeyDown;
            // 
            // lstBinds
            // 
            lstBinds.FormattingEnabled = true;
            lstBinds.ItemHeight = 25;
            lstBinds.Location = new Point(15, 477);
            lstBinds.Margin = new Padding(4, 5, 4, 5);
            lstBinds.Name = "lstBinds";
            lstBinds.Size = new Size(939, 279);
            lstBinds.TabIndex = 3;
            // 
            // lblHotkey
            // 
            lblHotkey.AutoSize = true;
            lblHotkey.Location = new Point(705, 32);
            lblHotkey.Margin = new Padding(4, 0, 4, 0);
            lblHotkey.Name = "lblHotkey";
            lblHotkey.Size = new Size(154, 25);
            lblHotkey.TabIndex = 4;
            lblHotkey.Text = "Горячая клавиша";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 32);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(117, 25);
            label1.TabIndex = 5;
            label1.Text = "Приложения";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 75);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(50, 25);
            label2.TabIndex = 6;
            label2.Text = "Путь";
            // 
            // PathForApp
            // 
            PathForApp.Location = new Point(73, 75);
            PathForApp.Margin = new Padding(4, 5, 4, 5);
            PathForApp.Name = "PathForApp";
            PathForApp.Size = new Size(249, 31);
            PathForApp.TabIndex = 7;
            PathForApp.TextChanged += PathForApp_TextChanged;
            // 
            // Browse
            // 
            Browse.Location = new Point(330, 75);
            Browse.Margin = new Padding(4, 5, 4, 5);
            Browse.Name = "Browse";
            Browse.Size = new Size(88, 31);
            Browse.TabIndex = 8;
            Browse.Text = "Обзор";
            Browse.UseVisualStyleBackColor = true;
            Browse.Click += Browse_Click;
            // 
            // btnSaveAHK
            // 
            btnSaveAHK.Location = new Point(41, 766);
            btnSaveAHK.Margin = new Padding(4, 5, 4, 5);
            btnSaveAHK.Name = "btnSaveAHK";
            btnSaveAHK.Size = new Size(188, 47);
            btnSaveAHK.TabIndex = 9;
            btnSaveAHK.Text = "Сохранить";
            btnSaveAHK.UseVisualStyleBackColor = true;
            btnSaveAHK.Click += btnSaveAHK_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(977, 827);
            Controls.Add(btnSaveAHK);
            Controls.Add(Browse);
            Controls.Add(PathForApp);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblHotkey);
            Controls.Add(lstBinds);
            Controls.Add(txtHotkey);
            Controls.Add(btnGenerateAHK);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AHK BindMaker";
            ResumeLayout(false);
            PerformLayout();
        }
        private Label label1;
        private Label label2;
        private TextBox PathForApp;
        private Button Browse;
        private Button btnSaveAHK;
    }
}
