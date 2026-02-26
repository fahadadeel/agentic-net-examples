using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Set the default language for all text in the presentation
        pres.DefaultTextStyle.DefaultParagraphFormat.DefaultPortionFormat.LanguageId = "en-US";

        // Save the presentation as PPTX
        pres.Save("DefaultLanguagePresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose the presentation object
        pres.Dispose();
    }
}