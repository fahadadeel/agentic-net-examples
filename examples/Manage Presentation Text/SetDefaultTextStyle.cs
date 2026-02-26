using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Set default language identifier for text
        presentation.DefaultTextStyle.DefaultParagraphFormat.DefaultPortionFormat.LanguageId = "en-US";

        // Set default font height for level 0 text style
        presentation.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight = 24f;

        // Save the updated presentation as PPTX
        presentation.Save("DefaultTextStyle_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}