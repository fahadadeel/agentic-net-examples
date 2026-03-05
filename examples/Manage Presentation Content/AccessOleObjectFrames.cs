using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ManageOleObjectFrames
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PPT file containing OLE objects
            string inputPath = "input.ppt";
            // Output PPT file after processing
            string outputPath = "output.ppt";

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            int oleObjectIndex = 0;

            // Iterate through all slides
            foreach (Aspose.Slides.ISlide slide in presentation.Slides)
            {
                // Iterate through all shapes on the slide
                foreach (Aspose.Slides.IShape shape in slide.Shapes)
                {
                    // Cast shape to OleObjectFrame if possible
                    Aspose.Slides.OleObjectFrame oleObjectFrame = shape as Aspose.Slides.OleObjectFrame;
                    if (oleObjectFrame != null)
                    {
                        // Access embedded OLE data
                        Aspose.Slides.IOleEmbeddedDataInfo embeddedData = oleObjectFrame.EmbeddedData;
                        byte[] fileData = embeddedData.EmbeddedFileData;
                        string fileExtension = embeddedData.EmbeddedFileExtension;

                        // Save the extracted OLE file to disk
                        string extractedFilePath = $"extracted_{oleObjectIndex}{fileExtension}";
                        File.WriteAllBytes(extractedFilePath, fileData);

                        oleObjectIndex++;
                    }
                }
            }

            // Save the presentation before exiting
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Ppt);
            presentation.Dispose();
        }
    }
}