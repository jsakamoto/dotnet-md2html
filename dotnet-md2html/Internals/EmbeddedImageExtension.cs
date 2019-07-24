using Markdig;
using Markdig.Renderers;
using Markdig.Renderers.Html.Inlines;

namespace DotNet.MarkdownToHtml.Internals
{
    public class EmbeddedImageExtension : IMarkdownExtension
    {
        private string BaseDirectory { get; }

        public EmbeddedImageExtension(string baseDirectory)
        {
            BaseDirectory = baseDirectory;
        }

        public void Setup(MarkdownPipelineBuilder pipeline)
        {
        }

        public void Setup(MarkdownPipeline pipeline, IMarkdownRenderer renderer)
        {
            var index = renderer.ObjectRenderers.FindIndex(r => r.GetType() == typeof(LinkInlineRenderer));
            renderer.ObjectRenderers[index] = new EmbeddedImageLinkInlineRenderer(this.BaseDirectory);
        }
    }
}
