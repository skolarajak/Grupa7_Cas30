using System;
using System.Text;

namespace Cas30
{
    class Functions
    {

        public static string RandomEmail()
        {
            Random Rnd = new Random();

            string EmailSegment1, EmailSegment2, EmailSegment3;
            EmailSegment1 = RandomAlphaNumeric(Rnd.Next(5, 10)).ToLower();
            EmailSegment1 += "." + RandomAlphaNumeric(Rnd.Next(5, 10)).ToLower();
            EmailSegment2 = RandomAlphaNumeric(Rnd.Next(7, 15)).ToLower();
            EmailSegment3 = RandomAlpha(Rnd.Next(4, 6)).ToLower();
            return EmailSegment1 + "@" + EmailSegment2 + "." + EmailSegment3;
        }

        public static string RandomTelephone()
        {
            Random Rnd = new Random();

            StringBuilder Builder = new StringBuilder();
            for (int i = 0; i < 12; i++)
            {
                if (i == 3)
                {
                    Builder.Append("/");
                } else if (i == 7) {
                    Builder.Append("-");
                } else
                {
                    Builder.Append(Rnd.Next(0, 9).ToString());
                }
            }

            return Builder.ToString();
        }

        public static string RandomAlphaNumeric(int Length = 10)
        {
            Random Rnd = new Random();
            const string Pool = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            var Builder = new StringBuilder();
            for (int i = 0; i < Length; i++)
            {
                var Char = Pool[Rnd.Next(0, Pool.Length)];
                Builder.Append(Char);
            }

            return Builder.ToString();
        }

        public static string RandomAlpha(int Length = 10)
        {
            Random Rnd = new Random();
            const string Pool = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

            var Builder = new StringBuilder();
            for (int i = 0; i < Length; i++)
            {
                var Char = Pool[Rnd.Next(0, Pool.Length)];
                Builder.Append(Char);
            }

            return Builder.ToString();
        }
    }
}
