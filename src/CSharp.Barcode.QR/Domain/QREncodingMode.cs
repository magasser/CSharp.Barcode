namespace CSharp.Barcode
{
    /// <summary>
    ///     Encoding mode of a QR Code
    /// </summary>
    public enum QREncodingMode
    {
        /// <summary>
        ///     Extendend channel interpretation encoding mode
        /// </summary>
        ECI = 1,

        /// <summary>
        ///     Numeric encoding mode
        /// </summary>
        Numeric = 2,

        /// <summary>
        ///     Alphanumeric encoding mode
        /// </summary>
        Alphanumeric = 3,

        /// <summary>
        ///     Byte encoding mode
        /// </summary>
        Byte = 4,

        /// <summary>
        ///     Kanji encoding mode
        /// </summary>
        Kanji = 5,

        /// <summary>
        ///     Structured append encoding mode
        /// </summary>
        StructuredAppend = 7,

        /// <summary>
        ///     Function code one encoding mode
        /// </summary>
        FNC1 = 8,

        /// <summary>
        ///     Mixed encoding modes
        /// </summary>
        Mixed = 9
    }
}
