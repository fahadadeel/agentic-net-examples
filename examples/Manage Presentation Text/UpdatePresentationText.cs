using System;
using Aspose.Slides;
using Aspose.Slides.Util;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the existing PPTX presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Find and replace text throughout the presentation (including master slides)
        Aspose.Slides.Util.SlideUtil.FindAndReplaceText(presentation, true, "OldText", "NewText", null);

        // Save the modified presentation as PPTX
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}