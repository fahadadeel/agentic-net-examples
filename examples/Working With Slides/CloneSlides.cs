using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace CloneMultipleSlides
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a shape to the first slide (so we have something to clone)
            presentation.Slides[0].Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle,
                50, 50, 200, 100);

            // Get the slide collection
            Aspose.Slides.ISlideCollection slides = presentation.Slides;

            // Clone the first slide multiple times (e.g., 3 additional copies)
            for (int i = 0; i < 3; i++)
            {
                slides.AddClone(slides[0]);
            }

            // Save the presentation
            presentation.Save("ClonedSlides_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}