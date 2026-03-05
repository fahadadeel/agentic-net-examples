using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Get the first slide (default slide)
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add a new empty slide that will be the target of the zoom
        Aspose.Slides.ISlide targetSlide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

        // Add a Zoom frame on the first slide linking to the target slide
        Aspose.Slides.IZoomFrame zoomFrame = slide.Shapes.AddZoomFrame(150f, 20f, 50f, 50f, targetSlide);

        // Set navigation behavior (return to parent slide after zoom)
        zoomFrame.ReturnToParent = true;

        // Save the presentation in PPTX format
        pres.Save("ZoomSlide_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}