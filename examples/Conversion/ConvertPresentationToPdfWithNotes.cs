using System;

namespace AsposeSlidesConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            // Expect input file path and output PDF path as arguments
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: AsposeSlidesConversion <input-ppt-or-pptx> <output-pdf>");
                return;
            }

            string inputPath = args[0];
            string outputPath = args[1];

            // Load the presentation (PPT or PPTX)
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Configure PDF options to include notes
                Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();
                pdfOptions.SlidesLayoutOptions = new Aspose.Slides.Export.NotesCommentsLayoutingOptions()
                {
                    NotesPosition = Aspose.Slides.Export.NotesPositions.BottomFull
                };

                // Save the presentation as PDF with notes
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);
            }
        }
    }
}