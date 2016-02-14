using System;
using System.Text;

namespace EncodeurBase64
{
    static class Base64
    {
        
        /// <summary>
        /// Custom Convert.ToBase64String
        /// </summary>
        /// <param name="source">Array to encode</param>
        /// <returns>Encoded string</returns>
        public static string Encode(byte[] source)
        {
            if (source == null)
                throw new ArgumentNullException("Array cannot be null");

            // "Le tableau aura une longueur qui sera un multiple de 3 afin de simplifier le test"
            if (source.Length == 0 || source.Length % 3 != 0)
                throw new ArgumentException("Array size should be multiple of 3");
            
            string binaryCode = ByteToBinaryCode(source);
            return BinaryCodeToEncodedString(binaryCode);
        }


        public static string ByteToBinaryCode(byte[] source)
        {
            StringBuilder builder = new StringBuilder();

            int sourceLength = source.Length;
            for (int i = 0; i < sourceLength; i++)
            {
                builder.Append(Convert.ToString(source[i], 2).PadLeft(8, '0'));
            }

            return builder.ToString();
        }
        

        public static string BinaryCodeToEncodedString(string binaryCode)
        {
            StringBuilder builder = new StringBuilder();

            int groupSize = 6;
            int binaryCodeLength = binaryCode.Length;

            for (int pos = 0; pos < binaryCodeLength; pos += groupSize)
            {
                string bit = binaryCode.Substring(pos, groupSize);
                int numericValue = Convert.ToInt32(bit, 2);
                builder.Append(Base64Array[numericValue]);
            }

            return builder.ToString();
        }
        

        private static readonly char[] Base64Array = new char[] {
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M',
            'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
            'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '/', '+'
        };

    }
}
