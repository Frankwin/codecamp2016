using System;
using System.Linq;
namespace CodeCampDemoFramework.Generators
{
    public static class PasswordGenerator
    {
        public static string Generate()
        {
            string password = RandomString(16);
            LastGeneratedPassword = password;
            return password;
        }

        public static string LastGeneratedPassword { get; set; }

        public static string RandomString(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()-=_+[]<>";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}