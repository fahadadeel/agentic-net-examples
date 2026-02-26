using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Path to the SVG file to be added
        string svgFilePath = "example.svg";
        // Path where the resulting presentation will be saved
        string outputPresentationPath = "output.pptx";

        // Create a new presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
        {
            // Load the SVG image from file
            Aspose.Slides.ISvgImage svgImage = new Aspose.Slides.SvgImage(svgFilePath);

            // Add the SVG image to the presentation's image collection
            Aspose.Slides.IPPImage ppImage = presentation.Images.AddImage(svgImage);

            // Insert the SVG image onto the first slide as a picture frame
            Aspose.Slides.IShape shape = presentation.Slides[0].Shapes.AddPictureFrame(
                Aspose.Slides.ShapeType.Rectangle,
                50, 50, 400, 300,
                ppImage);

            // Optional: Export the inserted shape as an SVG file
            using (FileStream shapeSvgStream = new FileStream("shape_output.svg", FileMode.Create))
            {
                shape.WriteAsSvg(shapeSvgStream);
            }

            // Save the presentation to disk
            presentation.Save(outputPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}