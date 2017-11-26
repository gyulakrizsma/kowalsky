using System;
using System.Collections.Generic;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Kowalsky.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Kowalsky.Services.GoogleApi
{
    public class GoogleApiServices : IGoogleApiServices
    {
        private readonly IErrorReporter _errorReporter;
        private readonly GoogleApiOptions _credentials;
        private const string Id = "10dcpNCVCBKG0UmWJIEjEPbagvbt0toVJUFbqMfg14qI";
        private const string Sheet = "sheet1";

        public GoogleApiServices(IOptions<GoogleApiOptions> options, IErrorReporter errorReporter)
        {
            _errorReporter = errorReporter;
            _credentials = options.Value;
        }

        public void SaveContactInfoToSpreadSheet(ContactInfo contact)
        {
            if (_credentials.Empty)
            {
                _errorReporter.CaptureAsync("GoogleApi options are empty");
                return;
            }

            var service = CreateService();
            var data = SetupData(contact);

            WriteToSpreadSheet(service, data);
        }

        private static void WriteToSpreadSheet(SheetsService service, ValueRange data)
        {
            var range = $"{Sheet}!A:E";

            var appendRequest = service.Spreadsheets.Values.Append(data, Id, range);
            appendRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
            appendRequest.Execute();
        }

        private static ValueRange SetupData(ContactInfo contact)
        {
            var valueRange = new ValueRange();

            var oblist = new List<object>()
            {
                contact.Name,
                contact.Email,
                contact.Phone,
                contact.Comment,
                DateTime.UtcNow.ToString("yyyy.MM.dd hh:mm:ss")
            };
            valueRange.Values = new List<IList<object>> { oblist };

            return valueRange;
        }

        private SheetsService CreateService()
        {
            var json = JsonConvert.SerializeObject(_credentials);

            var credential = GoogleCredential.FromJson(json)
                .CreateScoped(SheetsService.Scope.Spreadsheets);

            var initializer = new BaseClientService.Initializer
            {
                HttpClientInitializer = credential,
                ApplicationName = "Kowalsky"
            };

            return new SheetsService(initializer);
        }
    }
}
