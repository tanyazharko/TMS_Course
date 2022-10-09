using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileParser
{
    internal class RtfParser: FileParser
    {
        public RtfParser(string fileName)
           : base(fileName) { }
        public override string ParserFormat => ".rtf";
        public override void Analize() => Console.WriteLine($"{nameof(HtmlParser)}: File {FileName}, analized");
        public override void Close() => Console.WriteLine($"{nameof(HtmlParser)}: File {FileName}, closed");
        public override void Open() => Console.WriteLine($"{nameof(HtmlParser)}: File {FileName}, opened");
        public override void Read() => Console.WriteLine($"{nameof(HtmlParser)}: File {FileName}, read");
    }
}
