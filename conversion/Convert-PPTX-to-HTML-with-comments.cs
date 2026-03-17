using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var inputPath = "input.pptx";
            var outputPath = "output.html";

            using (var presentation = new Aspose.Slides.Presentation(inputPath))
            {
                var options = new Aspose.Slides.Export.HtmlOptions();
                // Export to HTML while retaining slide comments (default behavior)
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Html, options);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}