using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            using (Presentation presentation = new Presentation())
            {
                // Import slides from a PDF file
                string pdfPath = "input.pdf";
                if (File.Exists(pdfPath))
                {
                    presentation.Slides.AddFromPdf(pdfPath);
                }

                // Import slides from an HTML file
                string htmlPath = "input.html";
                if (File.Exists(htmlPath))
                {
                    using (FileStream htmlStream = new FileStream(htmlPath, FileMode.Open, FileAccess.Read))
                    {
                        presentation.Slides.AddFromHtml(htmlStream);
                    }
                }

                // Save the combined presentation
                string outputPath = "CombinedPresentation.pptx";
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}