using System.Text.Json;
using EfCoreTest.Models;

namespace EfCoreTest.DataAccess
{
    public class JsonDataAccess
    {
        private readonly string _filePath;

        public JsonDataAccess(string filePath)
        {
            _filePath = filePath;
        }

        public T? ReadData<T>() where T : class
        {
            var jsonData = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<T>(jsonData);
        }

        public void WriteData<T>(T data)
        {
            var jsonData = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, jsonData);
        }
    }
}