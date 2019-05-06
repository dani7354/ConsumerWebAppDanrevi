﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models.Course;
namespace ApiProxy.Contracts
{
    public interface ICourseApiProxy : IApiProxy
    {
       new IList<T> All<T>();
      new T Find<T>(int id);
      new void Create<T>(T article);
       new void Delete(int id);

        // Async
        Task<T> FindAsync<T>(int id) where T : CourseBase;
        Task<T> FindWithParticipantsAsync<T>(int id) where T : CourseBase;
        Task<IList<T>> AllAsync<T>() where T : CourseBase;
        Task CreateAsync<T>(T article) where T : CourseBase;
        Task UpdateAsync<T>(int id, T article) where T : CourseBase;
        Task DeleteAsync(int id);
    }
}