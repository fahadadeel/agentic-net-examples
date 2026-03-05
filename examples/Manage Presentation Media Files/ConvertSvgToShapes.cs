using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SvgToShapesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the SVG file to be converted
            string svgPath = "input.svg";

            // Read SVG content from file
            string svgContent = File.ReadAllText(svgPath);

            // Create an SVG image object from the SVG content
            Aspose.Slides.ISvgImage svgImage = new Aspose.Slides.SvgImage(svgContent);

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide of the presentation
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a group shape to the slide by converting the SVG image into individual shapes
            // Parameters: svgImage, x position, y position, width, height (in points)
            Aspose.Slides.IGroupShape groupShape = slide.Shapes.AddGroupShape(svgImage, 0f, 0f, 500f, 500f);

            // Optionally, set the name of the group shape for identification
            groupShape.Name = "ConvertedSvgGroup";

            // Save the presentation to a PPTX file
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}