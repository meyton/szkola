using System;
using System.IO;

namespace App1.Services.Interfaces
{
    public interface IFileHelper
    {
        string GetLocalFilepath(string filename);
        string SaveImageLocally(Stream imageStream);
    }
}
