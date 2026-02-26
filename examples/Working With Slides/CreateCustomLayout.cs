using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace CustomLayoutExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Get the first master slide
            IMasterSlide masterSlide = presentation.Masters[0];

            // Add a custom layout slide to the presentation
            ILayoutSlide customLayout = presentation.LayoutSlides.Add(masterSlide, SlideLayoutType.Custom, "MyCustomLayout");

            // Add a new slide using the custom layout
            ISlide newSlide = presentation.Slides.AddEmptySlide(customLayout);

            // Save the presentation
            presentation.Save("CustomLayoutPresentation.pptx", SaveFormat.Pptx);
        }
    }
}