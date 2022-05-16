using System.Text;

namespace Toggler
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
