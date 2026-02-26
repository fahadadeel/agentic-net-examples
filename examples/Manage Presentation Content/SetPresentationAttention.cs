using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

namespace SetPresentationAttention
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.ppt";

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Get the first shape on the first slide (assumed to be an AutoShape)
            Aspose.Slides.AutoShape autoShape = (Aspose.Slides.AutoShape)presentation.Slides[0].Shapes[0];

            // Highlight the word "Attention" with Yellow color
            autoShape.TextFrame.HighlightText("Attention", System.Drawing.Color.Yellow);

            // Highlight the word "Important" with Red color, whole words only
            autoShape.TextFrame.HighlightText(
                "Important",
                System.Drawing.Color.Red,
                new Aspose.Slides.TextSearchOptions() { WholeWordsOnly = true },
                null);

            // Save the modified presentation in PPT format
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Ppt);

            // Release resources
            presentation.Dispose();
        }
    }
}