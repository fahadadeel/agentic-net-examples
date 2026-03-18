using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Vba;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.pptm";
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            Aspose.Slides.Vba.IVbaProject vbaProject = presentation.VbaProject;
            if (vbaProject != null)
            {
                Aspose.Slides.Vba.IVbaModuleCollection modules = vbaProject.Modules;
                for (int i = 0; i < modules.Count; i++)
                {
                    Aspose.Slides.Vba.IVbaModule module = modules[i];
                    string moduleName = module.Name;
                    // Placeholder: actual VBA code extraction depends on available API
                    Console.WriteLine("Module: " + moduleName);
                }
            }
            else
            {
                Console.WriteLine("No VBA project found in the presentation.");
            }

            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}