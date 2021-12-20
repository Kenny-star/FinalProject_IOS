﻿using System;
using System.Security.Cryptography;
using System.Text;

namespace FinalProject_IOS.Models
{
    public class AuthHelper
    {
        static string computeHash(string rawPassword)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawPassword));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public string hashPassword(string password)
        {
            return computeHash(password);
        }

    }
}