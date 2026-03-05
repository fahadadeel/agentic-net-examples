using System;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access document properties
        Aspose.Slides.IDocumentProperties docProps = presentation.DocumentProperties;

        // Set built-in properties
        docProps.Author = "John Doe";
        docProps.Title = "Custom Properties Demo";
        docProps.Subject = "Aspose.Slides Example";

        // Add custom properties
        docProps.SetCustomPropertyValue("CustomString", "Hello World");
        docProps.SetCustomPropertyValue("CustomInt", 123);
        docProps.SetCustomPropertyValue("CustomDate", DateTime.UtcNow);
        docProps.SetCustomPropertyValue("CustomBool", true);
        docProps.SetCustomPropertyValue("CustomDouble", 3.14159);

        // Save the presentation
        presentation.Save("CustomPropertiesDemo.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}