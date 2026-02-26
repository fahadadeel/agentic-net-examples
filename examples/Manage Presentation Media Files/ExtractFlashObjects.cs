using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Path to the source presentation
        string sourcePath = "input.pptx";

        // Load the presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePath))
        {
            // Buffer for stream copying
            byte[] buffer = new byte[8192];

            // Iterate through all embedded video objects (Flash objects may be stored here)
            for (int index = 0; index < presentation.Videos.Count; index++)
            {
                Aspose.Slides.IVideo video = presentation.Videos[index];

                // Determine file extension based on content type
                string contentType = video.ContentType; // e.g., "application/x-shockwave-flash"
                string extension = ".bin";
                int slashPos = contentType.LastIndexOf('/');
                if (slashPos >= 0 && slashPos < contentType.Length - 1)
                {
                    string typePart = contentType.Substring(slashPos + 1);
                    if (typePart.Equals("x-shockwave-flash", StringComparison.OrdinalIgnoreCase))
                    {
                        extension = ".swf";
                    }
                    else if (typePart.Equals("mp4", StringComparison.OrdinalIgnoreCase))
                    {
                        extension = ".mp4";
                    }
                    else if (typePart.Equals("avi", StringComparison.OrdinalIgnoreCase))
                    {
                        extension = ".avi";
                    }
                }

                string outputFile = $"extracted_{index}{extension}";

                // Extract the binary data to a file
                using (Stream videoStream = video.GetStream())
                {
                    using (FileStream fileStream = new FileStream(outputFile, FileMode.Create, FileAccess.Write))
                    {
                        int bytesRead;
                        while ((bytesRead = videoStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            fileStream.Write(buffer, 0, bytesRead);
                        }
                    }
                }
            }

            // Save the presentation (no modifications) before exiting
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}