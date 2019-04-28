namespace FSL.FileSystem.Core.Repository
{
    public interface IDeleteRepository<TModel>
    {
        bool Delete(
            string id);
    }
}
