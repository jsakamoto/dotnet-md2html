using System;
using System.IO;
using Markdig.Renderers;
using Markdig.Renderers.Html.Inlines;
using Markdig.Syntax.Inlines;

namespace DotNet.MarkdownToHtml.Internals
{
    public class EmbeddedImageLinkInlineRenderer : LinkInlineRenderer
    {
        private string BaseDirectory { get; }

        public EmbeddedImageLinkInlineRenderer(string baseDirectory)
        {
            BaseDirectory = baseDirectory;
        }

        protected override void Write(HtmlRenderer renderer, LinkInline link)
        {
            if (link.IsImage)
            {
                var url = link.GetDynamicUrl?.Invoke() ?? link.Url;
                if (!url.StartsWith("data:") && !(new Uri(url, UriKind.RelativeOrAbsolute).IsAbsoluteUri))
                {
                    if (!string.IsNullOrEmpty(this.BaseDirectory)) url = Path.Combine(this.BaseDirectory, url);
                    if (File.Exists(url))
                    {
                        var contentBytes = File.ReadAllBytes(url);
                        var base64Str = Convert.ToBase64String(contentBytes);
                        var imageType = Path.GetExtension(url).TrimStart('.').ToLower();
                        link.GetDynamicUrl = () => $"data:image/{imageType};base64,{base64Str}";
                    }
                }
            }

            base.Write(renderer, link);
        }
    }
}
