using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Schema;

namespace xml2xsd.lib
{
    public class XsdGenerator
    {
        public String Generate(String xml){
            
            String genertatedXsd = "";

            XmlReader reader = XmlReader.Create(new StringReader(xml));
            XmlSchemaSet schemaSet = new XmlSchemaSet();
            XmlSchemaInference schema = new XmlSchemaInference();
            schemaSet = schema.InferSchema(reader);
            XmlWriterSettings writerSettings = new XmlWriterSettings();

            foreach (XmlSchema s in schemaSet.Schemas())
            {
                StringBuilder sb = new StringBuilder(); 
                using (var stringWriter = new StringWriterWithEncoding(sb, Encoding.UTF8))
                {
                    using (var writer = XmlWriter.Create(stringWriter))
                    {
                        s.Write(writer);
                    }

                    genertatedXsd = stringWriter.ToString();
                }
            }
            
            return genertatedXsd;
        }

        public class StringWriterWithEncoding : StringWriter 
        { 
            public StringWriterWithEncoding(StringBuilder sb, Encoding encoding) 
                : base( sb ) 
            { 
                this.m_Encoding = encoding; 
            } 
            private readonly Encoding m_Encoding; 
            public override Encoding Encoding 
            { 
                get
                { 
                    return this.m_Encoding; 
                } 
            } 
        } 
    }
}
