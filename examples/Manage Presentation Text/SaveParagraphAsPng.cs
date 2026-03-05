using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Define input and output directories
        string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
        if (!Directory.Exists(dataDir))
            Directory.CreateDirectory(dataDir);

        // Paths for the source PPTX and the resulting PNG
        string pptxPath = Path.Combine(dataDir, "input.pptx");
        string outPngPath = Path.Combine(dataDir, "paragraph.png");

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(pptxPath);

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Assume the first shape is an AutoShape containing the paragraph
        Aspose.Slides.IAutoShape autoShape = slide.Shapes[0] as Aspose.Slides.IAutoShape;
        if (autoShape != null)
        {
            // Render the shape (paragraph) to an image
            Aspose.Slides.IImage shapeImage = autoShape.GetImage();

            // Save the image as PNG
            shapeImage.Save(outPngPath, Aspose.Slides.ImageFormat.Png);
        }

        // Save the (potentially modified) presentation before exiting
        string outPptxPath = Path.Combine(dataDir, "output.pptx");
        presentation.Save(outPptxPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}