using BulkFilesRenamer.Helpers;

namespace BulkFilesRenamer.Forms
{
    public partial class SelectType : Form
    {
        public new EventHandler<CustomFormClosedEventArgs> OnFormClosed { get; set; }

        public SelectType(EventHandler<CustomFormClosedEventArgs> onFormClosed)
        {
            InitializeComponent();
            OnFormClosed = onFormClosed ?? throw new ArgumentNullException(nameof(onFormClosed));
            FormClosed += AfterFormClosed;
        }

        private void OnConfirmSelectButtonClick(object sender, EventArgs e) => Close();

        private void OnExtensionTextBoxKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Close();
            }
        }

        private void AfterFormClosed(object sender, FormClosedEventArgs e)
        {
            OnFormClosed(
                this,
                new CustomFormClosedEventArgs(CloseReason.None)
                {
                    SelectedExtension = extensionTextBox.Text
                }
            );
        }
    }
}

