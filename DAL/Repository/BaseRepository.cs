using Newtonsoft.Json;

namespace DAL.Repository;

public class Repository<T>
{
    private readonly string _filePath;

    public Repository(string fileName)
    {
        string filePath = Directory.GetCurrentDirectory();
        _filePath = Path.Combine(filePath, fileName);
    }

    public List<T> GetAll()
    {
        if (!File.Exists(_filePath))
        {
            File.Create(_filePath).Close();
        }
        string json = File.ReadAllText(_filePath);
        List<T> items = JsonConvert.DeserializeObject<List<T>>(json);
        return items ?? new List<T>();
    }

    public void SaveAll(List<T> items)
    {
        string jsonResult = JsonConvert.SerializeObject(items);
        File.WriteAllText(_filePath, jsonResult);
    }
}
