using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source SVG file
        string svgFilePath = "input.svg";

        // Load the SVG image into an ISvgImage instance
        Aspose.Slides.ISvgImage svgImage = new Aspose.Slides.SvgImage(svgFilePath);

        // Create a new presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
        {
            // Get the first slide of the presentation
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Define the position and size for the group shape that will contain the SVG shapes
            float x = 0f;
            float y = 0f;
            float width = 500f;
            float height = 500f;

            // Add a group shape to the slide, converting the SVG image into individual shapes
            Aspose.Slides.IGroupShape groupShape = slide.Shapes.AddGroupShape(svgImage, x, y, width, height);

            // Save the presentation to a PPTX file
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}