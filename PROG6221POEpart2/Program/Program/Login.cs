using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace QuickChatApp
{
    internal class Login
    {
        private readonly IDictionary<string, string> _userStore = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        private const int SaltSize = 16;
        private const int KeySize = 32;
        private const int Iterations = 100_000;

        public Login()
        {
            _userStore["Matthew"] = HashPassword("Password123");
        }

        internal bool LoginUser(string? username, string? password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            if (!_userStore.TryGetValue(username!, out var storedHash))
            {
                return false;
            }

            return VerifyPassword(storedHash, password);
        }

        private static string HashPassword(string password)
        {
            var salt = new byte[SaltSize];
            RandomNumberGenerator.Fill(salt);

            using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256);
            var key = pbkdf2.GetBytes(KeySize);

            return $"{Iterations}.{Convert.ToBase64String(salt)}.{Convert.ToBase64String(key)}";
        }

        private static bool VerifyPassword(string hashedPassword, string providedPassword)
        {
            try
            {
                var parts = hashedPassword.Split('.');
                if (parts.Length != 3)
                {
                    return false;
                }

                var iterations = int.Parse(parts[0]);
                var salt = Convert.FromBase64String(parts[1]);
                var key = Convert.FromBase64String(parts[2]);

                using var pbkdf2 = new Rfc2898DeriveBytes(providedPassword, salt, iterations, HashAlgorithmName.SHA256);
                var keyToCheck = pbkdf2.GetBytes(key.Length);

                return CryptographicOperations.FixedTimeEquals(key, keyToCheck);
            }
            catch
            {
                return false;
            }
        }
    }
}