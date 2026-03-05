using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load an existing presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Set zoom (scale) for slide view and notes view (percentage)
        presentation.ViewProperties.SlideViewProperties.Scale = 150; // 150%
        presentation.ViewProperties.NotesViewProperties.Scale = 150; // 150%

        // Add a ZoomFrame on the first slide that links to the second slide (if it exists)
        if (presentation.Slides.Count > 1)
        {
            Aspose.Slides.IZoomFrame zoomFrame = presentation.Slides[0].Shapes.AddZoomFrame(100f, 100f, 200f, 150f, presentation.Slides[1]);
            // Configure the ZoomFrame
            zoomFrame.ShowBackground = false;      // Do not show background of target slide
            zoomFrame.ReturnToParent = true;       // Return to parent slide after zoom
        }

        // Save the modified presentation
        presentation.Save("output.pptx", SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}