using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesBlobExport
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load the PPTX presentation from file
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

            // Create a memory stream to act as a BLOB for the PDF output
            MemoryStream pdfBlob = new MemoryStream();

            // Save the presentation as PDF into the memory stream
            presentation.Save(pdfBlob, Aspose.Slides.Export.SaveFormat.Pdf);

            // Write the PDF BLOB to a physical file
            File.WriteAllBytes("output.pdf", pdfBlob.ToArray());

            // Clean up resources
            pdfBlob.Dispose();
            presentation.Dispose();
        }
    }
}