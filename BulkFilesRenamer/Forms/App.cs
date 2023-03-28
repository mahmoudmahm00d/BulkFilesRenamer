using System.Diagnostics;
using System.Text.Json;
using BulkFilesRenamer.Helpers;

namespace BulkFilesRenamer.Forms;

public partial class App : Form
{
    private const int NONE_SELECTED = -1;
    private readonly IIOHandler IOHandler;
    private ILinkedListManager<FileInfo> filesListViewManager;

    public App()
    {
        IOHandler = new IOHandler();
        InitializeComponent();
    }

    #region Path Controller buttons
    private void OnSelectFolderButtonClick(object sender, EventArgs e)
    {
        FolderBrowserDialog folderBrowserDialog = new();
        DialogResult result = folderBrowserDialog.ShowDialog();
        // If the user selected a path
        if (result == DialogResult.OK)
        {
            // Enable buttons
            SetButtonsEnabledValue(true);
            // Save selected path
            selectedPathTextBox.Text = folderBrowserDialog.SelectedPath;
            // Get folder files
            IOHandler.GetFolderFiles(selectedPathTextBox.Text);
            // File list view manager
            filesListViewManager = new LinkedListManager<FileInfo>(IOHandler.Files);
            // Setup files list view
            DrawListView();
        }
    }

    private void OnCopyToClipboardButtonClick(object sender, EventArgs e)
    {
        Action copyToClipboard = () => Clipboard.SetText(selectedPathTextBox.Text);
        ExceptionHandler.HanldeWithMessageBox(
            copyToClipboard,
            successMessage: "Copied to clipboard"
        );
    }

    private void OnOpenInExplorerButtonClick(object sender, EventArgs e)
    {
        Action openInExplorer = () => Process.Start("explorer.exe", selectedPathTextBox.Text);
        ExceptionHandler.HanldeWithMessageBox(openInExplorer);
    }
    #endregion

    #region ListView controller buttons
    private void OnToTopButtonClick(object sender, EventArgs e)
    {
        MoveItem(MovementType.Top);
    }

    private void OnToBottomButtonClick(object sender, EventArgs e)
    {
        MoveItem(MovementType.Bottom);
    }

    private void OnUpButtonClick(object sender, EventArgs e)
    {
        MoveItem(MovementType.Up);
    }

    private void OnDownButtonClick(object sender, EventArgs e)
    {
        MoveItem(MovementType.Down);
    }

    private void OnRemoveButtonClick(object sender, EventArgs e)
    {
        int index = GetFilesListViewSelectedItem();
        // There is no selected item
        if (index == NONE_SELECTED)
        {
            return;
        }

        bool removed = filesListViewManager.RemoveAt(index);
        int newSelectedIndex = NONE_SELECTED;
        if (index < filesListView.Items.Count)
        {
            newSelectedIndex = index - 1;
        }

        if (removed)
        {
            DrawListView(newSelectedIndex);
        }
    }

    private void OnResetButtonClick(object sender, EventArgs e)
    {
        var result = MessageBox.Show(
            "Are you sure?",
            "Reset",
            MessageBoxButtons.OKCancel,
            MessageBoxIcon.Warning
        );

        if (result == DialogResult.Cancel)
        {
            return;
        }

        filesListViewManager.Reset(IOHandler.Files);
        DrawListView();
    }
    #endregion

    #region Events
    private async void OnRenameButtonClick(object sender, EventArgs e)
    {
        await Task.Run(Rename);
        // Disable buttons
        SetButtonsEnabledValue(false);
        // Redraw files list view
        DrawListView();
    }

    private void Rename()
    {
        var oldNames = filesListViewManager.Items.Select(item => item.FullName).ToList();

        _ = int.TryParse(startNumberTextBox.Text, out int startFrom);
        int numberOfDigits = startNumberTextBox.Text.Length;

        var newNames = filesListViewManager.Items
            .Select(item =>
            {
                string directoryName = Path.GetDirectoryName(item.FullName);
                string newName =
                    renameToTextBox.Text
                    + startFrom++.ToString().PadLeft(numberOfDigits, '0')
                    + Path.GetExtension(item.FullName);

                return Path.Combine(directoryName, newName);
            })
            .ToList();
        // Rename files
        List<string> errors = new();
        int progress = 0;
        foreach (var item in IOHandler.MoveFiles(oldNames, newNames))
        {
            if (item.Status == "Error")
            {
                errors.Add(item.Message);
            }

            progress++;
            UpdateProgressBar(progress / oldNames.Count * 100);
        }

        // Clear files
        IOHandler.Clear();
        filesListViewManager.Clear();

        if (errors.Count == 0)
        {
            MessageBox.Show(
                "Files reanmed successfully",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
            return;
        }

        MessageBox.Show(
            "Files reanmed with errors\n" + JsonSerializer.Serialize(errors),
            "Error",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error
        );
    }

    private void OnTextBoxLeave(object sender, EventArgs e)
    {
        DrawListView();
    }

    private void OnStartNumberTextBoxKeyDown(object sender, KeyEventArgs e)
    {
        // Allow only digits
        if (char.IsDigit((char)e.KeyCode) || e.KeyCode == Keys.Back)
        {
            return;
        }

        if (
            e.KeyCode == Keys.Left
            || e.KeyCode == Keys.Right
            || e.KeyCode == Keys.Home
            || e.KeyCode == Keys.End
            || e.KeyCode == Keys.NumPad0
            || e.KeyCode == Keys.NumPad1
            || e.KeyCode == Keys.NumPad2
            || e.KeyCode == Keys.NumPad3
            || e.KeyCode == Keys.NumPad4
            || e.KeyCode == Keys.NumPad5
            || e.KeyCode == Keys.NumPad6
            || e.KeyCode == Keys.NumPad7
            || e.KeyCode == Keys.NumPad8
            || e.KeyCode == Keys.NumPad9
        )
        {
            return;
        }

        e.SuppressKeyPress = true;
    }

    private void OnSelectTypesToolStripMenuItemClick(object sender, EventArgs e)
    {
        SelectType selectType = new SelectType(OnFormSelectTypeIsClosed);
        selectType.FormClosed += (sender, e) => Console.WriteLine();
        selectType.Show();
    }

    private void OnFormSelectTypeIsClosed(object sender, CustomFormClosedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(e.SelectedExtension))
        {
            filesListViewManager.Reset(IOHandler.Files);
            return;
        }

        var extenstions = e.SelectedExtension.Split(',');

        filesListViewManager.Reset(
            filesListViewManager.Items.Where(
                file => extenstions.Contains(Path.GetExtension(file.FullName))
            )
        );

        DrawListView();
    }

