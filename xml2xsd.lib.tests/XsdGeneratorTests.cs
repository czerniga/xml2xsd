using System;
using Xunit;
using xml2xsd.lib;

namespace test_xml2xsd.lib
{
    public class XsdGeneratorTests
    {
        [Fact]
        public void GenerateTest()
        {
            String inputXml = @"<?xml version='1.0' encoding='UTF-8'?>
                <note>
                <to>Tove</to>
                <from>Jani</from>
                <heading>Reminder</heading>
                <body>Don't forget me this weekend!</body>
                </note>";
            String outputXml = "<?xml version=\"1.0\" encoding=\"utf-8\"?><xs:schema attributeFormDefault=\"unqualified\" elementFormDefault=\"qualified\" xmlns:xs=\"http://www.w3.org/2001/XMLSchema\"><xs:element name=\"note\"><xs:complexType><xs:sequence><xs:element name=\"to\" type=\"xs:string\" /><xs:element name=\"from\" type=\"xs:string\" /><xs:element name=\"heading\" type=\"xs:string\" /><xs:element name=\"body\" type=\"xs:string\" /></xs:sequence></xs:complexType></xs:element></xs:schema>";
            XsdGenerator generator = new XsdGenerator();
            Assert.Equal(outputXml, generator.Generate(inputXml));
        }
    }
}
