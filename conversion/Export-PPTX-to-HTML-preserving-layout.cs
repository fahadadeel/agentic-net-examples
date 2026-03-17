using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.pptx";
            string outputPath = "output.html";

            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
            {
                Aspose.Slides.Export.HtmlOptions options = new Aspose.Slides.Export.HtmlOptions();
                // Customize options if needed, e.g., options.ShowHiddenSlides = true;

                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Html, options);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}