using System.Security.Cryptography;
using System.Text;

namespace Core.Helpers
{
    public static class Helper
    {
        public static void GenerateRsaKeyPair(out byte[] publicKey, out byte[] privateKey)
        {
            using var rsa = RSA.Create(2048);
            publicKey = rsa.ExportRSAPublicKey();     // Dùng để mã hóa
            privateKey = rsa.ExportRSAPrivateKey();   // Dùng để giải mã
        }

        public static string EncryptAes(string plainText, string secretKey)
        {
            using var aes = Aes.Create();
            aes.Key = SHA256.HashData(Encoding.UTF8.GetBytes(secretKey));
            aes.GenerateIV();
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            using var encryptor = aes.CreateEncryptor();
            var plainBytes = Encoding.UTF8.GetBytes(plainText);
            var cipherBytes = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);

            // Ghép IV + cipherText để giải mã sau
            var combined = aes.IV.Concat(cipherBytes).ToArray();
            return Convert.ToBase64String(combined);
        }

        public static string DecryptAes(string base64Cipher, string secretKey)
        {
            var fullBytes = Convert.FromBase64String(base64Cipher);
            var iv = fullBytes.Take(16).ToArray();
            var cipherBytes = fullBytes.Skip(16).ToArray();

            using var aes = Aes.Create();
            aes.Key = SHA256.HashData(Encoding.UTF8.GetBytes(secretKey));
            aes.IV = iv;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            using var decryptor = aes.CreateDecryptor();
            var plainBytes = decryptor.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
            return Encoding.UTF8.GetString(plainBytes);
        }
    }
}
