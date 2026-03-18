using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load the source presentation
            using (Presentation pres = new Presentation("input.pptx"))
            {
                // Configure XPS export options to preserve equation fidelity
                XpsOptions options = new XpsOptions();
                options.SaveMetafilesAsPng = false; // keep metafiles (e.g., equations) as vector graphics

                // Export the presentation to XPS format
                pres.Save("output.xps", SaveFormat.Xps, options);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}