using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get a layout slide from the first master slide
        Aspose.Slides.ILayoutSlide layout = presentation.Masters[0].LayoutSlides[0];

        // Add a new empty slide using the selected layout
        Aspose.Slides.ISlide newSlide = presentation.Slides.AddEmptySlide(layout);

        // Save the presentation to a file
        presentation.Save("AddedSlide.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}