using System;
using System.Drawing;
using Aspose.Slides;

namespace ZoomFramesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a second slide to link the zoom frame to
            Aspose.Slides.ISlide targetSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);

            // Add a zoom frame on the first slide referencing the second slide
            Aspose.Slides.IZoomFrame zoomFrame = presentation.Slides[0].Shapes.AddZoomFrame(150f, 20f, 100f, 100f, targetSlide);

            // Set zoom frame properties
            zoomFrame.ShowBackground = false;               // Do not show background of target slide
            zoomFrame.TransitionDuration = 2.0f;            // Set transition duration

            // Optionally set alternative text
            zoomFrame.AlternativeText = "Zoom to second slide";

            // Save the presentation
            presentation.Save("ZoomFrames_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}