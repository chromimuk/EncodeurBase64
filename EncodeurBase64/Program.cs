namespace EncodeurBase64
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] source = { 0x6A, 0x77, 0xC4 };
            System.Diagnostics.Debug.WriteLine(Base64.Encode(source));
        }
    }
}
