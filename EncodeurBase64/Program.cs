namespace EncodeurBase64
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] source = {
                0xab,0x01,0xfd
            };

            Base64.Encode(source);
        }
    }
}
