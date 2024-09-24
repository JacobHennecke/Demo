using Demo_project.Domain.Interfaces;
using Demo_project.Domain.Models;
using Demo_project.Infrastructure.DataSources;

namespace Demo_project.Infrastructure.Repositories
{
    public class ContentDistributionRepository : IDataRepository<ContentDistribution, ContentDistribution>
    {
        private readonly IDataConnector<ContentDistribution> connector;

        public ContentDistributionRepository()
        {
            connector = DataConnectorFactory<ContentDistribution>.GetConnector(ConnectorType.JsonData, nameof(ContentDistribution));
        }

        public ContentDistribution GetAll()
        {
            return connector.ReadData<ContentDistribution>();
        }

        public void Add(ContentDistribution data)
        {
            if (data != null)
            {
                connector.WriteData(data, "assetId");
            }
        }

        public ContentDistribution GetById(string id)
        {
            ContentDistribution dataset = GetAll();
            ContentDistributionAssets data = dataset.assets.Where(a => a.assetId == id).First();
            return new ContentDistribution(
                dataset.distributionDate,
                dataset.distributionChannels,
                dataset.distributionMethods,
                new ContentDistributionAssets[] { data }
            );
        }

        public void Update(ContentDistribution data)
        {
            throw new NotImplementedException();
        }


        public void Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}
