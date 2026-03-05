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
            // Path to the source SVG file
            string svgPath = "content.svg";

            // Create a new presentation
            using (Presentation presentation = new Presentation())
            {
                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Load the SVG image from file
                ISvgImage svgImage = new SvgImage(File.ReadAllText(svgPath));

                // Define position and size for the group shape (in points)
                float x = 100f;
                float y = 100f;
                float width = 400f;
                float height = 300f;

                // Convert the SVG image into a group shape and add it to the slide
                IGroupShape groupShape = slide.Shapes.AddGroupShape(svgImage, x, y, width, height);

                // Optionally, you can manipulate the group shape here (e.g., rotate, set fill, etc.)

                // Save the presentation as PDF
                presentation.Save("Output.pdf", SaveFormat.Pdf);
            }
        }
    }
}