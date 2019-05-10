using System;
using System.Collections.Generic;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Models.Article;

namespace ApiProxy.Contracts
{
    public interface IArticleApiProxy : IApiProxy
    {

        // Async methods


        Task<T> FindAsync<T>(int id) where T : ArticleBase;
        Task<IList<T>> AllAsync<T>() where T : ArticleBase;
        Task CreateAsync<T>(T article) where T : ArticleBase;
        Task UpdateAsync<T>(int id, T article) where T : ArticleBase;
        Task<IList<T>> GetByTagAsync<T>(string tag);
        Task DeleteAsync(int id);
    }
}
