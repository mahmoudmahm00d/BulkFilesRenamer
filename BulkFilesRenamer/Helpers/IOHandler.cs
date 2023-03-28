namespace BulkFilesRenamer.Helpers;

interface IIOHandler
{
    FileInfo[] Files { get; }
    Stream OpenFileRead(string path);
    DirectoryInfo OpenFolder(string path);
    void GetFolderFiles(string path);
    void MoveFile(string oldPath, string newPath);
    IEnumerable<StatusMessage> MoveFiles(IList<string> oldNames, IList<string> newNames);
    void Clear();
}

class IOHandler : IIOHandler
{
    private FileInfo[] files;

    public IOHandler() { }

    public FileInfo[] Files
    {
        get => files;
    }

    public void MoveFile(string oldPath, string newPath)
    {
        if (string.IsNullOrWhiteSpace(oldPath))
        {
            throw new ArgumentException(
                $"'{nameof(oldPath)}' cannot be null or whitespace.",
                nameof(oldPath)
            );
        }

        if (string.IsNullOrWhiteSpace(newPath))
        {
            throw new ArgumentException(
                $"'{nameof(newPath)}' cannot be null or whitespace.",
                nameof(newPath)
            );
        }

        try
        {
            File.Move(oldPath, newPath);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public Stream OpenFileRead(string path)
    {
        if (string.IsNullOrWhiteSpace(path))
        {
            throw new ArgumentException(
                $"'{nameof(path)}' cannot be null or whitespace.",
                nameof(path)
            );
        }

        return File.Open(path, FileMode.Open);
    }

    public DirectoryInfo OpenFolder(string path)
    {
        if (string.IsNullOrWhiteSpace(path))
        {
            throw new ArgumentException(
                $"'{nameof(path)}' cannot be null or whitespace.",
                nameof(path)
            );
        }

        return new DirectoryInfo(path);
    }

    public void GetFolderFiles(string path)
    {
        files = new DirectoryInfo(path).GetFiles();
    }

    public IEnumerable<StatusMessage> MoveFiles(IList<string> oldNames, IList<string> newNames)
    {
        if (oldNames is null)
        {
            throw new ArgumentNullException(nameof(oldNames));
        }

        if (newNames is null)
        {
            throw new ArgumentNullException(nameof(newNames));
        }

        if (oldNames.Count != newNames.Count)
        {
            throw new ArgumentException(
                $"{nameof(oldNames)} items count must be equals to {nameof(newNames)} items count"
            );
        }

        for (int i = 0; i < oldNames.Count; i++)
        {
            if (!File.Exists(oldNames[i]))
            {
                yield return new StatusMessage("Error", $"{oldNames[i]} not exists");
                continue;
            }

            Exception exception = null;
            try
            {
                File.Move(oldNames[i], newNames[i]);
            }
            catch (Exception e)
            {
                exception = e;
            }

            if (exception is null)
            {
                yield return new StatusMessage("Success", "Renamed Successfully");
                continue;
            }

            yield return new StatusMessage(
                "Error",
                $"{oldNames[i]} made the error:\n{exception.Message}"
            );
        }

        yield return new StatusMessage("Success", "Done");
    }

    public void Clear()
    {
        files = null;
    }
}

internal record StatusMessage(string Status, string Message);
