namespace ARMOTest
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            SearchButton = new Button();
            PauseButton = new Button();
            TreeView = new TreeView();
            CurrentDirectoryLabel = new Label();
            CurrentDirectoryNameLabel = new Label();
            SelectRootFolderButton = new Button();
            SelectRootFolderLabel = new Label();
            FileNameSearhLabel = new Label();
            FileNameSearhTextBox = new TextBox();
            TotalFilesLabel = new Label();
            TotalFilesCountLabel = new Label();
            FoundFilesLabel = new Label();
            FoundFilesCountLabel = new Label();
            SearchTimeLabel = new Label();
            SearchCountTimeLabel = new Label();
            SuspendLayout();
            // 
            // SearchButton
            // 
            SearchButton.Location = new Point(38, 40);
            SearchButton.Margin = new Padding(3, 4, 3, 4);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(106, 35);
            SearchButton.TabIndex = 0;
            SearchButton.Text = "Начать поиск";
            SearchButton.UseVisualStyleBackColor = true;
            SearchButton.Click += SearchButton_Click;
            // 
            // PauseButton
            // 
            PauseButton.Location = new Point(216, 40);
            PauseButton.Margin = new Padding(3, 4, 3, 4);
            PauseButton.Name = "PauseButton";
            PauseButton.Size = new Size(106, 35);
            PauseButton.TabIndex = 1;
            PauseButton.Text = "Пауза";
            PauseButton.UseVisualStyleBackColor = true;
            PauseButton.Click += PauseButton_Click;
            // 
            // TreeView
            // 
            TreeView.Location = new Point(38, 83);
            TreeView.Margin = new Padding(3, 4, 3, 4);
            TreeView.Name = "TreeView";
            TreeView.Size = new Size(284, 459);
            TreeView.TabIndex = 4;
            // 
            // CurrentDirectoryLabel
            // 
            CurrentDirectoryLabel.AutoSize = true;
            CurrentDirectoryLabel.Location = new Point(369, 48);
            CurrentDirectoryLabel.Name = "CurrentDirectoryLabel";
            CurrentDirectoryLabel.Size = new Size(156, 20);
            CurrentDirectoryLabel.TabIndex = 9;
            CurrentDirectoryLabel.Text = "Текущая директория:";
            // 
            // CurrentDirectoryNameLabel
            // 
            CurrentDirectoryNameLabel.AutoSize = true;
            CurrentDirectoryNameLabel.Location = new Point(518, 48);
            CurrentDirectoryNameLabel.Name = "CurrentDirectoryNameLabel";
            CurrentDirectoryNameLabel.Size = new Size(0, 20);
            CurrentDirectoryNameLabel.TabIndex = 10;
            // 
            // SelectRootFolderButton
            // 
            SelectRootFolderButton.Location = new Point(351, 83);
            SelectRootFolderButton.Margin = new Padding(3, 4, 3, 4);
            SelectRootFolderButton.Name = "SelectRootFolderButton";
            SelectRootFolderButton.Size = new Size(181, 35);
            SelectRootFolderButton.TabIndex = 11;
            SelectRootFolderButton.Text = "Выбор корневой папки";
            SelectRootFolderButton.UseVisualStyleBackColor = true;
            SelectRootFolderButton.Click += SelectRootFolderButton_Click;
            // 
            // SelectRootFolderLabel
            // 
            SelectRootFolderLabel.AutoSize = true;
            SelectRootFolderLabel.Location = new Point(351, 139);
            SelectRootFolderLabel.Name = "SelectRootFolderLabel";
            SelectRootFolderLabel.Size = new Size(0, 20);
            SelectRootFolderLabel.TabIndex = 12;
            // 
            // FileNameSearhLabel
            // 
            FileNameSearhLabel.AutoSize = true;
            FileNameSearhLabel.Location = new Point(369, 169);
            FileNameSearhLabel.Name = "FileNameSearhLabel";
            FileNameSearhLabel.Size = new Size(157, 20);
            FileNameSearhLabel.TabIndex = 13;
            FileNameSearhLabel.Text = "Имя искомого файла";
            // 
            // FileNameSearhTextBox
            // 
            FileNameSearhTextBox.Location = new Point(381, 193);
            FileNameSearhTextBox.Margin = new Padding(3, 4, 3, 4);
            FileNameSearhTextBox.Name = "FileNameSearhTextBox";
            FileNameSearhTextBox.Size = new Size(117, 27);
            FileNameSearhTextBox.TabIndex = 14;
            FileNameSearhTextBox.TextChanged += FileNameSearhTextBox_TextChange;
            // 
            // TotalFilesLabel
            // 
            TotalFilesLabel.AutoSize = true;
            TotalFilesLabel.Location = new Point(391, 260);
            TotalFilesLabel.Name = "TotalFilesLabel";
            TotalFilesLabel.Size = new Size(104, 20);
            TotalFilesLabel.TabIndex = 15;
            TotalFilesLabel.Text = "Всего файлов";
            // 
            // TotalFilesCountLabel
            // 
            TotalFilesCountLabel.AutoSize = true;
            TotalFilesCountLabel.Location = new Point(351, 283);
            TotalFilesCountLabel.Name = "TotalFilesCountLabel";
            TotalFilesCountLabel.Size = new Size(0, 20);
            TotalFilesCountLabel.TabIndex = 16;
            // 
            // FoundFilesLabel
            // 
            FoundFilesLabel.AutoSize = true;
            FoundFilesLabel.Location = new Point(351, 332);
            FoundFilesLabel.Name = "FoundFilesLabel";
            FoundFilesLabel.Size = new Size(219, 20);
            FoundFilesLabel.TabIndex = 17;
            FoundFilesLabel.Text = "Количество найденых файлов";
            // 
            // FoundFilesCountLabel
            // 
            FoundFilesCountLabel.AutoSize = true;
            FoundFilesCountLabel.Location = new Point(351, 368);
            FoundFilesCountLabel.Name = "FoundFilesCountLabel";
            FoundFilesCountLabel.Size = new Size(0, 20);
            FoundFilesCountLabel.TabIndex = 18;
            // 
            // SearchTimeLabel
            // 
            SearchTimeLabel.AutoSize = true;
            SearchTimeLabel.Location = new Point(390, 399);
            SearchTimeLabel.Name = "SearchTimeLabel";
            SearchTimeLabel.Size = new Size(107, 20);
            SearchTimeLabel.TabIndex = 19;
            SearchTimeLabel.Text = "Время поиска";
            // 
            // SearchCountTimeLabel
            // 
            SearchCountTimeLabel.AutoSize = true;
            SearchCountTimeLabel.Location = new Point(390, 440);
            SearchCountTimeLabel.Name = "SearchCountTimeLabel";
            SearchCountTimeLabel.Size = new Size(0, 20);
            SearchCountTimeLabel.TabIndex = 20;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(SearchCountTimeLabel);
            Controls.Add(SearchTimeLabel);
            Controls.Add(FoundFilesCountLabel);
            Controls.Add(FoundFilesLabel);
            Controls.Add(TotalFilesCountLabel);
            Controls.Add(TotalFilesLabel);
            Controls.Add(FileNameSearhTextBox);
            Controls.Add(FileNameSearhLabel);
            Controls.Add(SelectRootFolderLabel);
            Controls.Add(SelectRootFolderButton);
            Controls.Add(CurrentDirectoryNameLabel);
            Controls.Add(CurrentDirectoryLabel);
            Controls.Add(TreeView);
            Controls.Add(PauseButton);
            Controls.Add(SearchButton);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button SearchButton;
        private Button PauseButton;
        private TreeView TreeView;
        private Label CurrentDirectoryLabel;
        private Label CurrentDirectoryNameLabel;
        private Button SelectRootFolderButton;
        private Label SelectRootFolderLabel;
        private Label FileNameSearhLabel;
        private TextBox FileNameSearhTextBox;
        private Label TotalFilesLabel;
        private Label TotalFilesCountLabel;
        private Label FoundFilesLabel;
        private Label FoundFilesCountLabel;
        private Label SearchTimeLabel;
        private Label SearchCountTimeLabel;
    }
}
