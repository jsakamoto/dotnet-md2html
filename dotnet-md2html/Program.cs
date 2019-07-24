using System;
using System.IO;
using System.Text;
using CommandLineSwitchParser;

namespace DotNet.MarkdownToHtml
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!CommandLineSwitch.TryParse<CommandLineOptions>(ref args, out var cmdLineOptions, out var parserError))
            {
                Console.WriteLine(parserError.ToString());
                return;
            }
            if (cmdLineOptions.Version)
            {
                Console.WriteLine("ver." + typeof(Program).Assembly.GetName().Version.ToString(3));
                return;
            }

            var converterOptions = new MarkdownToHtmlConverterOptions
            {
                BaseDirectory = !string.IsNullOrEmpty(cmdLineOptions.InputPath) ? Path.GetDirectoryName(cmdLineOptions.InputPath) : null,
                EmbedImage = cmdLineOptions.EmbedImage
            };

            var input = Console.In;
            var output = Console.Out;
            if (!string.IsNullOrEmpty(cmdLineOptions.InputPath))
            {
                input = new StreamReader(cmdLineOptions.InputPath, encoding: Encoding.UTF8);
            }
            if (!string.IsNullOrEmpty(cmdLineOptions.OutputPath))
            {
                output = new StreamWriter(cmdLineOptions.OutputPath, append: false, encoding: Encoding.UTF8);
            }

            MarkdownToHtmlConverter.Convert(input, output, converterOptions);
        }
    }
}
