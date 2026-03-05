using System;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.ppt";

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Access document properties
        Aspose.Slides.IDocumentProperties documentProperties = presentation.DocumentProperties;

        // Modify built‑in properties
        documentProperties.Author = "John Doe";
        documentProperties.Title = "Sample Title";
        documentProperties.Subject = "Sample Subject";

        // Add custom properties
        documentProperties["CustomInt"] = 123;
        documentProperties["CustomString"] = "Hello";
        documentProperties["CustomDate"] = DateTime.Now;

        // Update existing custom properties (example: append index)
        for (int i = 0; i < documentProperties.CountOfCustomProperties; i++)
        {
            string propName = documentProperties.GetCustomPropertyName(i);
            object propValue = documentProperties[propName];

            if (propValue is int intValue)
            {
                documentProperties[propName] = intValue + (i + 1);
            }
            else if (propValue is string strValue)
            {
                documentProperties[propName] = strValue + (i + 1);
            }
        }

        // Save the presentation in PPT format
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Ppt);

        // Clean up
        presentation.Dispose();
    }
}