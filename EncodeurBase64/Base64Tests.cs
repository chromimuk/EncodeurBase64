using NUnit.Framework;
using System;

namespace EncodeurBase64
{
    [TestFixture]
    class Base64Tests
    {

        [Test]
        public void Encode()
        {
            byte[] source = { 0x6A, 0x77, 0xC4 };
            string expectedResult = "anfE";
            string actualResult = Base64.Encode(source);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void EncodeSourceSizeShouldBeMultipleOfThree()
        {
            byte[] source = { 0x6A, 0x77 };
            Base64.Encode(source);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void EncodeSourceSizeShouldNotBeEmpty()
        {
            byte[] source = new byte[0];
            Base64.Encode(source);
        }



        [Test]
        public void ConvertByteToBinary()
        {
            byte[] source = { 0x6A, 0x77, 0xC4 };
            string expectedResult = "011010100111011111000100";
            string actualResult = Base64.ByteToBinary(source);

            Assert.AreEqual(expectedResult, actualResult);
        }


        [Test]
        public void BinaryCodeToNumericValues()
        {
            string binaryCode = "011010100111011111000100";
            int[] expectedResult = { 26, 39, 31, 4 };
            int[] actualResult = Base64.BinaryCodeToNumericValues(binaryCode);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void NumericValuesToEncodedString()
        {
            int[] numericValues = { 26, 39, 31, 4 };
            string expectedResult = "anfE";
            string actualResult = Base64.NumericValuesToEncodedString(numericValues);

            Assert.AreEqual(expectedResult, actualResult);
        }


    }
}
