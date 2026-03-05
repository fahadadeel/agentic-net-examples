using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load an existing PPTX file
        Presentation presentation = new Presentation("input.pptx");

        // Get the first master slide from the presentation
        IMasterSlide masterSlide = presentation.Masters[0];

        // Add a custom layout slide to the presentation
        ILayoutSlide customLayout = presentation.LayoutSlides.Add(masterSlide, SlideLayoutType.Custom, "MyCustomLayout");

        // Add a new empty slide that uses the custom layout
        ISlide newSlide = presentation.Slides.AddEmptySlide(customLayout);

        // Save the modified presentation
        presentation.Save("output.pptx", SaveFormat.Pptx);
    }
}