using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileParser
{
    internal class XmlParser : FileParser
    {
        public XmlParser(string fileName)
           : base(fileName) { }
        public override string ParserFormat => ".xml";
        public override void Analize() => Console.WriteLine($"{nameof(XmlParser)}: File {FileName}, analized");
        public override void Close() => Console.WriteLine($"{nameof(XmlParser)}: File {FileName}, closed");
        public override void Open() => Console.WriteLine($"{nameof(XmlParser)}: File {FileName}, opened");
        public override void Read() => Console.WriteLine($"{nameof(XmlParser)}: File {FileName}, read");
    }
}

