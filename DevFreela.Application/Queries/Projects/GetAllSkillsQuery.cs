using DevFreela.Application.ViewModels;
using MediatR;
using System.Collections.Generic;

namespace DevFreela.Application.Queries.Projects
{
    public class GetAllSkillsQuery : IRequest<List<SkillViewModel>>
    {
        //public GetAllSkillsQuery(string query)
        //{
        //    Query = query;
        //}

        //public string Query { get; private set; }
    }
}