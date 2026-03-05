using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Path to the source presentation file
        string sourcePath = "input.pptx";

        // Load the presentation from the file
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePath))
        {
            // ID of the slide to retrieve (example value)
            uint slideId = 2;

            // Retrieve the slide (or master/layout) by its ID
            Aspose.Slides.IBaseSlide baseSlide = presentation.GetSlideById(slideId);

            // Attempt to cast to a regular slide
            Aspose.Slides.ISlide slide = baseSlide as Aspose.Slides.ISlide;

            if (slide != null)
            {
                Console.WriteLine("Slide found. Slide ID: " + slide.SlideId);
            }
            else
            {
                Console.WriteLine("Slide not found or is not a regular slide.");
            }

            // Save the (potentially unchanged) presentation before exiting
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}