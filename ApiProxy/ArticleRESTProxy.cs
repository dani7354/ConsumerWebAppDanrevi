using System;
using System.Collections.Generic;
using System.Text;
using ApiProxy.Contracts;
using Domain;

namespace ApiProxy
{
    class ArticleRestProxy : IArticleApiProxy<ArticleBase>
    {
        private string _baseEndpoint;
        public ArticleRestProxy(string baseEndpoint)
        {
            _baseEndpoint = baseEndpoint;
        }
        public IList<ArticleBase> All<T>()
        {
            return null;
        }

        public void Create<T>(ArticleBase article)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ArticleBase Find<T>(int id)
        {
            throw new NotImplementedException();
        }
    }
}
