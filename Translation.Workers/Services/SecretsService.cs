using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Translation.Workers.Dtos;

namespace Translation.Workers.Services
{
    public class SecretsService
    {
        private const string BaseSecretStorePath = @"C:\Users\Houston\OneDrive\.rcsdatastore\";
        public SecretsService() { }
        public SecretInfoDto GetSecretInfo()
        {
            SecretInfoDto secretInfo = new SecretInfoDto();

            // read json file from disk
            string jsonString = System.IO.File.ReadAllText(BaseSecretStorePath + "secrets.json");

            // deserialize json to object

            secretInfo = JsonConvert.DeserializeObject<SecretInfoDto>(jsonString);

            // return object
            return secretInfo;

        }

        public void SaveSecretInfo(SecretInfoDto secretInfo)
        {
            // serialize object to json
            string jsonString = JsonConvert.SerializeObject(secretInfo);

            // write json to disk
            System.IO.File.WriteAllText(BaseSecretStorePath + "secrets.json", jsonString);
        }

    }
}
