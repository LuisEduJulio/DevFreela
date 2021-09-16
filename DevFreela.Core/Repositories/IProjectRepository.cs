using DevFreela.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevFreela.Core.Repositories
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAll();

        Task<Project> GetById(int id);

        Task AddAsync(Project project);

        void Update(Project project);

        void Delete(int id);

        Task StartAsync(int id);
    }
}