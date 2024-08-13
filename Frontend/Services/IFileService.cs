namespace Frontend.Services;

public interface IFileService
{
    public bool SaveToFile(string content);

    public string? LoadFromFile();
}
