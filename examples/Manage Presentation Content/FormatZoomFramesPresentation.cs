using System;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide (already exists)
        Aspose.Slides.ISlide firstSlide = presentation.Slides[0];

        // Add two more empty slides for linking
        Aspose.Slides.ISlide secondSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
        Aspose.Slides.ISlide thirdSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);

        // Add a Zoom frame on the first slide that links to the second slide
        Aspose.Slides.IZoomFrame zoomFrame = firstSlide.Shapes.AddZoomFrame(150f, 20f, 100f, 100f, secondSlide);

        // Change the target slide of the zoom frame to the third slide
        zoomFrame.TargetSlide = thirdSlide;

        // Disable background usage for the zoom frame
        zoomFrame.ShowBackground = false;

        // Save the presentation
        presentation.Save("ZoomFramesDemo.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}