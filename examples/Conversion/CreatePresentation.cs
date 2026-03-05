using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation instance
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Save the presentation to a file
        presentation.Save("OutputPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up resources
        presentation.Dispose();
    }
}