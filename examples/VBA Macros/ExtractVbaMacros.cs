using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Vba;

class Program
{
    static void Main()
    {
        // Path to the input PPTX file
        string inputPath = "input.pptx";
        // Directory where extracted VBA modules will be saved
        string outputDir = "VbaMacros";

        // Ensure the output directory exists
        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        // Load the presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);
        try
        {
            // Get the VBA project from the presentation
            Aspose.Slides.Vba.IVbaProject vbaProject = pres.VbaProject;
            if (vbaProject != null)
            {
                // Get the collection of VBA modules
                Aspose.Slides.Vba.IVbaModuleCollection modules = vbaProject.Modules;
                int moduleIndex = 0;

                // Iterate through each module and write its source code to a file
                foreach (Aspose.Slides.Vba.IVbaModule module in modules)
                {
                    string moduleName = module.Name;
                    string sourceCode = module.SourceCode;
                    string fileName = Path.Combine(outputDir, "Module_" + moduleIndex + "_" + moduleName + ".bas");
                    File.WriteAllText(fileName, sourceCode);
                    moduleIndex++;
                }
            }
        }
        finally
        {
            // Save the presentation (even if unchanged) before exiting
            pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();
        }
    }
}