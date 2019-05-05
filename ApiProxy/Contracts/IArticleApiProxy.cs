using System;
using System.Collections.Generic;
using System.Security;
using System.Text;
using Models.Article;

namespace ApiProxy.Contracts
{
    public interface IArticleApiProxy : IApiProxy
    {
        new T Find<T>(int id) where T : ArticleBase;
        new IList<T> All<T>() where T : ArticleBase;
        new void Create<T>(T article) where T : ArticleBase;

        void Update<T>(int id, T article);
        IList<T> GetByTag<T>(string tag);

    }
}
