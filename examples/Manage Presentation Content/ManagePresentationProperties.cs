using System;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the document properties object
        Aspose.Slides.IDocumentProperties docProps = presentation.DocumentProperties;

        // Set built‑in properties
        docProps.Author = "John Doe";
        docProps.Title = "Sample Presentation";
        docProps.Subject = "Demonstration";
        docProps.PresentationFormat = "On-screen Show";

        // Add a custom property
        docProps.SetCustomPropertyValue("Company", "Acme Corp");

        // Save the presentation before exiting
        presentation.Save("ManagedProperties.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}