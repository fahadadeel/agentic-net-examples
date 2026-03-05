using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Paths for input PPTX and output PDF
        string inputPptx = "input.pptx";
        string outputPdf = "output.pdf";

        // Load the source presentation
        Aspose.Slides.Presentation sourcePres = new Aspose.Slides.Presentation(inputPptx);

        // Access the first slide
        Aspose.Slides.ISlide sourceSlide = sourcePres.Slides[0];

        // Assume the first shape is an AutoShape containing the paragraph to export
        Aspose.Slides.IAutoShape sourceShape = (Aspose.Slides.IAutoShape)sourceSlide.Shapes[0];

        // Define scaling factors for the shape thumbnail (full size)
        float scaleX = 1f;
        float scaleY = 1f;

        // Generate a thumbnail image of the shape (the paragraph)
        Aspose.Slides.IImage shapeImage = sourceShape.GetImage(Aspose.Slides.ShapeThumbnailBounds.Shape, scaleX, scaleY);

        // Create a new presentation that will hold the shape image
        Aspose.Slides.Presentation imagePres = new Aspose.Slides.Presentation();

        // Get the first slide of the new presentation
        Aspose.Slides.ISlide imageSlide = imagePres.Slides[0];

        // Add the shape image to the presentation's image collection
        Aspose.Slides.IPPImage ippImage = imagePres.Images.AddImage(shapeImage);

        // Insert a picture frame containing the shape image onto the slide
        Aspose.Slides.IPictureFrame pictureFrame = imageSlide.Shapes.AddPictureFrame(
            Aspose.Slides.ShapeType.Rectangle,
            0f,
            0f,
            sourceShape.Width,
            sourceShape.Height,
            ippImage);

        // Save the new presentation as a PDF (the paragraph image is now in the PDF)
        imagePres.Save(outputPdf, Aspose.Slides.Export.SaveFormat.Pdf);

        // Save the original presentation (optional, ensures lifecycle compliance)
        sourcePres.Save("source_saved.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}