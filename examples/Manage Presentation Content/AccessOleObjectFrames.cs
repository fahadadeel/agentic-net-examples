using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AccessOleObjectFrames
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PPTX file path
            string inputPath = "input.pptx";
            // Output PPTX file path (presentation will be saved here)
            string outputPath = "output.pptx";

            // Load the presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Access the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Access the first shape on the slide
            Aspose.Slides.IShape shape = slide.Shapes[0];

            // Cast the shape to OleObjectFrame
            Aspose.Slides.OleObjectFrame oleFrame = shape as Aspose.Slides.OleObjectFrame;

            if (oleFrame != null)
            {
                // Get embedded file data
                byte[] data = oleFrame.EmbeddedData.EmbeddedFileData;
                // Get embedded file extension
                string fileExtension = oleFrame.EmbeddedData.EmbeddedFileExtension;

                // Build output file name
                string extractedFilePath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "extracted" + fileExtension);

                // Write the extracted data to disk
                using (FileStream fileStream = new FileStream(extractedFilePath, FileMode.Create, FileAccess.Write))
                {
                    fileStream.Write(data, 0, data.Length);
                }
            }

            // Save the presentation before exiting
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}