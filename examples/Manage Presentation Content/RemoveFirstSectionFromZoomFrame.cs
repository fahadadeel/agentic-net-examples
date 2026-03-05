using System;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Load the presentation
        using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation("input.pptx"))
        {
            // Get the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Assume the first shape is a Summary Zoom frame
            Aspose.Slides.IShape shape = slide.Shapes[0];
            Aspose.Slides.ISummaryZoomFrame zoomFrame = shape as Aspose.Slides.ISummaryZoomFrame;

            if (zoomFrame != null && pres.Sections.Count > 0)
            {
                // Access the collection of Summary Zoom sections
                Aspose.Slides.ISummaryZoomSectionCollection collection = zoomFrame.SummaryZoomCollection;

                // Remove the first section from the Summary Zoom frame
                Aspose.Slides.ISection firstSection = pres.Sections[0];
                collection.RemoveSummaryZoomSection(firstSection);
            }

            // Save the modified presentation
            pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}