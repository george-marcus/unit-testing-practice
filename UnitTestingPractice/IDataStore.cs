namespace UnitTestingPractice
{
    public interface IDataStore
    {
        bool Create(string key, string data);
        bool TryRead(string key, out string data);
        bool Update(string key, string data);
        bool Delete(string key);
    }

   
}
