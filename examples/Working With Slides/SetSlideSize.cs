using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Set slide size to a predefined 16:9 on‑screen size without scaling existing content
        presentation.SlideSize.SetSize(Aspose.Slides.SlideSizeType.OnScreen16x9, Aspose.Slides.SlideSizeScaleType.DoNotScale);

        // Set a custom slide size (width: 1024 points, height: 768 points) and ensure content fits
        presentation.SlideSize.SetSize(1024f, 768f, Aspose.Slides.SlideSizeScaleType.EnsureFit);

        // Save the presentation to a file
        presentation.Save("SlideSizeExample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}