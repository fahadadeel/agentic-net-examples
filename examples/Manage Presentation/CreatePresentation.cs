using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation instance
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
        {
            // Save the presentation to a PPTX file
            presentation.Save("NewPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}