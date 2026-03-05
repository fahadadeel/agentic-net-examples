using System;
using Aspose.Slides;
using Aspose.Slides.Util;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load an existing presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Retrieve all text frames from the presentation, including master slides
        Aspose.Slides.ITextFrame[] textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextFrames(presentation, true);

        // Set the vertical anchoring type for each text frame
        foreach (Aspose.Slides.ITextFrame textFrame in textFrames)
        {
            // Access the text frame format (read/write)
            Aspose.Slides.ITextFrameFormat format = textFrame.TextFrameFormat;
            // Set anchoring to center (other options: Top, Bottom, etc.)
            format.AnchoringType = Aspose.Slides.TextAnchorType.Center;
        }

        // Save the modified presentation
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}