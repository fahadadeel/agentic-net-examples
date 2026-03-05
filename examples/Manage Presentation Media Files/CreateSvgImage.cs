using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SvgImageInsertExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Read SVG content from a file
            string svgContent = File.ReadAllText("content.svg");

            // Create an SVG image object
            Aspose.Slides.ISvgImage svgImage = new Aspose.Slides.SvgImage(svgContent);

            // Add the SVG image to the presentation's image collection
            Aspose.Slides.IPPImage ppImage = pres.Images.AddImage(svgImage);

            // Optionally, you could add a picture shape that uses the image
            // Aspose.Slides.IShape pictureShape = pres.Slides[0].Shapes.AddPictureFrame(
            //     Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 300, ppImage);

            // Save the presentation
            pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}