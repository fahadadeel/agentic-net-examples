using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first master slide
        Aspose.Slides.IMasterSlide masterSlide = presentation.Masters[0];

        // Add a custom layout slide to the presentation
        Aspose.Slides.ILayoutSlide customLayout = presentation.LayoutSlides.Add(masterSlide, Aspose.Slides.SlideLayoutType.Custom, "MyCustomLayout");

        // Add a new empty slide using the custom layout
        Aspose.Slides.ISlide newSlide = presentation.Slides.AddEmptySlide(customLayout);

        // Save the presentation
        presentation.Save("CustomLayoutPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}