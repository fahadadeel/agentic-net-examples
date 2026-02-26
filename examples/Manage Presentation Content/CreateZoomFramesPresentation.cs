using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a second slide to serve as the target of the zoom frame
        Aspose.Slides.ISlide targetSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);

        // Add a zoom frame on the first slide that links to the second slide
        Aspose.Slides.IZoomFrame zoomFrame = presentation.Slides[0].Shapes.AddZoomFrame(150f, 20f, 100f, 100f, targetSlide);

        // Set a name for the zoom frame
        zoomFrame.Name = "MyZoomFrame";

        // Save the presentation to a PPTX file
        presentation.Save("ZoomPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}