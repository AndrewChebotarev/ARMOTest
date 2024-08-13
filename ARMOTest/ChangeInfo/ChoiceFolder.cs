namespace ARMOTest.ChangeInfo
{
    public class ChoiceFolder
    {
        public void FolderChange(Label SelectRootFolderLabel, string filePath)
        {
            using (FolderBrowserDialog folderBrowserDialog = new())
            {
                WorkingDialogBox(SelectRootFolderLabel, folderBrowserDialog);
                CheckFileExists(SelectRootFolderLabel, filePath);
            }
        }

        private void WorkingDialogBox(Label SelectRootFolderLabel, FolderBrowserDialog folderBrowserDialog)
        {
            folderBrowserDialog.Description = "Выберите папку:";
            folderBrowserDialog.RootFolder = Environment.SpecialFolder.Desktop;

            DialogResult dialogResult = folderBrowserDialog.ShowDialog();

            if (dialogResult == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                SelectRootFolderLabel.Text = folderBrowserDialog.SelectedPath;
        }

        private void CheckFileExists(Label SelectRootFolderLabel, string filePath)
        {
            if (File.Exists(filePath))
                ReWriteData(SelectRootFolderLabel, filePath);
        }

        private void ReWriteData(Label SelectRootFolderLabel, string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);

            if (lines.Length > 0)
            {
                lines[0] = SelectRootFolderLabel.Text;
                File.WriteAllLines(filePath, lines);
            }
        }
    }
}
