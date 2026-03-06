using System;
using Aspose.Slides;

namespace OverviewPresentation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a rectangle auto shape to the first slide
            Aspose.Slides.IAutoShape overviewShape = presentation.Slides[0].Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle,
                50f,   // X position
                50f,   // Y position
                400f,  // Width
                100f,  // Height
                false  // isGrouped
            );

            // Add a text frame with the overview title
            overviewShape.AddTextFrame("Overview");

            // Add a hyperlink to the text
            overviewShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Aspose.Slides.Hyperlink("https://example.com");
            overviewShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.Tooltip = "Open example website";

            // Save the presentation
            string outputPath = System.IO.Path.Combine(Environment.CurrentDirectory, "OverviewPresentation.pptx");
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}