using DevFreela.Core.Enums;
using System;
using System.Collections.Generic;

namespace DevFreela.Core.Entities
{
    public class Project : BaseEntity
    {
        public Project(string title, string description, int idClient, int idFreelancer, decimal totalCoast)
        {
            Title = title;
            Description = description;
            IdClient = idClient;
            IdFreelancer = idFreelancer;
            TotalCoast = totalCoast;
            CreatedAt = DateTime.Now;
            Status = EProjectStatusEnum.Created;
            Comments = new List<ProjectComment>();
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public int IdClient { get; private set; }
        public User Client { get; private set; }
        public int IdFreelancer { get; private set; }
        public User Freelancer { get; private set; }
        public decimal TotalCoast { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? StartedAt { get; private set; }
        public DateTime? FinishedAt { get; private set; }
        public EProjectStatusEnum Status { get; private set; }
        public List<ProjectComment> Comments { get; private set; }

        public void Update(string title, string description, decimal totalCoats)
        {
            Title = title;
            Description = description;
            TotalCoast = totalCoats;
        }

        public void Start()
        {
            if (Status == EProjectStatusEnum.Created)
            {
                Status = EProjectStatusEnum.InProgress;
                StartedAt = DateTime.Now;
            }
        }

        public void Finish()
        {
            if (Status == EProjectStatusEnum.InProgress)
            {
                Status = EProjectStatusEnum.Finished;
                FinishedAt = DateTime.Now;
            }
        }

        public void Cancel()
        {
            if (Status == EProjectStatusEnum.InProgress || Status == EProjectStatusEnum.InProgress) Status = EProjectStatusEnum.Cancelled;
        }
    }
}