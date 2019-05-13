using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models.Course;
namespace ApiProxy.Contracts
{
    public interface ICourseApiProxy 
    {

        // Async
        Task<T> FindAsync<T>(int id) where T : CourseBase;
        Task<T> FindWithParticipantsAsync<T>(int id, string apiToken) where T : CourseBase;
        Task<IList<T>> AllAsync<T>() where T : CourseBase;
        Task CreateAsync<T>(T article, string apiToken) where T : CourseBase;
        Task UpdateAsync<T>(int id, T article, string apiToken) where T : CourseBase;
        Task DeleteAsync(int id, string apiToken);
        Task DeleteParticipantAsync(int courseId, string participantEmail, string apiToken);
        Task AddParticipantAsync(int courseId, string participantEmail, string apiToken);
    }
}
