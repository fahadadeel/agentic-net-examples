using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Create a new presentation inside a using block to ensure disposal
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
        {
            // Read SVG content from a file
            string svgContent = File.ReadAllText("content.svg");

            // Create an SVG image object
            Aspose.Slides.SvgImage svgImage = new Aspose.Slides.SvgImage(svgContent);

            // Add the SVG image to the presentation and obtain the PPImage
            Aspose.Slides.IPPImage ippImage = presentation.Images.AddImage(svgImage);
            Aspose.Slides.PPImage ppImage = (Aspose.Slides.PPImage)ippImage;

            // Access the SvgImage property if needed
            Aspose.Slides.ISvgImage retrievedSvg = ppImage.SvgImage;

            // Save the presentation
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}