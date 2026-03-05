using System;
using System.Text;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input PowerPoint file and output HTML file paths
        string inputPath = "sample.pptx";
        string htmlOutputPath = "output.html";

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Options for HTML conversion
        Aspose.Slides.Export.TextToHtmlConversionOptions options = new Aspose.Slides.Export.TextToHtmlConversionOptions();

        // StringBuilder to accumulate HTML from all paragraphs
        StringBuilder htmlBuilder = new StringBuilder();

        // Iterate through all slides
        foreach (Aspose.Slides.ISlide slide in presentation.Slides)
        {
            // Iterate through all shapes on the slide
            foreach (Aspose.Slides.IShape shape in slide.Shapes)
            {
                // Process only AutoShapes that contain a TextFrame
                if (shape is Aspose.Slides.IAutoShape)
                {
                    Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)shape;
                    if (autoShape.TextFrame != null)
                    {
                        // Get the paragraph collection from the TextFrame
                        Aspose.Slides.IParagraphCollection paragraphs = autoShape.TextFrame.Paragraphs;

                        // Export all paragraphs to HTML
                        string html = paragraphs.ExportToHtml(0, paragraphs.Count, options);

                        // Append the generated HTML
                        htmlBuilder.AppendLine(html);
                    }
                }
            }
        }

        // Write the accumulated HTML to a file
        File.WriteAllText(htmlOutputPath, htmlBuilder.ToString());

        // Save the presentation before exiting (optional, can be the same file or a new one)
        presentation.Save("saved.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}