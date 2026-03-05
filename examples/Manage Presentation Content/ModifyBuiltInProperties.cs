using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Load an existing PPTX presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("ModifyBuiltinProperties.pptx");

        // Get the document properties object
        Aspose.Slides.IDocumentProperties docProps = presentation.DocumentProperties;

        // Modify built‑in properties
        docProps.Author = "Aspose.Slides for .NET";
        docProps.Title = "Modifying Presentation Properties";
        docProps.Subject = "Aspose Subject";
        docProps.Category = "Demo Category";
        docProps.Comments = "Sample comments";

        // Save the updated presentation
        presentation.Save("DocumentProperties_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up resources
        presentation.Dispose();
    }
}