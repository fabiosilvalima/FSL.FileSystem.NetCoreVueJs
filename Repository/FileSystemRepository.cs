using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FSL.FileSystem.Core.Extensions;
using FSL.FileSystem.Core.Models;

namespace FSL.FileSystem.Core.Repository
{
    public sealed class FileSystemRepository :
        IFileSystemRepository
    {
        public IEnumerable<FileSystemObject> SelectMany(
            string id)
        {
            id = id ?? Environment.CurrentDirectory;

            var objs = new List<FileSystemObject>();

            if (Directory.Exists(id))
            {
                foreach (DirectoryInfo directoryInfo in new DirectoryInfo(id).GetDirectories().AsParallel())
                {
                    var obj = SelectOneDirectoryInfo(
                        directoryInfo);

                    objs.AddIfNotNull(obj);
                }

                foreach (FileInfo fileInfo in new DirectoryInfo(id).GetFiles().AsParallel())
                {
                    var obj = SelectOneFileInfo(
                        fileInfo);

                    objs.AddIfNotNull(obj);
                }
            }

            return objs;
        }

        public FileSystemObject SelectOne(
            string id)
        {
            var obj = SelectOneFileInfo(
                new FileInfo(id));

            if (obj == null)
            {
                obj = SelectOneDirectoryInfo(
                    new DirectoryInfo(id));
            }

            return obj;
        }

        public bool Delete(
            string id)
        {
            var obj = SelectOneFileInfo(
                new FileInfo(id));

            if (obj == null)
            {
                obj = SelectOneDirectoryInfo(
                    new DirectoryInfo(id));

                if (obj != null)
                {
                    Directory.Delete(id);
                }
            }
            else
            {
                File.Delete(id);

                return true;
            }

            return false;
        }

        public bool Exists(
          string fullName)
        {
            if (!Directory.Exists(fullName))
                return false;

            return true;
        }

        private FileSystemObject SelectOneDirectoryInfo(
            DirectoryInfo info)
        {
            if (info == null)
                return null;

            var obj = SelectOneFileSystemInfo(
                info);

            obj.IsFile = false;

            try
            {
                obj.HasChilds = (Directory.GetDirectories(info.FullName).Length + Directory.GetFiles(info.FullName).Length) > 0;
            }
            catch
            {

            }

            return obj;
        }

        private FileSystemObject SelectOneFileSystemInfo(
            FileSystemInfo info)
        {
            if (info == null)
                return null;

            var obj = new FileSystemObject
            {
                Name = Path.GetFileName(info.FullName),
                Id = info.FullName,
                HasChilds = false,
                IsFile = true,
                CreationTime = info.CreationTime,
                LastWriteTime = info.LastWriteTime,
                Extension = Path.GetExtension(info.FullName) ?? ""
            };

            return obj;
        }

        private FileSystemObject SelectOneFileInfo(
            FileInfo info)
        {
            if (info == null)
                return null;

            var obj = SelectOneFileSystemInfo(
                info);

            obj.Size = info.Length;

            return obj;
        }


    }
}
