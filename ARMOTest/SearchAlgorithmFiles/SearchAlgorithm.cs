namespace ARMOTest.SearchAlgorithmFiles
{

    public class SearchAlgorithm
    {
        Form1 form;

        TextBox FileNameSearhTextBox;
        TreeView TreeView;
        Label SearchCountTimeLabel;
        Label CurrentDirectoryNameLabel;
        Label TotalFilesCountLabel;
        Label FoundFilesCountLabel;

        private Regex regex;
        private CancellationTokenSource cancellationTokenSource;
        private Stopwatch stopwatch;

        private bool isPaused;
        private bool hasFiles;
        private object pauseLock = new object();

        private int allFilesCount = 0;
        private int foundFilesCount = 0;

        private string selectedFolderPath;

        public SearchAlgorithm(Form1 form, TextBox FileNameSearhTextBox, TreeView TreeView, Label SearchCountTimeLabel, Label CurrentDirectoryNameLabel
            , Label TotalFilesCountLabel, Label FoundFilesCountLabel, Regex regex, string selectedFolderPath)
        {
            this.form = form;

            this.FileNameSearhTextBox = FileNameSearhTextBox;
            this.selectedFolderPath = selectedFolderPath;
            this.SearchCountTimeLabel = SearchCountTimeLabel;
            this.CurrentDirectoryNameLabel = CurrentDirectoryNameLabel;
            this.TotalFilesCountLabel = TotalFilesCountLabel;
            this.FoundFilesCountLabel = FoundFilesCountLabel;

            this.TreeView = TreeView;
            this.regex = regex;
        }

        public async Task SearchFiles()
        {
            ClearBeforeStartSearch();

            var token = WorkingCancellationTokenSource();
            TreeNode rootNode = FillingTreeView();

            try
            {
                StartTimer();
                _ = UpdateTimeElapsedAsync(token);

                PauseSearch();
                PauseSearch();

                await Task.Run(() => RecursiveSearchMethod(rootNode, selectedFolderPath, token));
            }
            catch (OperationCanceledException)
            {
                
            }
            finally
            {
                stopwatch.Stop();
                SearchCountTimeLabel.Invoke(new Action(() => SearchCountTimeLabel.Text = $"{stopwatch.Elapsed:hh\\:mm\\:ss\\.fff}"));
            }
        }

        public void PauseSearch()
        {
            isPaused = !isPaused;

            if (!isPaused)
                SetPause();
            else
                ContinueSearch();
        }

        public void CancelSearch()
        {
            cancellationTokenSource?.Cancel();
        }

        private void ClearBeforeStartSearch()
        {
            FileNameSearhTextBox.Enabled = false;

            allFilesCount = 0;
            foundFilesCount = 0;

            TreeView.Nodes.Clear();

            isPaused = false;
        }

        private CancellationToken WorkingCancellationTokenSource()
        {
            cancellationTokenSource?.Cancel();
            cancellationTokenSource = new CancellationTokenSource();

            return cancellationTokenSource.Token;
        }

        private TreeNode FillingTreeView()
        {
            TreeNode rootNode = new TreeNode(selectedFolderPath);
            TreeView.Nodes.Add(rootNode);
            return rootNode;
        }

        private void StartTimer()
        {
            stopwatch = new Stopwatch();
            stopwatch.Start();
        }

        private async Task UpdateTimeElapsedAsync(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                TimeSpan elapsedTime = stopwatch.Elapsed;

                SearchCountTimeLabel.Invoke(new Action(() => SearchCountTimeLabel.Text = $"{elapsedTime:hh\\:mm\\:ss\\.fff}"));

                int millisecondsToWait = 10 - (int)elapsedTime.Milliseconds % 10;
                await Task.Delay(millisecondsToWait, token);
            }
        }

        private async Task RecursiveSearchMethod(TreeNode rootNode, string folderPath, CancellationToken token)
        {
            try
            {
                hasFiles = false;
                hasFiles = await WorkingWithDirectories(rootNode, folderPath, token);

                WorkingWithFiles(rootNode, folderPath, token);
                RemoveRootNeed(rootNode);
            }
            catch (OperationCanceledException)
            {
                
            }
        }

        private async Task<bool> WorkingWithDirectories(TreeNode rootNode, string folderPath, CancellationToken token)
        {
            string[] directories = Directory.GetDirectories(folderPath);
            bool foundFilesInAnyDirectory = false;

            foreach (string directory in directories)
            {
                token.ThrowIfCancellationRequested();

                lock (pauseLock)
                    while (isPaused)
                        Monitor.Wait(pauseLock);

                CurrentDirectoryNameLabel.Invoke(new Action<string>(SetCurrentDirectory), directory);

                if (DirectoryContainsFiles(directory))
                {
                    TreeNode dirNode = new TreeNode(Path.GetFileName(directory));
                    AddNodeToTreeView(rootNode, dirNode);
                    await RecursiveSearchMethod(dirNode, directory, token);
                    foundFilesInAnyDirectory = true;
                }
            }

            return foundFilesInAnyDirectory;
        }

        private void WorkingWithFiles(TreeNode rootNode, string folderPath, CancellationToken token)
        {
            string[] files = Directory.GetFiles(folderPath);

            foreach (string file in files)
            {
                token.ThrowIfCancellationRequested();

                lock (pauseLock)
                {
                    while (isPaused)
                    {
                        Monitor.Wait(pauseLock);
                    }
                }

                if (regex.IsMatch(Path.GetFileName(file)))
                {
                    TreeNode fileNode = new TreeNode(Path.GetFileName(file));
                    AddNodeToTreeView(rootNode, fileNode);
                    hasFiles = true;
                }
            }
        }

        private void SetCurrentDirectory(string text) => CurrentDirectoryNameLabel.Text = text;

        private bool DirectoryContainsFiles(string filePath)
        {
            try
            {
                string[] files = Directory.GetFiles(filePath);

                bool res = false;
                foreach (string file in files)
                {
                    allFilesCount++;
                    TotalFilesCountLabel.Invoke(new Action(AllFileLabelChange));

                    if (regex.IsMatch(Path.GetFileName(file)))
                    {
                        foundFilesCount++;
                        FoundFilesCountLabel.Invoke(new Action(FoundFileLabelChange));
                        res = true;
                    }
                }

                if (!res)
                {
                    string[] directories = Directory.GetDirectories(filePath);
                    foreach (string directory in directories)
                    {
                        if (DirectoryContainsFiles(directory))
                        {
                            res = true;
                            break;
                        }
                    }
                }

                return res;
            }
            catch (UnauthorizedAccessException ex)
            {
                return false;
            }
        }

        private void AddNodeToTreeView(TreeNode parentNode, TreeNode childNode)
        {
            if (form.InvokeRequired)
                form.Invoke(new Action<TreeNode, TreeNode>(AddNodeToTreeView), parentNode, childNode);
            else
                parentNode.Nodes.Add(childNode);
        }

        private void AllFileLabelChange() => TotalFilesCountLabel.Text = allFilesCount.ToString();

        private void FoundFileLabelChange() => FoundFilesCountLabel.Text = foundFilesCount.ToString();

        private void RemoveRootNeed(TreeNode rootNode)
        {
            if (!hasFiles && rootNode != null && rootNode.Parent != null)
                rootNode.Remove();
        }

        private void SetPause()
        {
            lock (pauseLock)
            {
                Monitor.PulseAll(pauseLock);
                stopwatch.Start();
                FileNameSearhTextBox.Enabled = false;
            }
        }

        private void ContinueSearch()
        {
            stopwatch.Stop();
            FileNameSearhTextBox.Enabled = true;
        }
    }
}
