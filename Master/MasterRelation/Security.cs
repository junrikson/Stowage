﻿using System;
using System.Security.Cryptography;

namespace MasterRelation
{
    class Security
    {
        public string getHashPassword(string password = "123")
        {
            byte[] salt = new byte[16];
            new RNGCryptoServiceProvider().GetBytes(salt);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            string savedPasswordHash = Convert.ToBase64String(hashBytes);
            return savedPasswordHash;
        }

        public bool checkHashPassword(string password = "", string savedPasswordHash = "")
        {
            bool isMatch = true;

            byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            for(int i = 0; i < 20; i++)
            {
                if (hashBytes[i + 16] != hash[i])
                    isMatch = false;
            }

            return isMatch;
        }
    }
}
