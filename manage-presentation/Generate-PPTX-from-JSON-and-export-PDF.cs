using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PresentationToPdf
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

                // Add a rectangle shape to the slide
                slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 200);

                // Save the presentation as PDF
                presentation.Save("Presentation.pdf", Aspose.Slides.Export.SaveFormat.Pdf);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}