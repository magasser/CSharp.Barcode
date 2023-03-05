namespace CSharp.Barcode.Encoders
{
    internal interface IQREncoder
    {
        QREncodingMode EncodingMode { get; }

        string Encode(string payload, QRVersion version);
    }
}
