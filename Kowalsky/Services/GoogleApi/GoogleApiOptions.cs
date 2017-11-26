using Newtonsoft.Json;

namespace Kowalsky.Services.GoogleApi
{
    public class GoogleApiOptions
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("project_id")]
        public string ProjectId { get; set; }

        [JsonProperty("private_key_id")]
        public string PrivateKeyId { get; set; }

        [JsonProperty("private_key")]
        public string PrivateKey { get; set; }

        [JsonProperty("client_email")]
        public string ClientEmail { get; set; }

        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        [JsonProperty("auth_uri")]
        public string AuthUri { get; set; }

        [JsonProperty("token_uri")]
        public string TokenUri { get; set; }

        [JsonProperty("auth_provider_x509_cert_url")]
        public string AuthProvider { get; set; }

        [JsonProperty("client_x509_cert_url")]
        public string ClientCertificate { get; set; }

        public bool Empty => string.IsNullOrWhiteSpace(Type) || string.IsNullOrWhiteSpace(ProjectId) ||
                             string.IsNullOrWhiteSpace(PrivateKeyId) || string.IsNullOrWhiteSpace(PrivateKey) ||
                             string.IsNullOrWhiteSpace(ClientEmail) || string.IsNullOrWhiteSpace(ClientId) ||
                             string.IsNullOrWhiteSpace(AuthUri) || string.IsNullOrWhiteSpace(TokenUri) ||
                             string.IsNullOrWhiteSpace(AuthProvider) || string.IsNullOrWhiteSpace(ClientCertificate);
    }
}
