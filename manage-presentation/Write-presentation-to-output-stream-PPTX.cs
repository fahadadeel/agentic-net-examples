using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PresentationToStreamExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                using (Presentation presentation = new Presentation())
                {
                    // Add a simple slide (optional)
                    ISlide slide = presentation.Slides[0];
                    slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 200).TextFrame.Text = "Hello, Aspose.Slides!";

                    // Define output file path
                    string outputPath = "output.pptx";

                    // Create a file stream for writing
                    using (FileStream fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                    {
                        // Save presentation directly to the stream in PPTX format
                        presentation.Save(fileStream, Aspose.Slides.Export.SaveFormat.Pptx);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}