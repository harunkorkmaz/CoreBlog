using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Helpers;

using System.IO;
using System.Security.Cryptography;
using System.Text;
public static class SecurityTool
{
    private const string Password = "PrkNpXdAA1qLdV8DSAEAWIDKyv7ZS41PYZEAtw7qhFQ=";

    private static byte[] Crypto(byte[] nonCryptoData, byte[] key, byte[] iv)
    {
        using MemoryStream memoryStream = new();
        using Aes aes = Aes.Create();
        aes.Key = key;
        aes.IV = iv;
        using CryptoStream cryptoStream = new(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write);
        cryptoStream.Write(nonCryptoData, 0, nonCryptoData.Length);
        cryptoStream.FlushFinalBlock();
        return memoryStream.ToArray();
    }
    private static string CreateCyrptoText(string text)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(text);
        PasswordDeriveBytes passwordDeriveBytes = new(Password, "Hamido"u8.ToArray());
        return Convert.ToBase64String(Crypto(bytes, passwordDeriveBytes.GetBytes(32), passwordDeriveBytes.GetBytes(16)));
    }
    private static byte[] DeCrypto(byte[] cryptoData, byte[] key, byte[] iv)
    {
        using MemoryStream memoryStream = new();
        using Aes aes = Aes.Create();
        aes.Key = key;
        aes.IV = iv;
        using CryptoStream cryptoStream = new(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Write);
        cryptoStream.Write(cryptoData, 0, cryptoData.Length);
        cryptoStream.FlushFinalBlock();
        return memoryStream.ToArray();
    }
    private static string SolvedCryptoText(string text)
    {
        text = text.Replace(" ", "+");
        int num = text.Length % 4;
        if (num > 0)
        {
            text += new string('=', 4 - num);
        }

        byte[] cryptoData = Convert.FromBase64String(text);
        PasswordDeriveBytes passwordDeriveBytes = new(Password, "Hamido"u8.ToArray());
        return Encoding.UTF8.GetString(DeCrypto(cryptoData, passwordDeriveBytes.GetBytes(32), passwordDeriveBytes.GetBytes(16)));
    }
    public static string ToSha1(this string password)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(password);
        byte[] computeHash = SHA1.HashData(bytes);
        return HexCodefromBytes(computeHash);
    }
    private static string HexCodefromBytes(IEnumerable<byte> bytes)
    {
        StringBuilder stringBuilder = new();
        foreach (byte data in bytes)
        {
            string hex = data.ToString("X2");
            _ = stringBuilder.Append(hex);
        }
        return stringBuilder.ToString();
    }
    public static string ToCryptoText(this string value)
    {
        return CreateCyrptoText(Convert.ToBase64String(Encoding.UTF8.GetBytes(value)));
    }
    public static string ToDeCryptoText(this string value)
    {
        return Encoding.UTF8.GetString(Convert.FromBase64String(SolvedCryptoText(value)));
    }
}

