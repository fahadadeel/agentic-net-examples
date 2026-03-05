using System;

class Program
{
    static void Main()
    {
        // Path to the source presentation
        System.String inputPath = "input.pptx";

        // Create load options and specify the format to load (PPTX)
        Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();
        loadOptions.LoadFormat = Aspose.Slides.LoadFormat.Pptx;

        // Load the presentation with the specified load options
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath, loadOptions);

        // Save the presentation before exiting
        System.String outputPath = "output.pptx";
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up resources
        presentation.Dispose();
    }
}