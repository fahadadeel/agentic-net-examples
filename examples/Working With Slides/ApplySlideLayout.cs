using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideLayoutExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first master slide from the presentation
            Aspose.Slides.IMasterSlide masterSlide = presentation.Masters[0];

            // Add a new layout slide of type Title to the presentation
            Aspose.Slides.IGlobalLayoutSlideCollection layoutCollection = presentation.LayoutSlides;
            Aspose.Slides.ILayoutSlide titleLayout = layoutCollection.Add(masterSlide, SlideLayoutType.Title, "MyTitleLayout");

            // Add a new empty slide using the created layout slide
            Aspose.Slides.ISlide newSlide = presentation.Slides.AddEmptySlide(titleLayout);

            // Optionally, you can set the layout slide explicitly (already set by AddEmptySlide)
            newSlide.LayoutSlide = titleLayout;

            // Save the presentation to a file
            presentation.Save("LayoutExample.pptx", SaveFormat.Pptx);
        }
    }
}