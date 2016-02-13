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
            // "Le tableau aura une longueur qui sera un multiple de 3 afin de simplifier le test"
            if (source.Length % 3 != 0 || source.Length == 0)
                throw new ArgumentException("Array size should be multiple of 3");
            
            string binaryCode = ByteToBinary(source);
            int[] numericValues = BinaryCodeToNumericValues(binaryCode);
            string encodedString = NumericValuesToEncodedString(numericValues);

            return encodedString;
        }


        public static string ByteToBinary(byte[] source)
        {
            StringBuilder builder = new StringBuilder();
            foreach (byte b in source)
            {
                // PadLeft here is important, we need 8 digits to form an octet 
                builder.Append(Convert.ToString(b, 2).PadLeft(8, '0'));
            }

            return builder.ToString();
        }


        public static int[] BinaryCodeToNumericValues(string binaryCode)
        {
            int groupSize = 6;
            int binaryCodeLength = binaryCode.Length;
            int[] numericValues = new int[binaryCodeLength / groupSize];

            int index = 0;
            for (int pos = 0; pos < binaryCodeLength; pos += groupSize)
            {
                string bit = binaryCode.Substring(pos, groupSize);
                numericValues[index] = Convert.ToInt32(bit, 2);
                index++;
            }

            return numericValues;
        }
          
              
        public static string NumericValuesToEncodedString(int[] numericValues)
        {
            StringBuilder builder = new StringBuilder();
            foreach (var numVal in numericValues)
            {
                builder.Append(Base64Array[numVal]);
            }

            return builder.ToString();
        }
        


        private static readonly char[] Base64Array = new char[] {
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N',
            'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n',
            'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
            '/', '+'
        };

    }
}
