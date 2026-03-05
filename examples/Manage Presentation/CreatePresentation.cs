using System;

class Program
{
    static void Main()
    {
        // Create a new presentation (contains one empty slide by default)
        var presentation = new Aspose.Slides.Presentation();

        // Save the presentation in PPTX format
        presentation.Save("NewPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}