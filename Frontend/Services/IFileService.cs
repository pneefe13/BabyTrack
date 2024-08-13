namespace Frontend.Services;

public interface IFileService
{
    public bool SaveToFile(byte[] content);

    public byte[]? LoadFromFile();
}
