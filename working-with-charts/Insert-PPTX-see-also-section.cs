using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace MyPresentationApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
                {
                    // Add a new slide for the "See also" section
                    Aspose.Slides.ISlide seeAlsoSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

                    // Add a rectangle shape to contain the reference text
                    Aspose.Slides.IAutoShape textShape = seeAlsoSlide.Shapes.AddAutoShape(
                        Aspose.Slides.ShapeType.Rectangle, 50, 100, 600, 300);

                    // Insert the "See also" content
                    textShape.AddTextFrame("See also:\n- Slide 2: Introduction\n- Slide 3: Summary");

                    // Save the presentation
                    presentation.Save("SeeAlsoPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}