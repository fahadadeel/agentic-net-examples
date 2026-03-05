using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SaveParagraphAsImage
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output directory and ensure it exists
            string outDir = "Output";
            if (!Directory.Exists(outDir))
                Directory.CreateDirectory(outDir);

            // Define file paths
            string pptxPath = Path.Combine(outDir, "presentation.pptx");
            string imgPath = Path.Combine(outDir, "paragraph.png");

            // Create a new presentation
            Presentation presentation = new Presentation();

            // Access the first slide
            ISlide slide = presentation.Slides[0];

            // Add a rectangle auto shape to hold the paragraph
            IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);

            // Get the text frame of the shape
            ITextFrame textFrame = autoShape.TextFrame;

            // Create a new paragraph with desired text
            Paragraph paragraph = new Paragraph();
            paragraph.Text = "This paragraph will be saved as an image.";

            // Add the paragraph to the text frame
            textFrame.Paragraphs.Add(paragraph);

            // Render the shape (which contains the paragraph) to an image
            IImage shapeImage = autoShape.GetImage();

            // Save the rendered image as PNG
            shapeImage.Save(imgPath, ImageFormat.Png);

            // Save the presentation as PPTX
            presentation.Save(pptxPath, SaveFormat.Pptx);

            // Clean up resources
            presentation.Dispose();
        }
    }
}