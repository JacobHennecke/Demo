using Demo_project.Domain.Interfaces;
using Demo_project.Domain.Models;
using Demo_project.Infrastructure.DataSources;

namespace Demo_project.Application.Services
{
    public class ContentDistributionService
    {
        private readonly IDataRepository<ContentDistribution, ContentDistribution> repository;

        public ContentDistributionService(IDataRepository<ContentDistribution, ContentDistribution> repository)
        {
            this.repository = repository;
        }

        public ContentDistribution GetAllContentDistributions()
        {
            return repository.GetAll();
        }

        public ContentDistribution GetContentDistributionById(string id)
        {
            return repository.GetById(id);
        }

        public void AddContentDistribution(ContentDistribution ContentDistribution)
        {
            repository.Add(ContentDistribution);
        }

        public void UpdateContentDistribution(ContentDistribution ContentDistribution)
        {
            repository.Update(ContentDistribution);
        }

        public void DeleteContentDistribution(string id)
        {
            repository.Delete(id);
        }
    }
}
