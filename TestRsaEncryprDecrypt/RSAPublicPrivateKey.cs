using System.Security.Cryptography;
using System.Xml.Serialization;

namespace TestRsaEncryprDecrypt
{
    public class RSAPublicPrivateKey
    {
        private static readonly RSACryptoServiceProvider csp = new (2048);

        public static string GetPublicKey()
        {
            var publicKey = csp.ExportParameters(false);

            return GetKey(publicKey);
        }

        public static string GetPrivateKey()
        {
            var privateKey = csp.ExportParameters(true);

            return GetKey(privateKey);
        }

        private static string GetKey(RSAParameters key)
        {
            var sw = new StringWriter();

            var xs = new XmlSerializer(typeof(RSAParameters));

            xs.Serialize(sw, key);

            return Base64.Base64Encode(sw.ToString());
        }
    }
}
