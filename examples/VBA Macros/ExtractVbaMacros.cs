using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Vba;

class Program
{
    static void Main()
    {
        // Path to the input presentation containing VBA macros
        string inputPath = "input.pptx";

        // Directory where extracted macro modules will be saved
        string outputDir = "Macros";

        // Ensure the output directory exists
        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
        try
        {
            // Get the VBA project from the presentation
            Aspose.Slides.Vba.IVbaProject vbaProject = presentation.VbaProject;

            if (vbaProject != null)
            {
                // Iterate through all VBA modules
                Aspose.Slides.Vba.IVbaModuleCollection modules = vbaProject.Modules;
                int moduleIndex = 0;
                foreach (Aspose.Slides.Vba.IVbaModule module in modules)
                {
                    // Retrieve module name and source code
                    string moduleName = module.Name;
                    string sourceCode = module.SourceCode;

                    // Build output file path for the module
                    string outPath = Path.Combine(outputDir, $"module_{moduleIndex}_{moduleName}.bas");

                    // Write the source code to a file
                    File.WriteAllText(outPath, sourceCode);
                    moduleIndex++;
                }
            }
        }
        finally
        {
            // Save the presentation (even if unchanged) before exiting
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
    }
}