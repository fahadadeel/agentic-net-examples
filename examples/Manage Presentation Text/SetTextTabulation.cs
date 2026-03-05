using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SetTextTabulationExample
{
    class Program
    {
        static void Main()
        {
            // Define output directory and file name
            System.String outputDir = "Output";
            if (!System.IO.Directory.Exists(outputDir))
                System.IO.Directory.CreateDirectory(outputDir);
            System.String outPath = System.IO.Path.Combine(outputDir, "SetTextTabulation_out.pptx");

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle AutoShape
            Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 100, 100, 400, 200);

            // Add a TextFrame with tab-separated text
            shape.AddTextFrame("Column1\tColumn2\tColumn3");

            // Access the first paragraph of the TextFrame
            Aspose.Slides.IParagraph paragraph = shape.TextFrame.Paragraphs[0];

            // Add tab stops at desired positions (in points) with left alignment
            paragraph.ParagraphFormat.Tabs.Add(100.0, Aspose.Slides.TabAlignment.Left);
            paragraph.ParagraphFormat.Tabs.Add(200.0, Aspose.Slides.TabAlignment.Left);
            paragraph.ParagraphFormat.Tabs.Add(300.0, Aspose.Slides.TabAlignment.Left);

            // Save the presentation to the specified path
            presentation.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose the presentation object
            presentation.Dispose();
        }
    }
}