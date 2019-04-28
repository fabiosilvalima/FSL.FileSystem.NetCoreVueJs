using System;

namespace FSL.FileSystem.Core.Models
{
    public class FileSystemObject
    {
        public DateTime? CreationTime { get; set; }
        public DateTime? LastWriteTime { get; set; }
        public long? Size { get; set; }
        public bool? HasChilds { get; set; }
        public bool? IsFile { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public string ImageRuntimeVersion { get; set; }
        public string Compilation { get; set; }
        public string Extension { get; set;}
    }
}
