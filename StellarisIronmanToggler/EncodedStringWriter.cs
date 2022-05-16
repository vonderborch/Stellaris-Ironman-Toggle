using System.IO;
using System.Text;

namespace StellarisIronmanToggler
{
    public sealed class EncodedStringWriter : StringWriter
    {
        public EncodedStringWriter(Encoding encoding) : base()
        {
            this.Encoding = encoding;
        }

        public override Encoding Encoding { get; }
    }
}
