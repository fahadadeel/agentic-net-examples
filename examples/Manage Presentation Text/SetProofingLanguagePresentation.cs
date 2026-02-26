using System;

class Program
{
    static void Main()
    {
        // Create load options and set default proofing language
        Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();
        loadOptions.DefaultTextLanguage = "en-US";

        // Load the presentation with the specified load options
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx", loadOptions))
        {
            // Access the first shape on the first slide (assumed to be an AutoShape)
            Aspose.Slides.IShape shape = presentation.Slides[0].Shapes[0];
            Aspose.Slides.IAutoShape autoShape = shape as Aspose.Slides.IAutoShape;

            if (autoShape != null && autoShape.TextFrame != null &&
                autoShape.TextFrame.Paragraphs.Count > 0 &&
                autoShape.TextFrame.Paragraphs[0].Portions.Count > 0)
            {
                // Get the first portion of text and set its proofing language
                Aspose.Slides.IPortion portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
                portion.PortionFormat.LanguageId = "en-US";
            }

            // Save the modified presentation
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}