using System.IO;
using DotNet.MarkdownToHtml.Internals;
using Markdig;

namespace DotNet.MarkdownToHtml
{
    public static class MarkdownToHtmlConverter
    {
        public static void Convert(TextReader input, TextWriter output, MarkdownToHtmlConverterOptions options)
        {
            var markdownText = input.ReadToEnd();

            var pipelineBulder = new MarkdownPipelineBuilder()
                .UseAdvancedExtensions();
            if (options.EmbedImage) pipelineBulder.Use(new EmbeddedImageExtension(options.BaseDirectory));

            var pipeline = pipelineBulder.Build();
            var htmlBodyText = Markdown.ToHtml(markdownText, pipeline);

            var styleText = GetDefaultStyleText();

            output.WriteLine("<!DOCTYPE html>");
            output.WriteLine("<html>");
            output.WriteLine("<head>");
            output.WriteLine("<style>");
            output.WriteLine(styleText);
            output.WriteLine("</style>");
            output.WriteLine("</head>");
            output.WriteLine("<body class=\"markdown-body\">");

            output.WriteLine(htmlBodyText);

            output.WriteLine("</body>");
            output.WriteLine("</html>");
            output.Flush();
        }

        private static string GetDefaultStyleText()
        {
            using (var defaultStyleStream = typeof(MarkdownToHtmlConverter).Assembly.GetManifestResourceStream(nameof(DotNet) + "." + nameof(DotNet.MarkdownToHtml) + ".github-markdown.css"))
            using (var styleReader = new StreamReader(defaultStyleStream))
            {
                return styleReader.ReadToEnd();
            }
        }
    }
}
