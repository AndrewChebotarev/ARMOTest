namespace ARMOTest.ChangeInfo
{
    public class ChangeFileName
    {
        public Regex SaveName(TextBox FileNameSearhTextBox, string fileName)
        {
            try
            {
                ReWriteFileName(FileNameSearhTextBox, fileName);
                return InitializeNewRegex(FileNameSearhTextBox);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при работе с файлом настройки: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return InitializeNewRegex(FileNameSearhTextBox);
            }
        }

        private void ReWriteFileName(TextBox FileNameSearhTextBox, string fileName)
        {
            string[] lines = File.ReadAllLines(fileName);

            if (lines.Length > 1)
            {
                lines[1] = FileNameSearhTextBox.Text;
                File.WriteAllLines(fileName, lines);
            }
        }

        private Regex InitializeNewRegex(TextBox FileNameSearhTextBox) => new Regex(FileNameSearhTextBox.Text);
    }
}
