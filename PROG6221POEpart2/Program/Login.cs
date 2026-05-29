// C#
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace QuickChatApp
{
    internal class Login
    {
        private readonly IDictionary<string, string> users; // username -> passwordHash (hex)

        public Login()
        {
            // Example users: in real app load from DB or secure store
            users = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                { "matthew", ComputeSha256Hex("Password123") } // demo only
            };
        }

        internal bool LoginUser(string? username, string? password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrEmpty(password))
                return false;

            if (!users.TryGetValue(username.Trim(), out var storedHash))
                return false;

            var givenHash = ComputeSha256Hex(password);
            return string.Equals(storedHash, givenHash, StringComparison.OrdinalIgnoreCase);
        }

        private static string ComputeSha256Hex(string input)
        {
            using (var sha = SHA256.Create())
            {
                var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(input));
                return BitConverter.ToString(bytes).Replace("-", "").ToLowerInvariant();
            }
        }
    }
}