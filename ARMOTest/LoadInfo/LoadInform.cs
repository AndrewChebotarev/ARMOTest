namespace ARMOTest.LoadInfo
{
    public class LoadInform
    {
        public string GetSettingFilePath() => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "setting.txt");

        public Regex LoadInformation(Label SelectRootFolderLabel, TextBox FileNameSearhTextBox, string fileName)
        {
            if (!File.Exists(fileName))
                CreateSettingFile(fileName);
            else
                ReadSettingFile(SelectRootFolderLabel, FileNameSearhTextBox, fileName);

            return new Regex(FileNameSearhTextBox.Text);
        }

        public string GetSelectFolderPath(Label SelectRootFolderLabel) => SelectRootFolderLabel.Text;

        private void CreateSettingFile(string fileName)
        {
            string[] initialLines = { "", "" };
            File.WriteAllLines(fileName, initialLines);
        }

        private void ReadSettingFile(Label SelectRootFolderLabel, TextBox FileNameSearhTextBox, string fileName)
        {
            string[] lines = File.ReadAllLines(fileName);

            LoadFolderPath(SelectRootFolderLabel, lines);
            LoadFileName(FileNameSearhTextBox, lines);
        }

        private void LoadFolderPath(Label SelectRootFolderLabel, string[] lines)
        {
            if (lines.Length > 0)
            {
                string firstLine = lines[0];
                SelectRootFolderLabel.Text = firstLine;
            }
        }

        private void LoadFileName(TextBox FileNameSearhTextBox, string[] lines)
        {
            if (lines.Length > 1)
            {
                string secondLine = lines[1];
                FileNameSearhTextBox.Text = secondLine;
            }
        }
    }
}
