using Demo_project.Domain.Interfaces;
using Demo_project.Domain.Models;
using Demo_project.Infrastructure.DataSources;

namespace Demo_project.Infrastructure.Repositories
{
    public class BriefingRepository : IDataRepository<Briefing, IEnumerable<Briefing>>
    {
        private readonly IDataConnector<Briefing> connector;

        public BriefingRepository()
        {
            connector = DataConnectorFactory<Briefing>.GetConnector(ConnectorType.JsonData, nameof(Briefing));
        }

        public IEnumerable<Briefing> GetAll()
        {
            return connector.ReadData<IEnumerable<Briefing>>();
        }

        public void Add(Briefing data)
        {
            if (data != null)
            {
                connector.WriteData(data, "assetId");
            }
        }

        public Briefing GetById(string id)
        {
            IEnumerable<Briefing> assets = GetAll();
            return assets.Where(a => a.assetId == id).First();
        }

        public void Update(Briefing data)
        {
            throw new NotImplementedException();
        }


        public void Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}
