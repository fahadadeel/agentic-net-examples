using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first master slide in the presentation
        Aspose.Slides.IMasterSlide masterSlide = presentation.Masters[0];

        // Choose a predefined layout from the master slide (e.g., the first layout)
        Aspose.Slides.ILayoutSlide layoutSlide = masterSlide.LayoutSlides[0];

        // Add a new slide based on the selected layout
        Aspose.Slides.ISlide newSlide = presentation.Slides.AddEmptySlide(layoutSlide);

        // Save the presentation to a file
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}