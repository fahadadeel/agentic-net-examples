using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
        {
            // Get the slide collection
            Aspose.Slides.ISlideCollection slides = presentation.Slides;

            // Add a second empty slide at the end (the presentation already contains one slide)
            Aspose.Slides.ISlide secondSlide = slides.AddEmptySlide(presentation.LayoutSlides[0]);

            // Insert a new empty slide at index 1 (between the first and second slides)
            Aspose.Slides.ISlide insertedSlide = slides.InsertEmptySlide(1, presentation.LayoutSlides[0]);

            // Move the last slide (currently at index 2) to the first position (index 0)
            Aspose.Slides.ISlide slideToMove = slides[2];
            slides.Reorder(0, slideToMove);

            // Save the presentation in PPTX format
            presentation.Save("OrderedSlides.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}