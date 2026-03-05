using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Define the slide range to be shown in the slide show (slides 1 to 3)
        presentation.SlideShowSettings.Slides = new Aspose.Slides.SlidesRange { Start = 1, End = 3 };

        // Save the presentation to a PPTX file
        presentation.Save("SelectSlides_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}