using System;
using xml2xsd.lib;

namespace xml2xsd.console
{
    enum ExitCode : int {
        Success = 0,
        Error = -1
    }

    class Program
    {
        static int Main(string[] args)
        {
            String inputXml = "";

            // if nothing is being piped in, then exit
            if (!IsPipedInput()){
                Console.WriteLine("Wrong number of arguments.");
                return (int)ExitCode.Error;
            } else {

                while (Console.In.Peek() != -1)
                {
                    inputXml += Console.In.ReadLine();
                }

                String xsd = new XsdGenerator().Generate(inputXml);
                Console.WriteLine(xsd);
                return (int)ExitCode.Success;
            }
        }

        private static bool IsPipedInput()
        {
            try
            {
                bool isKey = Console.KeyAvailable;
                return false;
            }
            catch
            {
                return true;
            }
        }
    }
}
