using System;
using Aspose.Slides;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first master slide
            Aspose.Slides.IMasterSlide master = presentation.Masters[0];

            // Get the first layout slide from the master
            Aspose.Slides.ILayoutSlide layout = master.LayoutSlides[0];

            // Add a new empty slide based on the selected layout
            Aspose.Slides.ISlide newSlide = presentation.Slides.AddEmptySlide(layout);

            // Save the presentation
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}