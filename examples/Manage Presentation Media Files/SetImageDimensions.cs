using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Set custom slide size (width: 960 points, height: 540 points) without scaling existing content
        presentation.SlideSize.SetSize(960f, 540f, Aspose.Slides.SlideSizeScaleType.DoNotScale);

        // Save the presentation to disk
        presentation.Save("CustomSizePresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}