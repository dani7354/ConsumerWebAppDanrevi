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
        new T Find<T>(int id) where T : ArticleBase;
        new IList<T> All<T>() where T : ArticleBase;
        new void Create<T>(T article) where T : ArticleBase;
        void Update<T>(int id, T article) where T : ArticleBase;
        IList<T> GetByTag<T>(string tag);

        // Async methods


        Task<T> FindAsync<T>(int id) where T : ArticleBase;
        Task<IList<T>> AllAsync<T>() where T : ArticleBase;
        Task CreateAsync<T>(T article) where T : ArticleBase;
        Task UpdateAsync<T>(int id, T article) where T : ArticleBase;
        Task<IList<T>> GetByTagAsync<T>(string tag);
        Task DeleteAsync(int id);
    }
}
