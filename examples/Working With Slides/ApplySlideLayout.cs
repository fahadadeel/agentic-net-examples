using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first master slide from the presentation
        Aspose.Slides.IMasterSlide masterSlide = presentation.Masters[0];

        // Add a new layout slide (TitleOnly) to the presentation
        Aspose.Slides.ILayoutSlide customLayout = presentation.LayoutSlides.Add(masterSlide, SlideLayoutType.TitleOnly, "CustomTitleLayout");

        // Add a new empty slide using the default first layout slide
        Aspose.Slides.ISlide newSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

        // Apply the custom layout to the newly added slide
        newSlide.LayoutSlide = customLayout;

        // Save the presentation to a file
        presentation.Save("Output.pptx", SaveFormat.Pptx);
    }
}