using System;
using System.IO;
using Aspose.Slides.Export;
using Aspose.Slides.DOM.Ole;

class Program
{
    static void Main()
    {
        try
        {
            var presentation = new Aspose.Slides.Presentation();
            var slide = presentation.Slides[0];

            var vbaProject = new Aspose.Slides.Vba.VbaProject();
            // Add VBA macro code to the project (actual API may vary)
            // vbaProject.Modules.Add("Module1", "Sub AutoOpen()\n MsgBox \"Hello from VBA\"\nEnd Sub");
            presentation.VbaProject = vbaProject;

            presentation.Save("MacroPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}