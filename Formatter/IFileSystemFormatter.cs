using FSL.FileSystem.Core.Models;
using System.Collections.Generic;

namespace FSL.FileSystem.Core.Formatter
{
    public interface IFileSystemFormatter
    {
        object ToJson(
            IEnumerable<FileSystemObject> fileSystemObjects);
    }
}
