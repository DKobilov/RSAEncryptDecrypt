using TestRsaEncryprDecrypt;

namespace EncryptDecrypt
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Insert your text: ");

            var text = Console.ReadLine();
            Console.WriteLine();

            if (string.IsNullOrWhiteSpace(text))
            {
                text = "Hello!";
                Console.WriteLine(text);
                Console.WriteLine();
            }               

            var publicKeyBase64 = RSAPublicPrivateKey.GetPublicKey();
            Console.WriteLine($"public key in base64 format: {publicKeyBase64}");
            Console.WriteLine();

            var privateKeyBase64 = RSAPublicPrivateKey.GetPrivateKey();
            Console.WriteLine($"private key in base64 format: {privateKeyBase64}");
            Console.WriteLine();

            var crypt = new Crypt(publicKeyBase64, privateKeyBase64);

            var cypherText = crypt.Encrypt(text);
            Console.WriteLine($"Encryted text: {cypherText}");
            Console.WriteLine();

            var textData = crypt.Decrypt(cypherText);
            Console.WriteLine($"Decrypted text: {textData}");





            //var publickeyfilename = @"C:\Users\I_Islomov\Desktop\publicKey.xml";
            //RSAParameters publickey;

            //using (var stream = new FileStream(publickeyfilename, FileMode.Open))
            //{
            //    var xmlSerializer = new XmlSerializer(typeof(RSAParameters));
            //    publickey = (RSAParameters)xmlSerializer.Deserialize(stream);
            //    stream.Close();
            //}
        }
    }
}
