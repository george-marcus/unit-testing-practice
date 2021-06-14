using System;
using System.Collections.Generic;

namespace UnitTestingPractice
{
    public class DataStore : IDataStore
    {
        private readonly ILogger logger;

        private readonly Dictionary<string, string> dataDictioanry;

        public DataStore(ILogger logger)
        {
            dataDictioanry = new Dictionary<string, string>();
            this.logger = logger;
        }

        public bool Create(string key, string data)
        {
            logger.Write("Entrance to create method");

            try
            {
                dataDictioanry.Add(key, data);
                logger.Write($"Successfully created {key} {data}");
                return true;
            }
            catch (ArgumentNullException ex)
            {
                logger.Write(ex.Message);
                return false;
            }
            catch (ArgumentException ex)
            {
                logger.Write(ex.Message);
                return false;
            }
            catch (OutOfMemoryException ex)
            {
                logger.Write(ex.Message);
                return false;
            }
        }

        public bool Delete(string key)
        {
            logger.Write("Entrance to delete method");

            try
            {
                var result = dataDictioanry.Remove(key);

                if (result)
                {
                    logger.Write($"Successfully removed {key} from data store");
                    return result;
                }

                logger.Write($"Couldn't find {key} in data store");
                return false;
            }
            catch (ArgumentNullException ex)
            {
                logger.Write(ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                logger.Write(ex.Message);
                return false;
            }
        }

        public bool TryRead(string key, out string data)
        {
            logger.Write("Entrance to read method");

            try
            {
                data = dataDictioanry.GetValueOrDefault(key);

                logger.Write($"Successfully fetched {data} from data store");
                return data != null;
            }
            catch (ArgumentNullException ex)
            {
                logger.Write(ex.Message);
                data = null;
                return false;
            }
        }

        public bool Update(string key, string data)
        {
            logger.Write("Entrance to update method");
            try
            {
                var oldData = dataDictioanry.GetValueOrDefault(key);

                if (string.IsNullOrEmpty(oldData))
                {
                    throw new ArgumentNullException("Old data couldn't be found");
                }

                dataDictioanry[key] = data;
                logger.Write($"Successfully updated {oldData} to {data} in the data store");
                return true;
            }
            catch (ArgumentNullException ex)
            {
                logger.Write(ex.Message);
                return false;
            }
        }
    }

   
}
