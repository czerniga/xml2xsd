# XML Schema Generator

[![Action Status](https://github.com/czerniga/xml2xsd/workflows/.NET%20Core/badge.svg)](https://github.com/czerniga/xml2xsd/actions)

## Introduction
This project contains a simple console application whose purpose is to automatically generate [XSD](https://en.wikipedia.org/wiki/XML_Schema_(W3C)) from the input XML file (STDIN). The application uses standard functions available in .net core 2.0.

## Example
This is a simple example on how to generate XSD from XML in console:
```console
cat test.xml | dotnet "run" "--project" "xml2xsd.console\xml2xsd.console.csproj"
```
This example works on windows (powershell) and linux.

## License
[![MIT License](https://img.shields.io/apm/l/atomic-design-ui.svg?)](https://github.com/tterb/atomic-design-ui/blob/master/LICENSEs)