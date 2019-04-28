using FSL.FileSystem.Core.Models;
using System.Collections.Generic;

namespace FSL.FileSystem.Core.Extensions
{
    public static class FileSystemExtension
    {
        public static void AddIfNotNull(
            this List<FileSystemObject> objs,
            FileSystemObject obj)
        {
            if (objs == null || obj == null)
                return;

            objs.Add(obj);
        }
    }
}
