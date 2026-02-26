using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing.Imaging;

class Program
{
    static void Main()
    {
        // Load an existing presentation
        Presentation presentation = new Presentation("input.pptx");

        // Access the first slide
        ISlide slide = presentation.Slides[0];

        // Access the first shape on the slide (ensure there is at least one shape)
        IShape shape = slide.Shapes[0];

        // Generate a thumbnail image for the shape
        IImage shapeThumbnail = shape.GetImage();

        // Save the thumbnail image to disk with a chosen file name
        shapeThumbnail.Save("shape_thumbnail.png", ImageFormat.Png);

        // Save the presentation before exiting (no modifications made)
        presentation.Save("output.pptx", SaveFormat.Pptx);
    }
}