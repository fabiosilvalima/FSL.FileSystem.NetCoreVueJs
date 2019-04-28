using System;

namespace FSL.FileSystem.Core.Formatter
{
    public static class FormatterFactory
    {
        public static IFileSystemFormatter CreateInstance(
            string formatterName = null)
        {
            formatterName = formatterName ?? "Default";

            var type = Type.GetType($"FSL.FileSystem.Core.Formatter.{formatterName}FileSystemFormatter");

            return Activator.CreateInstance(type) as IFileSystemFormatter;
        }
    }
}
