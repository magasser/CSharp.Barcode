using System.Collections.Generic;

namespace CSharp.Barcode
{
    /// <summary>
    ///     Format and version information of a QR Code
    /// </summary>
    public sealed class QRVersion
    {
        public static readonly QRVersion VersionM1 = new QRVersion("M1", 11, 70, 15, 36, 5, 0, 3, null, null, null);

        public static readonly QRVersion VersionM2 = new QRVersion("M2", 13, 74, 15, 80, 10, 0, 4, 3, null, null);

        public static readonly QRVersion VersionM3 = new QRVersion("M3", 15, 78, 15, 132, 17, 0, 5, 4, 4, 3);

        public static readonly QRVersion VersionM4 = new QRVersion("M4", 17, 82, 15, 192, 24, 0, 6, 5, 5, 4);

        public static readonly QRVersion Version1 = new QRVersion("1", 21, 202, 31, 208, 26, 0, 10, 9, 8, 8);

        private QRVersion(
            string version,
            int modules,
            int functionPatternModules,
            int formatAndVersionInformationModules,
            int dataModules,
            int dataCapacity,
            int remainderBits,
            int numericCharacterCountBits,
            int? alphanumericCharacterCountBits,
            int? byteCharacterCountBits,
            int? kanjiCharacterCountBits)
        {
            Version = version;
            Modules = modules;
            FunctionPatternModules = functionPatternModules;
            FormatAndVersionInformationModules = formatAndVersionInformationModules;
            DataModules = dataModules;
            DataCapacity = dataCapacity;
            RemainderBits = remainderBits;
            NumericCharacterCountBits = numericCharacterCountBits;
            AlphanumericCharacterCountBits = alphanumericCharacterCountBits;
            ByteCharacterCountBits = byteCharacterCountBits;
            KanjiCharacterCountBits = kanjiCharacterCountBits;
        }

        /// <summary>
        ///     Version identifier
        /// </summary>
        public string Version { get; }

        /// <summary>
        ///     Number of modules
        /// </summary>
        public int Modules { get; }

        /// <summary>
        ///     Number of function patter modules
        /// </summary>
        public int FunctionPatternModules { get; }

        /// <summary>
        ///     Number of format and version information modules
        /// </summary>
        public int FormatAndVersionInformationModules { get; }

        /// <summary>
        ///     Number of data modules
        /// </summary>
        public int DataModules { get; }

        /// <summary>
        ///     Data capacity
        /// </summary>
        public int DataCapacity { get; }

        /// <summary>
        ///     Remainder bits
        /// </summary>
        public int RemainderBits { get; }

        /// <summary>
        ///     Character count indicator bits in numeric mode
        /// </summary>
        public int NumericCharacterCountBits { get; }

        /// <summary>
        ///     Character count indicator bits in alphanumeric mode
        /// </summary>
        public int? AlphanumericCharacterCountBits { get; }

        /// <summary>
        ///     Character count indicator bits in byte mode
        /// </summary>
        public int? ByteCharacterCountBits { get; }

        /// <summary>
        ///     Character count indicator bits in kanji mode
        /// </summary>
        public int? KanjiCharacterCountBits { get; }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            var version = (QRVersion)obj;

            return version.Version == Version;
        }

        public static bool operator ==(QRVersion a, QRVersion b) => a.Equals(b);

        public static bool operator !=(QRVersion a, QRVersion b) => !a.Equals(b);

        /// <inheritdoc />
        public override int GetHashCode()
        {
            var hashCode = 1371032057;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Version);
            hashCode = hashCode * -1521134295 + Modules.GetHashCode();
            hashCode = hashCode * -1521134295 + FunctionPatternModules.GetHashCode();
            hashCode = hashCode * -1521134295 + FormatAndVersionInformationModules.GetHashCode();
            hashCode = hashCode * -1521134295 + DataModules.GetHashCode();
            hashCode = hashCode * -1521134295 + DataCapacity.GetHashCode();
            hashCode = hashCode * -1521134295 + RemainderBits.GetHashCode();
            hashCode = hashCode * -1521134295 + NumericCharacterCountBits.GetHashCode();
            hashCode = hashCode * -1521134295 + AlphanumericCharacterCountBits.GetHashCode();
            hashCode = hashCode * -1521134295 + ByteCharacterCountBits.GetHashCode();
            hashCode = hashCode * -1521134295 + KanjiCharacterCountBits.GetHashCode();
            return hashCode;
        }

        public override string ToString() => Version;
    }
}
