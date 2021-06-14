namespace UnitTestingPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = new Logger();
            IDataStore dataStore = new DataStore(logger);

            dataStore.Create("key", "data");
            dataStore.Update("key", "new data");
            dataStore.TryRead("key", out _);
            dataStore.Delete("key");
        }
    }
}
