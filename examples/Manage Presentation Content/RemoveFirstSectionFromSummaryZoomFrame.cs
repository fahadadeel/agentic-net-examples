using System;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Paths for input and output PPTX files
        var inputPath = "input.pptx";
        var outputPath = "output.pptx";

        // Load the presentation
        using (var pres = new Aspose.Slides.Presentation(inputPath))
        {
            // Get the first slide (adjust index if needed)
            var slide = pres.Slides[0];

            // Locate the first Summary Zoom frame on the slide
            Aspose.Slides.ISummaryZoomFrame zoomFrame = null;
            foreach (var shape in slide.Shapes)
            {
                if (shape is Aspose.Slides.ISummaryZoomFrame)
                {
                    zoomFrame = (Aspose.Slides.ISummaryZoomFrame)shape;
                    break;
                }
            }

            // If a Summary Zoom frame and at least one section exist, remove the first section
            if (zoomFrame != null && pres.Sections.Count > 0)
            {
                var collection = zoomFrame.SummaryZoomCollection;
                collection.RemoveSummaryZoomSection(pres.Sections[0]);
            }

            // Save the modified presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}