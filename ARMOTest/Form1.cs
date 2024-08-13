namespace ARMOTest
{
    public partial class Form1 : Form
    {
        private Regex regex;

        private ChangeFileName changeFileName;
        private ChoiceFolder choiceFolder;
        private LoadInform loadInform;
        SearchAlgorithm searchAlgorithm;

        private string settingFilePath;
        private string selectedFolderPath;

        public Form1()
        {
            InitializeComponent();
            InitializeClasses();
            LoadInformation();
        }

        private void InitializeClasses()
        {
            changeFileName = new();
            choiceFolder = new();
            loadInform = new();
        }

        private void LoadInformation()
        {
            settingFilePath = loadInform.GetSettingFilePath();
            regex = loadInform.LoadInformation(SelectRootFolderLabel, FileNameSearhTextBox, settingFilePath);
            selectedFolderPath = loadInform.GetSelectFolderPath(SelectRootFolderLabel);
        }

        private void SelectRootFolderButton_Click(object sender, EventArgs e)
        {
            choiceFolder.FolderChange(SelectRootFolderLabel, settingFilePath);
            selectedFolderPath = SelectRootFolderLabel.Text;
        }

        private void FileNameSearhTextBox_TextChange(object sender, EventArgs e)
        {
            regex = changeFileName.SaveName(FileNameSearhTextBox, settingFilePath);
        }

        private async void SearchButton_Click(object sender, EventArgs e)
        {
            searchAlgorithm?.CancelSearch();

            searchAlgorithm = new(this, FileNameSearhTextBox, TreeView, SearchCountTimeLabel, CurrentDirectoryNameLabel
            , TotalFilesCountLabel, FoundFilesCountLabel, regex, selectedFolderPath);

            await searchAlgorithm.SearchFiles();
        }

        private void PauseButton_Click(object sender, EventArgs e)
        {
            searchAlgorithm.PauseSearch();
        }
    }
}
