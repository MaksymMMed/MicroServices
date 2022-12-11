using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly UnitContext consumersContext;

        public UnitOfWork(UnitContext consumersContext,
            IConsumerRepository consumerRepository,
            IUnitRepository unitRepository,
            IEnergyConsumeRepository energyConsume,
            IIssueRepository issueRepository)
        {
            this.consumersContext = consumersContext;
            this.consumerRepository = consumerRepository;
            this.unitRepository = unitRepository;
            this.energyConsumeRepository = energyConsume;
            this.issueRepository = issueRepository;
        }

        public IConsumerRepository consumerRepository { get;}

        public IUnitRepository unitRepository { get; }

        public IEnergyConsumeRepository energyConsumeRepository { get; }

        public IIssueRepository issueRepository { get; }

        public async Task SaveChangesAsync()
        {
           await consumersContext.SaveChangesAsync();    
        }
    }
}
