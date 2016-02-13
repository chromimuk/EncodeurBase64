using System;
using System.Text;

namespace EncodeurBase64
{
    static class Base64
    {

        public static string Encode(byte[] source)
        {
            string binaryCode = ByteToBinary(source);
            int[] numericValues = BinaryCodeToNumericValue(binaryCode);
            string message = NumericValuesToMessage(numericValues);

            return message;
        }



        public static string ByteToBinary(byte[] source)
        {
            StringBuilder builder = new StringBuilder();
            foreach (byte b in source)
            {
                // PadLeft here is important, we need 8 digits 
                builder.Append(Convert.ToString(b, 2).PadLeft(8, '0'));
            }

            return builder.ToString();
        }


        public static int[] BinaryCodeToNumericValue(string binary)
        {
            int groupSize = 6;
            int[] numericValues = new int[binary.Length / groupSize];

            int j = 0;
            int binaryCodeLength = binary.Length;

            for (int i = 0; i < binaryCodeLength; i += groupSize)
            {
                // if the code is smaller than 6 char.
                // if (i + groupSize > binaryCodeLength) groupSize = binaryCodeLength - 1;

                string bit = binary.Substring(i, groupSize);
                numericValues[j] = Convert.ToInt32(bit, 2);
                j++;
            }

            return numericValues;
        }
          
              
        public static string NumericValuesToMessage(int[] numericValues)
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
