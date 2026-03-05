using System;

class Program
{
    static void Main(string[] args)
    {
        // Path to the existing PPTX file
        System.String sourcePath = "input.pptx";
        // Path where the presentation will be saved
        System.String destinationPath = "output.pptx";

        // Open the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePath);

        // Save the presentation in PPTX format
        presentation.Save(destinationPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}