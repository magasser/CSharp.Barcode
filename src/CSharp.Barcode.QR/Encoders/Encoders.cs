namespace CSharp.Barcode.Encoders
{
    internal static class Encoders
    {
        public static IQREncoder ECI = new ECIEncoder();
        public static IQREncoder Numeric = new NumericEncoder();
        public static IQREncoder Alphanumeric = new AlphanumericEncoder();
        public static IQREncoder Byte = new ByteEncoder();
    }
}
