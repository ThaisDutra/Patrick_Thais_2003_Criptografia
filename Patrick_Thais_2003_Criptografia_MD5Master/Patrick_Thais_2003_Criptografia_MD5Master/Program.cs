using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
namespace Patrick_Thais_2003_Criptografia_MD5Master
{
    class Program
    {
        static void Main(string[] args)
        {
            string senha = (Console.ReadLine());
            using (MD5 md5Hash = MD5.Create())
            {
                string crip = GetMd5Hash(md5Hash, senha);
                Console.WriteLine("Senha: " + senha + " = " + crip);
            }
            Console.ReadKey();
        }
        static string GetMd5Hash(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
        static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            string hashOfInput = GetMd5Hash(md5Hash, input);
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
