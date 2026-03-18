using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RemoveMacrosExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Path to the source presentation
                string inputPath = "input.pptx";
                // Path to the output presentation without macros and embedded binaries
                string outputPath = "output_without_macros.pptx";

                // Configure load options to delete embedded binary objects (macros, OLE data, etc.)
                LoadOptions loadOptions = new LoadOptions();
                loadOptions.DeleteEmbeddedBinaryObjects = true;

                // Load the presentation with the specified options
                using (Presentation presentation = new Presentation(inputPath, loadOptions))
                {
                    // Save the cleaned presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}