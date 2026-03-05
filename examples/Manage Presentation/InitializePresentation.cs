using System;

class Program
{
    static void Main(string[] args)
    {
        // Initialize a new presentation document
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
        {
            // Save the presentation in PPTX format before exiting
            presentation.Save("NewPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}