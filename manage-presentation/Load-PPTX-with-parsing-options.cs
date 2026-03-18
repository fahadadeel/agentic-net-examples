using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create load options and set desired properties
            Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();
            loadOptions.DefaultRegularFont = "Arial";
            loadOptions.DeleteEmbeddedBinaryObjects = true;

            // Load the presentation with the specified load options
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx", loadOptions);

            // Save the presentation before exiting
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}