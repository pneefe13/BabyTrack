﻿using Microsoft.Win32;
using System.IO;

namespace Frontend.Services;
public class FileService : IFileService
{
    public string? LoadFromFile()
    {
        var dialog = new OpenFileDialog();
        dialog.Filter = "BabyTrack save data (.btsv)|*.btsv"; // todo more generic?
        dialog.DefaultExt = ".btsv";

        var result = dialog.ShowDialog();
        if (result == true)
        {
            var fileName = dialog.FileName;
            var content = File.ReadAllText(fileName);
            return content;
        }

        return null;
    }

    public bool SaveToFile(string content)
    {
        var dialog = new SaveFileDialog();
        dialog.Filter = "BabyTrack save data (.btsv)|*.btsv"; // todo more generic?
        dialog.DefaultExt = ".btsv";

        var result = dialog.ShowDialog();
        if (result == true)
        {
            var fileName = dialog.FileName;
            File.WriteAllText(fileName, content);
            return true;
        }

        return false;
    }
}
