using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesSvgExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Load SVG content from a file
            string svgPath = "example.svg";
            string svgContent = File.ReadAllText(svgPath);
            ISvgImage svgImage = new SvgImage(svgContent);

            // Add the SVG image to the presentation's image collection
            IPPImage addedImage = presentation.Images.AddImage(svgImage);

            // Add the SVG image to the first slide as a picture frame
            // Parameters: shape type, X, Y, width, height, image
            presentation.Slides[0].Shapes.AddPictureFrame(
                ShapeType.Rectangle,
                50f,
                50f,
                400f,
                300f,
                addedImage
            );

            // Save the presentation to a PPTX file
            presentation.Save("PresentationWithSvg.pptx", SaveFormat.Pptx);
        }
    }
}