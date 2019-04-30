using Crm.Domain.Exceptions;
using Crm.Domain.Interfaces.Services;
using Crm.Domain.Models.Usuarios;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Crm.Domain.Services
{
    public sealed class CriptografiaService : ICriptografiaService
    {
        private static readonly byte[] BIv = { 0x50, 0x08, 0xF1, 0xDD, 0xDE, 0x3C, 0xF2, 0x18, 0x44, 0x74, 0x19, 0x2C, 0x53, 0x49, 0xAB, 0xBC }; // Todo: ultilizar variavel de appsettings.json
        private const string CryptoKey = "Q3JpcHRvZ3JhZmlhcyBjb20gUmluamRhZWwgLyBBRVM="; // Todo: ultilizar variavel de appsettings.json

        /// <summary>     
        /// Metodo de criptografia de valor     
        /// </summary>     
        /// <param name="text">valor a ser criptografado</param>
        /// <param name="chave">Chave usada para salt do codigo</param>
        /// <returns>valor criptografado</returns>
        public string CriptografarSenha(string text, string chave)
        {
            try
            {
                if (string.IsNullOrEmpty(text))
                {
                    return null;
                }

                var baseKey = Convert.FromBase64String(CryptoKey);
                var baseText = new UTF8Encoding().GetBytes($"{text}{chave}");

                using (var rijndael = new RijndaelManaged { KeySize = 256 })
                using (var memoryStream = new MemoryStream())
                {
                    var encryptor = new CryptoStream(
                        memoryStream,
                        rijndael.CreateEncryptor(baseKey, BIv),
                        CryptoStreamMode.Write);

                    encryptor.Write(baseText, 0, baseText.Length);

                    encryptor.FlushFinalBlock();

                    return Convert.ToBase64String(memoryStream.ToArray());
                }
            }
            catch (Exception ex)
            {
                throw new DomainException($"Erro ao criptografar {ex.Message}");
            }
        }

        /// <summary>
        /// Valida se a senha esta correta.
        /// </summary>
        /// <param name="senha">Objeto com login e senha do banco de dados.</param>
        /// <param name="login">Objeto com login e senha digitados pelo usuario. (Obrigátorios)</param>
        /// <returns></returns>
        public bool ValidarSenha(string senha, LoginInput login)
        {
            var senhaCripografada = CriptografarSenha(login.Senha, login.Usuario);

            return senhaCripografada.Equals(senha);
        }

        public string Criptografar(string texto)
        {
            try
            {
                if (string.IsNullOrEmpty(texto))
                {
                    return null;
                }

                var baseKey = Convert.FromBase64String(CryptoKey);
                var baseText = new UTF8Encoding().GetBytes(texto);

                using (var rijndael = new RijndaelManaged { KeySize = 256 })
                using (var memoryStream = new MemoryStream())
                {
                    var encryptor = new CryptoStream(
                        memoryStream,
                        rijndael.CreateEncryptor(baseKey, BIv),
                        CryptoStreamMode.Write);

                    encryptor.Write(baseText, 0, baseText.Length);

                    encryptor.FlushFinalBlock();

                    return Convert.ToBase64String(memoryStream.ToArray());
                }
            }
            catch (Exception ex)
            {
                throw new DomainException($"Erro ao criptografar {ex.Message}");
            }
        }

        /// <summary>     
        /// Pega um valor previamente criptografado e retorna o valor inicial 
        /// </summary>     
        /// <param name="texto">texto criptografado</param>     
        /// <returns>valor descriptografado</returns>     
        public string Descriptografar(string texto)
        {
            try
            {
                if (string.IsNullOrEmpty(texto)) return null;

                var baseKey = Convert.FromBase64String(CryptoKey);
                var baseText = Convert.FromBase64String(texto);

                using (var rijndael = new RijndaelManaged { KeySize = 256 })
                using (var mStream = new MemoryStream())
                {
                    var decryptor = new CryptoStream(
                        mStream,
                        rijndael.CreateDecryptor(baseKey, BIv),
                        CryptoStreamMode.Write);

                    decryptor.Write(baseText, 0, baseText.Length);

                    decryptor.FlushFinalBlock();

                    var utf8 = new UTF8Encoding();

                    return utf8.GetString(mStream.ToArray());
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao descriptografar {ex.Message}");
            }
        }
    }
}