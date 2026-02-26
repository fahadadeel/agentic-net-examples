using System;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Set slide size to a predefined type (16:9) without scaling existing content
        presentation.SlideSize.SetSize(Aspose.Slides.SlideSizeType.OnScreen16x9, Aspose.Slides.SlideSizeScaleType.DoNotScale);

        // Set a custom slide size: 10 inches wide by 7.5 inches high
        // 1 inch = 72 points, so convert inches to points
        float widthInPoints = 10f * 72f;
        float heightInPoints = 7.5f * 72f;
        presentation.SlideSize.SetSize(widthInPoints, heightInPoints, Aspose.Slides.SlideSizeScaleType.EnsureFit);

        // Save the presentation before exiting
        presentation.Save("SlideSizeExample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}