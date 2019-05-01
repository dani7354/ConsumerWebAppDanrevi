﻿using System;
using System.Collections.Generic;
using System.Security;
using System.Text;
using Domain;

namespace ApiProxy.Contracts
{
    public interface IArticleApiProxy : IApiProxy
    {
        new T Find<T>(int id) where T : ArticleBase;
        new IList<T> All<T>() where T : ArticleBase;
        new void Create<T>(T article) where T : ArticleBase;
        IList<T> GetByTag<T>(string tag);

    }
}
