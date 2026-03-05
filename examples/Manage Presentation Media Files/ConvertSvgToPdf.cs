using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Load SVG content from a file
        string svgPath = "example.svg";
        string svgContent = File.ReadAllText(svgPath);

        // Create an SVG image object
        Aspose.Slides.ISvgImage svgImage = new Aspose.Slides.SvgImage(svgContent);

        // Create a new presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
        {
            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add the SVG as a group shape to the slide (position and size can be adjusted)
            Aspose.Slides.IGroupShape groupShape = slide.Shapes.AddGroupShape(svgImage, 0f, 0f, 500f, 500f);

            // Example: modify the first shape inside the group (e.g., change its name)
            if (groupShape.Shapes.Count > 0)
            {
                Aspose.Slides.IShape innerShape = groupShape.Shapes[0];
                innerShape.Name = "EditedShape";
            }

            // Save the presentation as PPTX
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

            // Save the presentation as PDF
            presentation.Save("output.pdf", Aspose.Slides.Export.SaveFormat.Pdf);
        }
    }
}