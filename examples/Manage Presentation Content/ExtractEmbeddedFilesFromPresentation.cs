using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ManagePresentationContent
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path (PPT format)
            string inputPath = "input.ppt";
            // Output directory for extracted embedded files
            string outputDir = "ExtractedFiles";

            // Ensure the output directory exists
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            // Load the presentation
            Presentation presentation = new Presentation(inputPath);

            // Index for naming extracted files
            int fileIndex = 0;

            // Iterate through all slides and shapes to find OLE object frames
            foreach (ISlide slide in presentation.Slides)
            {
                foreach (IShape shape in slide.Shapes)
                {
                    if (shape is OleObjectFrame)
                    {
                        OleObjectFrame oleObject = shape as OleObjectFrame;

                        // Get the embedded file data and its extension
                        byte[] embeddedData = oleObject.EmbeddedData.EmbeddedFileData;
                        string fileExtension = oleObject.EmbeddedData.EmbeddedFileExtension;

                        // Build the output file path
                        string outPath = Path.Combine(outputDir, $"embedded_{fileIndex}{fileExtension}");

                        // Write the embedded file to disk
                        using (FileStream fileStream = new FileStream(outPath, FileMode.Create, FileAccess.Write, FileShare.Read))
                        {
                            fileStream.Write(embeddedData, 0, embeddedData.Length);
                        }

                        fileIndex++;
                    }
                }
            }

            // Save the (potentially unchanged) presentation before exiting
            presentation.Save("output.ppt", SaveFormat.Ppt);
            presentation.Dispose();
        }
    }
}