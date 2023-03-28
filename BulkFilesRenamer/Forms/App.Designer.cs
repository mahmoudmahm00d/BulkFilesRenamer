namespace BulkFilesRenamer.Forms
{
    partial class App
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
            selectPathButton = new Button();
            selectedPathTextBox = new TextBox();
            copyToClipboardButton = new Button();
            openInExplorerButton = new Button();
            filesListView = new ListView();
            fileNameColumnHeader = new ColumnHeader();
            fileRenamedColumnHeader = new ColumnHeader();
            taskProgressBar = new ProgressBar();
            renameToTextBox = new TextBox();
            startNumberTextBox = new TextBox();
            renameButton = new Button();
            toTopButton = new Button();
            upButton = new Button();
            downButton = new Button();
            toBottomButton = new Button();
            removeButton = new Button();
            resetButton = new Button();
            defaultMenuStrip = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openFolderToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            selectTypesToolStripMenuItem = new ToolStripMenuItem();
            resetFiltersToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            defaultMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // selectPathButton
            // 
            selectPathButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            selectPathButton.Location = new Point(626, 31);
            selectPathButton.Name = "selectPathButton";
            selectPathButton.Size = new Size(80, 30);
            selectPathButton.TabIndex = 0;
            selectPathButton.Text = "Select Path";
            selectPathButton.UseVisualStyleBackColor = true;
            selectPathButton.Click += OnSelectFolderButtonClick;
            // 
            // selectedPathTextBox
            // 
            selectedPathTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            selectedPathTextBox.Location = new Point(12, 36);
            selectedPathTextBox.Name = "selectedPathTextBox";
            selectedPathTextBox.ReadOnly = true;
            selectedPathTextBox.Size = new Size(536, 23);
            selectedPathTextBox.TabIndex = 50;
            selectedPathTextBox.Text = "Selected path will show here";
            // 
            // copyToClipboardButton
            // 
            copyToClipboardButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            copyToClipboardButton.Enabled = false;
            copyToClipboardButton.Image = Properties.Resources.clipboard_fill__Icon_;
            copyToClipboardButton.Location = new Point(590, 31);
            copyToClipboardButton.Name = "copyToClipboardButton";
            copyToClipboardButton.Size = new Size(30, 30);
            copyToClipboardButton.TabIndex = 1;
            copyToClipboardButton.UseVisualStyleBackColor = true;
            copyToClipboardButton.Click += OnCopyToClipboardButtonClick;
            // 
            // openInExplorerButton
            // 
            openInExplorerButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            openInExplorerButton.Enabled = false;
            openInExplorerButton.Image = Properties.Resources.folder_open_fill__Icon_;
            openInExplorerButton.Location = new Point(554, 31);
            openInExplorerButton.Name = "openInExplorerButton";
            openInExplorerButton.Size = new Size(30, 30);
            openInExplorerButton.TabIndex = 2;
            openInExplorerButton.UseVisualStyleBackColor = true;
            openInExplorerButton.Click += OnOpenInExplorerButtonClick;
            // 
            // filesListView
            // 
            filesListView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            filesListView.Columns.AddRange(new ColumnHeader[] { fileNameColumnHeader, fileRenamedColumnHeader });
            filesListView.Location = new Point(12, 101);
            filesListView.MultiSelect = false;
            filesListView.Name = "filesListView";
            filesListView.Size = new Size(694, 350);
            filesListView.TabIndex = 9;
            filesListView.UseCompatibleStateImageBehavior = false;
            filesListView.View = View.Details;
            filesListView.KeyDown += OnFilesListViewKeyDown;
            // 
            // fileNameColumnHeader
            // 
            fileNameColumnHeader.Text = "File Name";
            fileNameColumnHeader.Width = 360;
            // 
            // fileRenamedColumnHeader
            // 
            fileRenamedColumnHeader.Text = "New File Name";
            fileRenamedColumnHeader.Width = 300;
            // 
            // taskProgressBar
            // 
            taskProgressBar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            taskProgressBar.Location = new Point(12, 498);
            taskProgressBar.Name = "taskProgressBar";
            taskProgressBar.Size = new Size(694, 23);
            taskProgressBar.TabIndex = 3;
            // 
            // renameToTextBox
            // 
            renameToTextBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            renameToTextBox.Location = new Point(12, 469);
            renameToTextBox.Name = "renameToTextBox";
            renameToTextBox.Size = new Size(465, 23);
            renameToTextBox.TabIndex = 10;
            renameToTextBox.Text = "Rename to ";
            renameToTextBox.Leave += OnTextBoxLeave;
            // 
            // startNumberTextBox
            // 
            startNumberTextBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            startNumberTextBox.Location = new Point(483, 469);
            startNumberTextBox.Name = "startNumberTextBox";
            startNumberTextBox.Size = new Size(137, 23);
            startNumberTextBox.TabIndex = 11;
            startNumberTextBox.Text = "01";
            startNumberTextBox.KeyDown += OnStartNumberTextBoxKeyDown;
            startNumberTextBox.Leave += OnTextBoxLeave;
            // 
            // renameButton
            // 
            renameButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            renameButton.Enabled = false;
            renameButton.Location = new Point(626, 467);
            renameButton.Name = "renameButton";
            renameButton.Size = new Size(80, 25);
            renameButton.TabIndex = 12;
            renameButton.Text = "Rename";
            renameButton.UseVisualStyleBackColor = true;
            renameButton.Click += OnRenameButtonClick;
            // 
            // toTopButton
            // 
            toTopButton.BackgroundImageLayout = ImageLayout.Center;
            toTopButton.Enabled = false;
            toTopButton.Image = Properties.Resources.arrow_line_up_fill__Icon_;
            toTopButton.Location = new Point(16, 65);
            toTopButton.Name = "toTopButton";
            toTopButton.Size = new Size(30, 30);
            toTopButton.TabIndex = 3;
            toTopButton.UseVisualStyleBackColor = true;
            toTopButton.Click += OnToTopButtonClick;
            // 
            // upButton
            // 
            upButton.BackgroundImageLayout = ImageLayout.Center;
            upButton.Enabled = false;
            upButton.Image = Properties.Resources.arrow_up_fill__Icon_;
            upButton.Location = new Point(52, 65);
            upButton.Name = "upButton";
            upButton.Size = new Size(30, 30);
            upButton.TabIndex = 4;
            upButton.UseVisualStyleBackColor = true;
            upButton.Click += OnUpButtonClick;
            // 
            // downButton
            // 
            downButton.Enabled = false;
            downButton.Image = Properties.Resources.arrow_down_fill__Icon_;
            downButton.Location = new Point(88, 65);
            downButton.Name = "downButton";
            downButton.Size = new Size(30, 30);
            downButton.TabIndex = 5;
            downButton.UseVisualStyleBackColor = true;
            downButton.Click += OnDownButtonClick;
            // 
            // toBottomButton
            // 
            toBottomButton.Enabled = false;
            toBottomButton.Image = Properties.Resources.arrow_line_down_fill__Icon_;
            toBottomButton.Location = new Point(124, 65);
            toBottomButton.Name = "toBottomButton";
            toBottomButton.Size = new Size(30, 30);
            toBottomButton.TabIndex = 6;
            toBottomButton.UseVisualStyleBackColor = true;
            toBottomButton.Click += OnToBottomButtonClick;
            // 
            // removeButton
            // 
            removeButton.Enabled = false;
            removeButton.Image = Properties.Resources.file_minus_fill__Icon_;
            removeButton.Location = new Point(160, 65);
            removeButton.Name = "removeButton";
            removeButton.Size = new Size(30, 30);
            removeButton.TabIndex = 7;
            removeButton.UseVisualStyleBackColor = true;
            removeButton.Click += OnRemoveButtonClick;
            // 
            // resetButton
            // 
            resetButton.Enabled = false;
            resetButton.Image = Properties.Resources.arrow_counter_clockwise_fill__Icon_;
            resetButton.Location = new Point(196, 65);
            resetButton.Name = "resetButton";
            resetButton.Size = new Size(30, 30);
            resetButton.TabIndex = 8;
            resetButton.UseVisualStyleBackColor = true;
            resetButton.Click += OnResetButtonClick;
            // 
            // defaultMenuStrip
            // 
            defaultMenuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem, aboutToolStripMenuItem });
            defaultMenuStrip.Location = new Point(0, 0);
            defaultMenuStrip.Name = "defaultMenuStrip";
            defaultMenuStrip.Size = new Size(718, 24);
            defaultMenuStrip.TabIndex = 4;
            defaultMenuStrip.Text = "defaultMenuStrip";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openFolderToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "&File";
            // 
            // openFolderToolStripMenuItem
            // 
            openFolderToolStripMenuItem.Name = "openFolderToolStripMenuItem";
            openFolderToolStripMenuItem.Size = new Size(139, 22);
            openFolderToolStripMenuItem.Text = "&Open Folder";
            openFolderToolStripMenuItem.Click += OnOpenFolderToolStripMenuItemClick;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(139, 22);
            exitToolStripMenuItem.Text = "&Exit";
            exitToolStripMenuItem.Click += OnExitToolStripMenuItemClick;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { selectTypesToolStripMenuItem, resetFiltersToolStripMenuItem });
            editToolStripMenuItem.Enabled = false;
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(39, 20);
            editToolStripMenuItem.Text = "&Edit";
            // 
            // selectTypesToolStripMenuItem
            // 
            selectTypesToolStripMenuItem.Name = "selectTypesToolStripMenuItem";
            selectTypesToolStripMenuItem.Size = new Size(137, 22);
            selectTypesToolStripMenuItem.Text = "&Select Types";
            selectTypesToolStripMenuItem.Click += OnSelectTypesToolStripMenuItemClick;
            // 
            // resetFiltersToolStripMenuItem
            // 
            resetFiltersToolStripMenuItem.Name = "resetFiltersToolStripMenuItem";
            resetFiltersToolStripMenuItem.Size = new Size(137, 22);
            resetFiltersToolStripMenuItem.Text = "&Reset filters";
            resetFiltersToolStripMenuItem.Click += OnResetFiltersToolStripMenuItemClick;
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(52, 20);
            aboutToolStripMenuItem.Text = "&About";
            aboutToolStripMenuItem.Click += OnAboutToolStripMenuItemClick;
            // 
            // App
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(718, 533);
            Controls.Add(taskProgressBar);
            Controls.Add(filesListView);
            Controls.Add(startNumberTextBox);
            Controls.Add(renameToTextBox);
            Controls.Add(selectedPathTextBox);
            Controls.Add(resetButton);
            Controls.Add(removeButton);
            Controls.Add(toBottomButton);
            Controls.Add(downButton);
            Controls.Add(upButton);
            Controls.Add(toTopButton);
            Controls.Add(openInExplorerButton);
            Controls.Add(copyToClipboardButton);
            Controls.Add(renameButton);
            Controls.Add(selectPathButton);
            Controls.Add(defaultMenuStrip);
            KeyPreview = true;
            MainMenuStrip = defaultMenuStrip;
            MinimumSize = new Size(512, 512);
            Name = "App";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bulk Files Renamer";
            FormClosing += OnAppFormClosing;
            defaultMenuStrip.ResumeLayout(false);
            defaultMenuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button selectPathButton;
        private TextBox selectedPathTextBox;
        private Button copyToClipboardButton;
        private Button openInExplorerButton;
        private ListView filesListView;
        private ProgressBar taskProgressBar;
        private TextBox renameToTextBox;
        private TextBox startNumberTextBox;
        private Button renameButton;
        private ColumnHeader fileNameColumnHeader;
        private Button toTopButton;
        private Button upButton;
        private Button downButton;
        private Button toBottomButton;
        private Button removeButton;
        private Button resetButton;
        private MenuStrip defaultMenuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openFolderToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem selectTypesToolStripMenuItem;
        private ToolStripMenuItem resetFiltersToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ColumnHeader fileRenamedColumnHeader;
    }
}