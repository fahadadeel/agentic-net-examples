using System;
using Aspose.Slides;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Get the first master slide
            IMasterSlide masterSlide = presentation.Masters[0];

            // Add a custom layout to the master slide
            ILayoutSlide customLayout = masterSlide.LayoutSlides.Add(SlideLayoutType.Custom, "MyCustomLayout");

            // Add a new empty slide using the custom layout
            ISlide newSlide = presentation.Slides.AddEmptySlide(customLayout);

            // Alternatively, assign the custom layout to an existing slide
            // ISlide existingSlide = presentation.Slides[0];
            // existingSlide.LayoutSlide = customLayout;

            // Save the presentation
            presentation.Save("CustomLayoutPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}