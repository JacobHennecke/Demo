using Demo_project.Domain.Interfaces;
using Demo_project.Domain.Models;
using Demo_project.Infrastructure.DataSources;

namespace Demo_project.Infrastructure.Repositories
{
    public class AssetRepository : IDataRepository<Asset, IEnumerable<Asset>>
    {
        private readonly IDataConnector<Asset> connector;

        public AssetRepository()
        {
            connector = DataConnectorFactory<Asset>.GetConnector(ConnectorType.JsonData, nameof(Asset));
        }

        public IEnumerable<Asset> GetAll()
        {
            return connector.ReadData<IEnumerable<Asset>>();
        }

        public void Add(Asset data)
        {
            if (data != null)
            {
                connector.WriteData(data, "assetId");
            }
        }

        public Asset GetById(string id)
        {
            IEnumerable<Asset> assets = GetAll();
            return assets.Where(a => a.assetId == id).First();
        }

        public void Update(Asset data)
        {
            throw new NotImplementedException();
        }


        public void Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}