    private void OnOpenFolderToolStripMenuItemClick(object sender, EventArgs e)
    {
        OnSelectFolderButtonClick(sender, e);
    }

    private void OnExitToolStripMenuItemClick(object sender, EventArgs e)
    {
        Close();
    }

    private void OnResetFiltersToolStripMenuItemClick(object sender, EventArgs e)
    {
        OnResetButtonClick(sender, e);
    }

    private void OnAboutToolStripMenuItemClick(object sender, EventArgs e)
    {
        MessageBox.Show(
            """
                Bulk files renamer

                This application can renames with incremental value
                Choose the name and the starting number and hit rename

                Enjoy ☺️
            """,
            "About",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information
        );
    }

    private void OnAppFormClosing(object sender, FormClosingEventArgs e)
    {
        if (!filesListViewManager?.Items?.Any() ?? true)
        {
            return;
        }

        var result = MessageBox.Show(
            "Are you sure?",
            "Exit",
            MessageBoxButtons.OKCancel,
            MessageBoxIcon.Information
        );

        if (result == DialogResult.Cancel)
        {
            e.Cancel = true;
        }
    }

    private void OnFilesListViewKeyDown(object sender, KeyEventArgs e)
    {
        switch (e.KeyData)
        {
            case Keys.F6:
                {
                    MoveItem(MovementType.Up);
                    break;
                }
            case Keys.F5:
                {
                    MoveItem(MovementType.Down);
                    break;
                }
            case Keys.F8:
                {
                    MoveItem(MovementType.Top);
                    break;
                }
            case Keys.F7:
                {
                    MoveItem(MovementType.Bottom);
                    break;
                }
            case Keys.Delete:
                {
                    OnRemoveButtonClick(null, EventArgs.Empty);
                    break;
                }
            default:
                break;
        }
    }
    #endregion

    #region Helpers
    private int GetFilesListViewSelectedItem()
    {
        if (filesListView.SelectedIndices.Count == 0)
        {
            return NONE_SELECTED;
        }

        return filesListView.SelectedIndices[0];
    }

    private void UpdateProgressBar(int value)
    {
        if (taskProgressBar.InvokeRequired)
        {
            taskProgressBar.Invoke(new MethodInvoker(() => taskProgressBar.Value = value));
        }
        else
        {
            taskProgressBar.Value = value;
        }
    }

    private void MoveItem(MovementType type)
    {
        int index = GetFilesListViewSelectedItem();
        // There is no selected item
        if (index == NONE_SELECTED)
        {
            return;
        }

        bool moved = false;
        int newSelectedIndex = NONE_SELECTED;

        switch (type)
        {
            case MovementType.Up:
                moved = filesListViewManager.MoveUp(index);
                newSelectedIndex = index - 1;
                break;
            case MovementType.Down:
                moved = filesListViewManager.MoveDown(index);
                newSelectedIndex = index + 1;
                break;
            case MovementType.Top:
                moved = filesListViewManager.MoveToTop(index);
                newSelectedIndex = 0;
                break;
            case MovementType.Bottom:
                moved = filesListViewManager.MoveToBottom(index);
                newSelectedIndex = filesListView.Items.Count - 1;
                break;
            default:
                break;
        }

        if (moved)
        {
            DrawListView(newSelectedIndex);
        }
    }

    private void DrawListView(int selectIndex = -1)
    {
        if (filesListViewManager.Items is null)
        {
            return;
        }

        filesListView.Items.Clear();
        _ = int.TryParse(startNumberTextBox.Text, out int currentNumber);
        int numberOfDigits = startNumberTextBox.Text.Length;

        foreach (var file in filesListViewManager.Items)
        {
            ListViewItem listViewItem = new() { Text = file.Name };

            string newName = GetFileNewName(currentNumber, numberOfDigits, file);
            currentNumber++;

            ListViewItem.ListViewSubItem fileReameItem = new(listViewItem, newName);
            listViewItem.SubItems.Add(fileReameItem);
            filesListView.Items.Add(listViewItem);
        }

        if (0 <= selectIndex)
        {
            filesListView.Items[selectIndex].Selected = true;
        }
    }

    private string GetFileNewName(int number, int numberOfDigits, FileInfo file)
    {
        return renameToTextBox.Text
            + number.ToString().PadLeft(numberOfDigits, '0')
            + Path.GetExtension(file.FullName);
    }

    private void SetButtonsEnabledValue(bool value)
    {
        copyToClipboardButton.Enabled = value;
        openInExplorerButton.Enabled = value;
        upButton.Enabled = value;
        downButton.Enabled = value;
        toBottomButton.Enabled = value;
        toTopButton.Enabled = value;
        resetButton.Enabled = value;
        removeButton.Enabled = value;
        renameButton.Enabled = value;
        editToolStripMenuItem.Enabled = value;
    }
    #endregion
}
