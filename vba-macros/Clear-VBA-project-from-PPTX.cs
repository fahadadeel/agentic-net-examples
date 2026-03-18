using System;
using Aspose.Slides;
using Aspose.Slides.Vba;
using Aspose.Slides.Export;

namespace RemoveVbaMacros
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptm";
            string outputPath = "output_without_macros.pptx";

            Aspose.Slides.Presentation presentation = null;

            try
            {
                // Load the presentation
                presentation = new Aspose.Slides.Presentation(inputPath);

                // Replace the existing VBA project with a new empty one
                presentation.VbaProject = VbaProjectFactory.Instance.CreateVbaProject();

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
                Console.WriteLine("VBA macros removed and presentation saved to: " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                // Ensure resources are released
                if (presentation != null)
                {
                    presentation.Dispose();
                }
            }
        }
    }
}