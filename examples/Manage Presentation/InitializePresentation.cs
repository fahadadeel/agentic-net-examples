using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Set custom slide size (width: 960 points, height: 540 points)
        presentation.SlideSize.SetSize(960f, 540f, Aspose.Slides.SlideSizeScaleType.DoNotScale);

        // Save the presentation in PPTX format
        presentation.Save("CustomSizePresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}