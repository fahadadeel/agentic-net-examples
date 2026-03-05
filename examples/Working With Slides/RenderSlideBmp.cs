using System;
using System.Drawing.Imaging;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the PPTX presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Render the slide to an image
        Aspose.Slides.IImage image = slide.GetImage();

        // Save the image as BMP
        image.Save("slide_0.bmp", ImageFormat.Bmp);

        // Save the presentation before exiting
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up resources
        image.Dispose();
        presentation.Dispose();
    }
}