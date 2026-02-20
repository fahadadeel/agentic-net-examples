using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Path to the PPTX file
        string filePath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "input.pptx");

        // Load options (no password required for this example)
        Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();
        loadOptions.OnlyLoadDocumentProperties = false;

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(filePath, loadOptions);

        // Check if the VBA project exists and whether it is password protected
        bool isVbaPasswordProtected = false;
        if (presentation.VbaProject != null)
        {
            isVbaPasswordProtected = presentation.VbaProject.IsPasswordProtected;
        }

        Console.WriteLine("VBA project password protected: " + isVbaPasswordProtected);

        // Save the presentation before exiting (no modifications made)
        presentation.Save(filePath, SaveFormat.Pptx);

        // Dispose the presentation object
        presentation.Dispose();
    }
}