using System;
using System.ComponentModel;

namespace CSharp.Barcode
{
    public sealed class QRCodeGeneratorOptions
    {
        private const QRErrorCorrection DefaultErrorCorrection = QRErrorCorrection.L;
        private const QRFormat DefaultFormat = QRFormat.Normal;

        private string _payload;
        private QRErrorCorrection _errorCorrection;
        private QRFormat _format;

        internal QRCodeGeneratorOptions(string payload)
        {
            if (payload is null)
            {
                throw new ArgumentNullException(nameof(payload));
            }

            _payload = payload;
            _format = DefaultFormat;
            _errorCorrection = DefaultErrorCorrection;
        }

        public QRCodeGeneratorOptions WithErrorCorrection(QRErrorCorrection errorCorrectionLevel)
        {
            if (!Enum.IsDefined(typeof(QRErrorCorrection), errorCorrectionLevel))
            {
                throw new InvalidEnumArgumentException(
                    nameof(errorCorrectionLevel),
                    (int)errorCorrectionLevel,
                    typeof(QRErrorCorrection));
            }

            _errorCorrection = errorCorrectionLevel;

            return this;
        }

        public QRCodeGeneratorOptions WithFormat(QRFormat format)
        {
            if (!Enum.IsDefined(typeof(QRFormat), format))
            {
                throw new InvalidEnumArgumentException(nameof(format), (int)format, typeof(QRFormat));
            }

            _format = format;

            return this;
        }

        public QRCode Generate() => throw new NotImplementedException();
    }
}
