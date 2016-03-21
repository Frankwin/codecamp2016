using System;

namespace CodeCampDemoFramework.Generators
{
    public class EmailAddressGenerator
    {
        public static string Generate()
        {
            return "random" + GetRandomNumber() + "@random.com";
        }

        // Generate random number for email address
        public static int GetRandomNumber()
        {
            return new Random().Next(100000, 100000000);
        }
    }
}