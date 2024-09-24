using Demo_project.Domain.Interfaces;
using Demo_project.Domain.Models;
using Demo_project.Infrastructure.DataSources;

namespace Demo_project.Application.Services
{
    public class BriefingService
    {
        private readonly IDataRepository<Briefing, IEnumerable<Briefing>> repository;

        public BriefingService(IDataRepository<Briefing, IEnumerable<Briefing>> repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Briefing> GetAllBriefings()
        {
            return repository.GetAll();
        }

        public Briefing GetBriefingById(string id)
        {
            return repository.GetById(id);
        }

        public void AddBriefing(Briefing Briefing)
        {
            repository.Add(Briefing);
        }

        public void UpdateBriefing(Briefing Briefing)
        {
            repository.Update(Briefing);
        }

        public void DeleteBriefing(string id)
        {
            repository.Delete(id);
        }
    }
}
