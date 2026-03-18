using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Load a presentation and remove all embedded binary objects (including VBA)
            LoadOptions loadOptions = new LoadOptions();
            loadOptions.DeleteEmbeddedBinaryObjects = true;
            Presentation presentation = new Presentation("input.pptx", loadOptions);

            // Remove any existing VBA project
            presentation.VbaProject = null;

            // Save the modified presentation
            presentation.Save("output.pptx", SaveFormat.Pptx);

            // Release resources
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}