using LibreTranslate.Net;
using Translation.Workers.Dtos;
using Translation.Workers.Services;

namespace Translation.Workers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //// store secret info to disk
            //var secretInfo = new SecretInfoDto()
            //{
            //    ApiKey = "MySecretApiKey"
            //};

            //var secretsService = new SecretsService();
            //secretsService.SaveSecretInfo(secretInfo);

            // get secret info
            var secretsService = new SecretsService();

            var secretInfo = secretsService.GetSecretInfo();

            // store secret info in a variable
            var apiKey = secretInfo.ApiKey;

            var libreTranslate = new LibreTranslate.Net.LibreTranslate();
            var englishText = "Hello World!";
            var getSupportedLanguagesAsyncTask = libreTranslate.GetSupportedLanguagesAsync();
            //System.Threading.Tasks.Task.Run(() => getSupportedLanguagesAsyncTask).Wait();
            //var supportedLanguages = getSupportedLanguagesAsyncTask.Result;
            //Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(supportedLanguages, Newtonsoft.Json.Formatting.Indented));
            var TranslateAsyncTask = libreTranslate.TranslateAsync(new Translate()
            {
                ApiKey = secretInfo.ApiKey,
                Source = LanguageCode.English,
                Target = LanguageCode.Spanish,
                Text = englishText
            });
            System.Threading.Tasks.Task.Run(() => TranslateAsyncTask).Wait();
            var spanishText = TranslateAsyncTask.Result;
            Console.WriteLine(spanishText);
            Console.ReadLine();
            Console.WriteLine("Hello, World!");
        }
    }
}
