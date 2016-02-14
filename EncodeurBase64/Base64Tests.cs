using NUnit.Framework;
using System;

namespace EncodeurBase64
{
    [TestFixture]
    class Base64Tests
    {

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SourceArrayShouldNotBeNull()
        {
            Base64.Encode(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void SourceArraySizeShouldNotBeEmpty()
        {
            byte[] source = new byte[0];
            Base64.Encode(source);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void SourceArraySizeShouldBeMultipleOfThree()
        {
            byte[] source = { 0x6A, 0x77 };
            Base64.Encode(source);
        }


        [Test]
        public void Encode()
        {
            byte[] source = { 0x6A, 0x77, 0xC4 };
            string expectedResult = "anfE";
            string actualResult = Base64.Encode(source);

            Assert.AreEqual(expectedResult, actualResult);
        }
        
        [Test]
        public void ConvertByteToBinary()
        {
            byte[] source = { 0x6A, 0x77, 0xC4 };
            string expectedResult = "011010100111011111000100";
            string actualResult = Base64.ByteToBinaryCode(source);

            Assert.AreEqual(expectedResult, actualResult);
        }
        
        [Test]
        public void BinaryCodeToEncodedString()
        {
            string binaryCode = "011010100111011111000100";
            string expectedResult = "anfE";
            string actualResult = Base64.BinaryCodeToEncodedString(binaryCode);

            Assert.AreEqual(expectedResult, actualResult);
        }

    }
}
