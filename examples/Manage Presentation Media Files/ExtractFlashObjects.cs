using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Path to the source PPTX file
        string sourcePath = "input.pptx";

        // Open the presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePath))
        {
            // Buffer for streaming data
            byte[] buffer = new byte[8192];

            // Iterate through all embedded video objects (SWF files are treated as videos)
            for (int index = 0; index < presentation.Videos.Count; index++)
            {
                Aspose.Slides.IVideo video = presentation.Videos[index];

                // Determine file extension from content type (e.g., "application/x-shockwave-flash")
                string contentType = video.ContentType;
                string extension = ".bin";
                int slashPos = contentType.LastIndexOf('/');
                if (slashPos != -1 && slashPos + 1 < contentType.Length)
                {
                    string typePart = contentType.Substring(slashPos + 1);
                    extension = "." + typePart;
                }

                // Create output file name
                string outputFileName = $"flash_{index}{extension}";

                // Extract the video (SWF) stream to a file
                using (Stream videoStream = video.GetStream())
                {
                    using (FileStream fileStream = new FileStream(outputFileName, FileMode.Create, FileAccess.Write))
                    {
                        int bytesRead;
                        while ((bytesRead = videoStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            fileStream.Write(buffer, 0, bytesRead);
                        }
                    }
                }
            }

            // Save the presentation (even if unchanged) before exiting
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}