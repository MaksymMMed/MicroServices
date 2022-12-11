using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Realization
{
    public class IssueRepository : GenericRepository<Issue>,IIssueRepository
    {
        public IssueRepository(UnitContext databaseContext, IMemoryCache memoryCache) : base(databaseContext, memoryCache)
        {
        }

        public override Task<Issue> GetCompleteEntityAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
