using System;

namespace CSharp.Barcode
{
    public static class QRCodeGenerator
    {
        public static QRCodeGeneratorOptions WithPayload(string payload)
        {
            if (payload is null)
            {
                throw new ArgumentNullException(nameof(payload));
            }

            return new QRCodeGeneratorOptions(payload);
        }
    }
}
