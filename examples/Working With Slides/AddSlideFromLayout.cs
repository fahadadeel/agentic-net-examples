using System;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first layout slide from the presentation's layout collection
        Aspose.Slides.ILayoutSlide layoutSlide = presentation.LayoutSlides[0];

        // Add a new empty slide based on the selected layout
        Aspose.Slides.ISlide newSlide = presentation.Slides.AddEmptySlide(layoutSlide);

        // Save the presentation to a file
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}