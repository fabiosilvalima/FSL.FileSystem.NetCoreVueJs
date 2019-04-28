using FSL.FileSystem.Core.Formatter;
using FSL.FileSystem.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FSL.FileSystem.Core.Service
{
    public interface IFileSystemService
    {
        IEnumerable<FileSystemObject> GetAllFileSystemObject(
            string fullName);

        object ToJson(
            IEnumerable<FileSystemObject> objs,
            IFileSystemFormatter fileSystemFormatter = null);

        bool DirectoryExists(
            string fullName);
    }
}
