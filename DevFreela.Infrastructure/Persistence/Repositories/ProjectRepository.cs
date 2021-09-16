using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DevFreelaDbContext _dbContext;
        private readonly string _connectionString;

        public ProjectRepository(DevFreelaDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("DevFreelaCs");
        }

        public async Task<List<Project>> GetAll()
        {
            return await _dbContext.Projects.ToListAsync();
        }

        public async Task<Project> GetById(int id)
        {
            return await _dbContext
                .Projects
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(Project project)
        {
            await _dbContext.Projects.AddAsync(project);

            await _dbContext.SaveChangesAsync();
        }

        public void Update(Project project)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task StartAsync(int id)
        {
            var project = await _dbContext.Projects.SingleOrDefaultAsync(p => p.Id == id);

            project.Start();

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = @"UPDATE Projects " +
                    "SET " +
                    "Status = @status, " +
                    "StartedAt = @startedat" +
                    "WHERE" +
                    "Id = @id";

                //sqlConnection.Execute(script, new
                //{
                //    status = project.Status,
                //    startedat = project.StartedAt,
                //    id
                //});
            }
        }
    }
}