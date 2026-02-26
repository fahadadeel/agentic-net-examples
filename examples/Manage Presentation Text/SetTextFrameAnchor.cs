using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load an existing presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

            // Retrieve all text frames in the presentation (excluding master slides)
            Aspose.Slides.ITextFrame[] textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextFrames(presentation, false);

            // Set the vertical anchor type for each text frame
            foreach (Aspose.Slides.ITextFrame textFrame in textFrames)
            {
                textFrame.TextFrameFormat.AnchoringType = Aspose.Slides.TextAnchorType.Top;
            }

            // Save the updated presentation
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}