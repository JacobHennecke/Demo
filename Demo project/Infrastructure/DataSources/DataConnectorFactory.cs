using Demo_project.Domain.Interfaces;

namespace Demo_project.Infrastructure.DataSources
{
    public enum ConnectorType
    {
        JsonData,
        Database,
        Blob
    }

    public class DataConnectorFactory<T>
    {
        public static IDataConnector<T> GetConnector(ConnectorType connectorType, string objectType = "")
        {
            switch (connectorType)
            {
                case ConnectorType.JsonData:
                    if (objectType == "")
                    {
                        throw new ArgumentException(objectType);
                    }
                    return new JsonDataSource<T>(objectType);

                case ConnectorType.Database:
                    return new DatabaseDataSource<T>();

                case ConnectorType.Blob:
                    return new BlobDataSource<T>();

                default:
                    throw new ArgumentException("Invalid connector type");
            }
        }
    }
}
