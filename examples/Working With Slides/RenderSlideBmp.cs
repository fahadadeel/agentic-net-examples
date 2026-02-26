using System;
using System.IO;
using System.Drawing.Imaging;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Paths for input presentation and output files
        string inputPath = "input.pptx";
        string outputImagePath = "slide_0.bmp";
        string outputPresentationPath = "output.pptx";

        // Load the presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
        {
            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Render the slide to an image
            using (Aspose.Slides.IImage image = slide.GetImage())
            {
                // Save the image as BMP
                image.Save(outputImagePath, ImageFormat.Bmp);
            }

            // Save the presentation before exiting
            presentation.Save(outputPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}