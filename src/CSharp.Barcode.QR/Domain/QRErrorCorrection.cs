namespace CSharp.Barcode
{
    /// <summary>
    ///     Error correction levels for QR Codes
    /// </summary>
    public enum QRErrorCorrection
    {
        /// <summary>
        ///     Error correction with 7% recovery
        /// </summary>
        L = 1,

        /// <summary>
        ///     Error correction with 15% recovery
        /// </summary>
        M = 2,

        /// <summary>
        ///     Error correction with 25% recovery
        /// </summary>
        Q = 3,

        /// <summary>
        ///     Error correction with 30% recovery
        /// </summary>
        H = 4
    }
}
