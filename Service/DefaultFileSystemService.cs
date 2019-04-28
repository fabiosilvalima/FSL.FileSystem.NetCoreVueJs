using FSL.FileSystem.Core.Formatter;
using FSL.FileSystem.Core.Models;
using FSL.FileSystem.Core.Repository;
using System.Collections.Generic;
using System.Linq;

namespace FSL.FileSystem.Core.Service
{
    public sealed class DefaultFileSystemService :
        IFileSystemService
    {
        private readonly IFileSystemRepository _fileSystemRepository;

        public DefaultFileSystemService(
            IFileSystemRepository fileSystemRepository)
        {
            _fileSystemRepository = fileSystemRepository;
        }

        public IEnumerable<FileSystemObject> GetAllFileSystemObject(
            string fullName)
        {
            var objs = _fileSystemRepository.SelectMany(
                fullName)
                .ToList();

            if (objs.Any())
                objs.OrderBy(obj => obj.IsFile.ToString());

            return objs;
        }

        public object ToJson(
            IEnumerable<FileSystemObject> objs,
            IFileSystemFormatter fileSystemFormatter = null)
        {
            fileSystemFormatter = fileSystemFormatter ?? FormatterFactory.CreateInstance();

            return fileSystemFormatter.ToJson(
                objs);
        }

        public bool DirectoryExists(
            string fullName)
        {
            var result = _fileSystemRepository.Exists(
                fullName);

            return result;
        }
    }
}
