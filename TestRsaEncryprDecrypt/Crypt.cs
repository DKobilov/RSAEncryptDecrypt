using System.Security.Cryptography;
using System.Text;
using System.Xml.Serialization;

namespace TestRsaEncryprDecrypt
{
    public class Crypt
    {
        private readonly string _publicKey;
        private readonly string _privateKey;

        public Crypt(string publicKey, string privateKey)
        {
            _publicKey = publicKey;
            _privateKey = privateKey;
        }

        public string Encrypt(string text)
        {
            var rsaPublicKey = GetKeyBytes(_publicKey);

            var csp = new RSACryptoServiceProvider();
            csp.ImportParameters(rsaPublicKey);

            var textBytes = Encoding.UTF8.GetBytes(text);

            var cypherTextBytes = csp.Encrypt(textBytes, false);

            return Convert.ToBase64String(cypherTextBytes);
        }



        public string Decrypt(string cypherText)
        {
            var rsaPrivateKey = GetKeyBytes(_privateKey);

            var csp = new RSACryptoServiceProvider();
            csp.ImportParameters(rsaPrivateKey);

            var cypherTextBytes = Convert.FromBase64String(cypherText);

            var textBytes = csp.Decrypt(cypherTextBytes, false);

            return Encoding.UTF8.GetString(textBytes);
        }

        private RSAParameters GetKeyBytes(string key)
        {
            var xs = new XmlSerializer(typeof(RSAParameters));
            var publicKeyXml = Base64.Base64Decode(key);
            var publicSeyString = new StringReader(publicKeyXml);
            return (RSAParameters)xs.Deserialize(publicSeyString);
        }
    }
}
