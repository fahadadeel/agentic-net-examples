using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Path to the source presentation
        var sourcePath = "VideoPresentation.pptx";

        // Load the presentation
        using (var pres = new Aspose.Slides.Presentation(sourcePath))
        {
            // Buffer for copying streams
            var buffer = new byte[8 * 1024];

            // Iterate through embedded videos
            for (int index = 0; index < pres.Videos.Count; index++)
            {
                var video = pres.Videos[index];
                // Determine file extension from content type
                var contentType = video.ContentType;
                var slashPos = contentType.LastIndexOf('/');
                var extension = contentType.Substring(slashPos + 1);
                var outputFile = $"extracted_video_{index}.{extension}";

                using (var videoStream = video.GetStream())
                using (var fileStream = new FileStream(outputFile, FileMode.Create, FileAccess.Write, FileShare.Read))
                {
                    int bytesRead;
                    while ((bytesRead = videoStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        fileStream.Write(buffer, 0, bytesRead);
                    }
                }
            }

            // Save the presentation before exit
            pres.Save("VideoPresentation_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}