using Demo_project.Domain.Interfaces;
using Demo_project.Infrastructure.Extentions;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Collections.Generic;
using System.Data;
using System.Text.Json;

namespace Demo_project.Infrastructure.DataSources
{
    public class JsonDataSource<T> : IDataConnector<T>
    {
        private static Dictionary<string, object> jsonData = new Dictionary<string, object>();

        private static void appendJsonData(string objectType, object data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }
            if (!jsonData.ContainsKey(objectType))
            {
                jsonData.Add(objectType, data);
            }
        }

        public static void LoadDataFile(string objectType)
        {
            using (StreamReader reader = new StreamReader($"Metadata/{objectType}Metadata.json"))
            {
                string jsonMetadata = reader.ReadToEnd();
                if (jsonMetadata.StartsWith("["))
                {
                    appendJsonData(objectType, JsonSerializer.Deserialize<List<T>>(jsonMetadata));
                }
                else if (jsonMetadata.StartsWith("{"))
                {
                    appendJsonData(objectType, JsonSerializer.Deserialize<T>(jsonMetadata));
                }
            }
        }

        private string objectType;

        public JsonDataSource(string objectType)
        {
            this.objectType = objectType;
        }

        public T1 ReadData<T1>()
        {
            return (T1)jsonData[objectType];
        }

        public void WriteData(T data, string propertyName)
        {
            object dataset = jsonData[objectType];
            if (dataset.GetType() == typeof(List<T>))
            {
                WriteDataList((List<T>)dataset, data, propertyName);
            }
            else if (nameof(dataset) == objectType)
            {
                throw new NotImplementedException();
            }
        }

        private void WriteDataList(List<T> dataset, T data, string propertyName)
        {
            object dataIdentifier = data.GetGenericValue(propertyName);

            // Find by propertyName the objects identifer property, idea is to find the assetId and if it has a match update it on the write
            int dataObjectIndex = dataset.FindIndex(x => x.GetGenericValue(propertyName).ToString() == dataIdentifier.ToString());
            if (dataObjectIndex != -1)
            {
                throw new BadHttpRequestException($"Key is already in use ({dataIdentifier})");
            }
            ((List<T>)jsonData[objectType]).Add(data);
        }

        public void UpdateData(T data, string propertyName)
        {
            throw new NotImplementedException();
        }

        public void DeleteData(T data, string propertyName)
        {
            throw new NotImplementedException();
        }
    }
}
