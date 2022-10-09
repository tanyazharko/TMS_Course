using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileParser
{
    abstract class FileParser
    {
        protected string FileName;
        public FileParser(string fileName) => FileName = fileName;
        public abstract string ParserFormat { get; }
        public abstract void Read();
        public abstract void Open();
        public abstract void Analize();
        public abstract void Close();
        public virtual void Parse()
        {
            Open();
            Read();
            Analize();
            Close();
        }
        public static FileParser GetParser(string fileName)
        {
            FileParser fileParser;

            if (fileName.EndsWith("html"))
            {
                fileParser = new HtmlParser(fileName);
            }
            else if (fileName.EndsWith("xml"))
            {
                fileParser = new XmlParser(fileName);
            }
            else if (fileName.EndsWith("rtf"))
            {
                fileParser = new RtfParser(fileName);
            }
            else
            {
                return null;
            }

            return fileParser;
        }
    }
}
