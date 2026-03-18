using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace EmbedModuleToPptx
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Access the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a rectangle shape to hold the text
                Aspose.Slides.IAutoShape textShape = slide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle,
                    50f, 50f, 600f, 400f);

                // Add a text frame to the shape
                Aspose.Slides.ITextFrame textFrame = textShape.AddTextFrame(string.Empty);

                // Get the first paragraph and portion to set the text
                Aspose.Slides.IParagraph paragraph = textFrame.Paragraphs[0];
                Aspose.Slides.IPortion portion = paragraph.Portions[0];

                // Module source code to embed
                string moduleSource = @"// Sample module source code
public class SampleModule
{
    public void Execute()
    {
        // Implementation here
    }
}";

                // Set the text of the portion
                portion.Text = moduleSource;

                // Save the presentation
                presentation.Save("ModulePresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}