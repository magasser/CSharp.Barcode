using System;

namespace CSharp.Barcode.Exceptions
{
    [Serializable]
    public class EncodingException : Exception
    {
        public EncodingException() { }

        public EncodingException(string message)
            : base(message) { }

        public EncodingException(string messager, Exception inner)
            : base(messager, inner) { }
    }
}
