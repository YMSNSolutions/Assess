﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Functions
{
    /// <summary>
    /// This class generates and compares hashes using MD5, SHA1, SHA256, SHA384, 
    /// and SHA512 hashing algorithms. Before computing a hash, it appends a
    /// randomly generated salt to the plain text, and stores this salt appended
    /// to the result. To verify another plain text value against the given hash,
    /// this class will retrieve the salt value from the hash string and use it
    /// when computing a new hash of the plain text. Appending a salt value to
    /// the hash may not be the most efficient approach, so when using hashes in
    /// a real-life application, you may choose to store them separately. You may
    /// also opt to keep results as byte arrays instead of converting them into
    /// base64-encoded strings.
    /// </summary>
    public class HashProvider
    {
        #region Properties

        /// <summary>
        /// Available hash algorithms
        /// </summary>
        public enum HashAlgorithmList
        {
            SHA1,
            SHA256,
            SHA384,
            SHA512,
            MD5
        }

        private static Random random = new Random((int)DateTime.Now.Ticks);

        #endregion

        /// <summary>
        /// Generates a hash for the given plain text value and returns a
        /// base64-encoded result. Before the hash is computed, a random salt
        /// is generated and appended to the plain text. This salt is stored at
        /// the end of the hash value, so it can be used later for hash
        /// verification.
        /// </summary>
        /// <param name="plainText">
        /// Plaintext value to be hashed. The function does not check whether
        /// this parameter is null.
        /// </param>
        /// <param name="hashAlgorithm">
        /// Name of the hash algorithm. Allowed values are: "MD5", "SHA1",
        /// "SHA256", "SHA384", and "SHA512" (if any other value is specified
        /// MD5 hashing algorithm will be used). This value is case-insensitive.
        /// </param>
        /// <param name="saltBytes">
        /// Salt bytes. This parameter can be null, in which case a random salt
        /// value will be generated.
        /// </param>
        /// <returns>
        /// Hash value formatted as a base64-encoded string.
        /// </returns>
        public static string ComputeHash(string plainText, HashAlgorithmList hashAlgorithmList, string salt)
        {
            byte[] saltBytes = System.Text.Encoding.UTF8.GetBytes(salt);

            // If salt is not specified, generate it on the fly.
            if (saltBytes == null || saltBytes.Length == 0)
            {
                // Define min and max salt sizes.
                int minSaltSize = 4;
                int maxSaltSize = 8;

                // Generate a random number for the size of the salt.
                Random random = new Random();
                int saltSize = random.Next(minSaltSize, maxSaltSize);

                // Allocate a byte array, which will hold the salt.
                saltBytes = new byte[saltSize];

                // Initialize a random number generator.
                RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

                // Fill the salt with cryptographically strong byte values.
                rng.GetNonZeroBytes(saltBytes);
            }

            // Convert plain text into a byte array.
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            // Allocate array, which will hold plain text and salt.
            byte[] plainTextWithSaltBytes =
                    new byte[plainTextBytes.Length + saltBytes.Length];

            // Copy plain text bytes into resulting array.
            for (int i = 0; i < plainTextBytes.Length; i++)
                plainTextWithSaltBytes[i] = plainTextBytes[i];

            // Append salt bytes to the resulting array.
            for (int i = 0; i < saltBytes.Length; i++)
                plainTextWithSaltBytes[plainTextBytes.Length + i] = saltBytes[i];

            // Because we support multiple hashing algorithms, we must define
            // hash object as a common (abstract) base class. We will specify the
            // actual hashing algorithm class later during object creation.
            HashAlgorithm hash;

            // Initialize appropriate hashing algorithm class.
            switch (hashAlgorithmList)
            {
                case HashAlgorithmList.SHA1:
                    hash = new SHA1Managed();
                    break;

                case HashAlgorithmList.SHA256:
                    hash = new SHA256Managed();
                    break;

                case HashAlgorithmList.SHA384:
                    hash = new SHA384Managed();
                    break;

                case HashAlgorithmList.SHA512:
                    hash = new SHA512Managed();
                    break;

                case HashAlgorithmList.MD5:
                    hash = new MD5CryptoServiceProvider();
                    break;

                default:
                    hash = new MD5CryptoServiceProvider();
                    break;
            }

            // Compute hash value of our plain text with appended salt.
            byte[] hashBytes = hash.ComputeHash(plainTextWithSaltBytes);

            // Create array which will hold hash and original salt bytes.
            byte[] hashWithSaltBytes = new byte[hashBytes.Length +
                                                saltBytes.Length];

            // Copy hash bytes into resulting array.
            for (int i = 0; i < hashBytes.Length; i++)
                hashWithSaltBytes[i] = hashBytes[i];

            // Append salt bytes to the result.
            for (int i = 0; i < saltBytes.Length; i++)
                hashWithSaltBytes[hashBytes.Length + i] = saltBytes[i];

            // Convert result into a base64-encoded string.
            string hashValue = Convert.ToBase64String(hashWithSaltBytes);

            // Return the result.
            return hashValue;
        }

        public static string RandomString(int size)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghizklmnopqrstuvwxyz0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, size)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());

            return result;
        }
    }
}
