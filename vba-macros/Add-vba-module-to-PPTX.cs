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
            string inputPath = "input.pptx";
            string outputPath = "output_with_macro.pptm";

            using (var presentation = new Presentation(inputPath))
            {
                // Create a new VBA project and assign it to the presentation
                presentation.VbaProject = new Aspose.Slides.Vba.VbaProject();

                // Add a new empty module and set its source code
                var module = presentation.VbaProject.Modules.AddEmptyModule("MyModule");
                module.SourceCode = "Sub AutoOpen()\n    MsgBox \"Hello from VBA\"\nEnd Sub";

                // Add references to standard OLE libraries
                var stdoleRef = new Aspose.Slides.Vba.VbaReferenceOleTypeLib("stdole", "{00020430-0000-0000-C000-000000000046}");
                var officeRef = new Aspose.Slides.Vba.VbaReferenceOleTypeLib("Office", "{000C0601-0000-0000-C000-000000000046}");
                presentation.VbaProject.References.Add(stdoleRef);
                presentation.VbaProject.References.Add(officeRef);

                // Save the presentation with macros
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptm);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}