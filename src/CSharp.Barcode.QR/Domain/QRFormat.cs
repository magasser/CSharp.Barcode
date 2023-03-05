namespace CSharp.Barcode
{
    /// <summary>
    ///     QR Code format
    /// </summary>
    public enum QRFormat
    {
        /// <summary>
        ///     Normal QR Code format with full range capabilities and maximum data capacity
        /// </summary>
        Normal = 1,

        /// <summary>
        ///     Micro QR Code format with resticted capabilites and reduced data capacity
        /// </summary>
        Micro = 2
    }
}
