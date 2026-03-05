using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Get the document properties object
        Aspose.Slides.IDocumentProperties documentProperties = presentation.DocumentProperties;

        // Modify each custom property by appending its index
        for (int i = 0; i < documentProperties.CountOfCustomProperties; i++)
        {
            string propName = documentProperties.GetCustomPropertyName(i);
            object propValue = documentProperties[propName];
            string newValue = propValue.ToString() + " Updated " + (i + 1);
            documentProperties[propName] = newValue;
        }

        // Save the presentation with modified properties
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up resources
        presentation.Dispose();
    }
}