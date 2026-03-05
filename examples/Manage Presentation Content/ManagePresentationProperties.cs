using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the document properties of the presentation
        Aspose.Slides.IDocumentProperties docProps = presentation.DocumentProperties;

        // Set built-in properties
        docProps.Author = "John Doe";
        docProps.Title = "Sample Presentation";
        docProps.Subject = "Demo of Document Properties";
        docProps.Category = "Examples";
        docProps.Comments = "Created with Aspose.Slides";

        // Set custom properties
        docProps.SetCustomPropertyValue("CustomString", "CustomValue");
        docProps.SetCustomPropertyValue("CustomNumber", 12345);
        docProps.SetCustomPropertyValue("CustomDate", DateTime.UtcNow);

        // Save the presentation to a PPTX file
        presentation.Save("ManagedProperties.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}