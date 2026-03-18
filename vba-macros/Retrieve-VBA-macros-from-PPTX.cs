using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RetrieveVbaMacro
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Path to the source presentation
                string sourcePath = "input.pptx";

                // Load the presentation
                Presentation presentation = new Presentation(sourcePath);

                // Access the VBA project
                Aspose.Slides.Vba.IVbaProject vbaProject = presentation.VbaProject;

                if (vbaProject != null)
                {
                    // Get the binary representation of the VBA project
                    byte[] vbaBinary = vbaProject.ToBinary();

                    // Save the binary data to a file for further analysis
                    string vbaOutputPath = "VbaProject.bin";
                    File.WriteAllBytes(vbaOutputPath, vbaBinary);

                    Console.WriteLine("VBA project extracted to: " + vbaOutputPath);
                }
                else
                {
                    Console.WriteLine("No VBA project found in the presentation.");
                }

                // Save the (unchanged) presentation before exiting
                presentation.Save("output.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}