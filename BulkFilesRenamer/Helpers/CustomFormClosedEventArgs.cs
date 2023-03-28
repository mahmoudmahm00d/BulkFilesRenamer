namespace BulkFilesRenamer.Helpers
{
    public class CustomFormClosedEventArgs : FormClosedEventArgs
    {
        public string SelectedExtension { get; set; }

        public CustomFormClosedEventArgs(CloseReason closeReason) : base(closeReason) { }
    }
}

