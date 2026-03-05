using System;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Set zoom (scale) for slide view and notes view (percentage)
        presentation.ViewProperties.SlideViewProperties.Scale = 150;
        presentation.ViewProperties.NotesViewProperties.Scale = 150;

        // Add a second slide to serve as the target of the zoom frame
        Aspose.Slides.ISlide targetSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);

        // Add a Zoom Frame on the first slide linking to the second slide
        Aspose.Slides.IZoomFrame zoomFrame = presentation.Slides[0].Shapes.AddZoomFrame(100f, 100f, 200f, 150f, targetSlide);

        // Configure Zoom Frame properties
        zoomFrame.TransitionDuration = 2.0f;   // Duration of transition in seconds
        zoomFrame.ShowBackground = false;     // Do not show background of target slide
        zoomFrame.ReturnToParent = true;      // Enable return to parent navigation

        // Save the presentation
        presentation.Save("ManagedZoom.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}