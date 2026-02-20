using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Vba;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input presentation path (must be a macro-enabled file)
        string inputPath = "input.pptm";
        // Directory to save extracted VBA modules
        string outputDir = "VbaMacros";

        if (!Directory.Exists(outputDir))
            Directory.CreateDirectory(outputDir);

        // Load presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
        try
        {
            // Get VBA project
            Aspose.Slides.Vba.IVbaProject vbaProject = presentation.VbaProject;
            if (vbaProject != null)
            {
                // Iterate through modules and save source code
                Aspose.Slides.Vba.IVbaModuleCollection modules = vbaProject.Modules;
                foreach (Aspose.Slides.Vba.IVbaModule module in modules)
                {
                    string moduleName = module.Name;
                    string sourceCode = module.SourceCode;
                    string outPath = Path.Combine(outputDir, moduleName + ".bas");
                    File.WriteAllText(outPath, sourceCode);
                }
            }
        }
        finally
        {
            // Save presentation before exit (no modifications made)
            presentation.Save("output.pptm", Aspose.Slides.Export.SaveFormat.Pptm);
            presentation.Dispose();
        }
    }
}