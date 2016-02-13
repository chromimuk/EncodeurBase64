using NUnit.Framework;

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
        public void ConvertByteToBinary()
        {
            byte[] source = { 0x6A, 0x77, 0xC4 };
            string expectedResult = "011010100111011111000100";
            string actualResult = Base64.ByteToBinary(source);

            Assert.AreEqual(expectedResult, actualResult);
        }


        [Test]
        public void BinaryCodeToNumericValue()
        {
            string binaryCode = "011010100111011111000100";
            int[] expectedResult = { 26, 39, 31, 4 };
            int[] actualResult = Base64.BinaryCodeToNumericValue(binaryCode);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void NumericValuesToMessage()
        {
            int[] numericValues = { 26, 39, 31, 4 };
            string expectedResult = "anfE";
            string actualResult = Base64.NumericValuesToMessage(numericValues);

            Assert.AreEqual(expectedResult, actualResult);
        }


    }
}
