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
            // Load an existing presentation that will be the target of import operations
            string inputPath = "input.pptx";
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Import slides from a PDF document into the presentation
                string pdfPath = "source.pdf";
                // AddFromPdf returns an array of ISlide objects representing the newly added slides
                ISlide[] importedSlides = presentation.Slides.AddFromPdf(pdfPath);

                // Create a new section that starts with the first imported slide
                // AddSection requires an ISlide instance, not an integer index
                if (importedSlides.Length > 0)
                {
                    ISection pdfSection = presentation.Sections.AddSection("Imported PDF Slides", importedSlides[0]);
                }

                // Example of reordering: move the first imported slide to the very beginning of the slide deck
                if (importedSlides.Length > 0)
                {
                    presentation.Slides.Reorder(0, importedSlides[0]);
                }

                // Save the modified presentation before exiting the using block
                string outputPath = "output.pptx";
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during import or saving
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}