namespace BulkFilesRenamer.Helpers;

class ExceptionHandler
{
    public static void HanldeWithMessageBox(Delegate method, string successMessage = "")
    {
        try
        {
            method.DynamicInvoke();
            if (!string.IsNullOrWhiteSpace(successMessage))
            {
                MessageBox.Show(
                    successMessage,
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
