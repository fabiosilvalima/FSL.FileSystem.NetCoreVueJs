namespace FSL.FileSystem.Core.Repository
{
    public interface IFileSystemRepository :
        ISelectRepository<Models.FileSystemObject>,
        IDeleteRepository<Models.FileSystemObject>
    {
        bool Exists(
            string fullName);
    }
}
