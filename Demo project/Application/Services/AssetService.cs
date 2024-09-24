using Demo_project.Domain.Interfaces;
using Demo_project.Domain.Models;
using Demo_project.Infrastructure.DataSources;

namespace Demo_project.Application.Services
{
    public class AssetService
    {
        private readonly IDataRepository<Asset, IEnumerable<Asset>> repository;

        public AssetService(IDataRepository<Asset, IEnumerable<Asset>> repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Asset> GetAllAssets()
        {
            return repository.GetAll();
        }

        public Asset GetAssetById(string id)
        {
            return repository.GetById(id);
        }

        public void AddAsset(Asset asset)
        {
            repository.Add(asset);
        }

        public void UpdateAsset(Asset asset)
        {
            repository.Update(asset);
        }

        public void DeleteAsset(string id)
        {
            repository.Delete(id);
        }
    }
}
