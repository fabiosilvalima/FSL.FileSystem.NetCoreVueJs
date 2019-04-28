using System.Collections.Generic;

namespace FSL.FileSystem.Core.Repository
{
    public interface ISelectRepository<TModel>
    {
        TModel SelectOne(
            string id);

        IEnumerable<TModel> SelectMany(
            string id);
    }
}
