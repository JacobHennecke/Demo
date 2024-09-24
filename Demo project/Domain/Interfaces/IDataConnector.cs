namespace Demo_project.Domain.Interfaces
{
    public interface IDataConnector<T>
    {
        T1 ReadData<T1>();

        void WriteData(T data, string propertyName);

        void UpdateData(T data, string propertyName);

        void DeleteData(T data, string propertyName);
    }
}
