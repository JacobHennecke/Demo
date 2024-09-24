using Demo_project.Domain.Interfaces;

namespace Demo_project.Infrastructure.DataSources
{
    public class BlobDataSource<T> : IDataConnector<T>
    {
        public void DeleteData(T data, string propertyName)
        {
            throw new NotImplementedException();
        }

        public T1 ReadData<T1>()
        {
            throw new NotImplementedException();
        }

        public void UpdateData(T data, string propertyName)
        {
            throw new NotImplementedException();
        }

        public void WriteData(T data, string propertyName)
        {
            throw new NotImplementedException();
        }
    }
}
