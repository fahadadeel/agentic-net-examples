using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Vba;
using Aspose.Slides.Export;

namespace CheckVbaProjectProtection
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the input PPTX file
            string inputFilePath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");

            // Load the presentation
            using (Presentation presentation = new Presentation(inputFilePath))
            {
                // Get the VBA project (may be null if no macros)
                IVbaProject vbaProject = presentation.VbaProject;

                // Determine if the VBA project is password protected
                bool isVbaPasswordProtected = false;
                if (vbaProject != null)
                {
                    isVbaPasswordProtected = vbaProject.IsPasswordProtected;
                }

                Console.WriteLine("VBA Project password protected: " + isVbaPasswordProtected);

                // Save the presentation before exiting
                string outputFilePath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");
                presentation.Save(outputFilePath, SaveFormat.Pptx);
            }
        }
    }
}