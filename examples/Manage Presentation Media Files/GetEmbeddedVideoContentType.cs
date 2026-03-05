using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load an existing presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation("input.pptx");

        // Iterate through all embedded videos
        for (int i = 0; i < pres.Videos.Count; i++)
        {
            Aspose.Slides.IVideo video = pres.Videos[i];
            string contentType = video.ContentType;
            Console.WriteLine($"Video {i} Content Type: {contentType}");

            // Save each video to a file using its content type to determine extension
            using (Stream videoStream = video.GetStream())
            {
                string extension = GetExtensionFromContentType(contentType);
                string outputPath = $"video{i}{extension}";
                using (FileStream fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                {
                    byte[] buffer = new byte[8192];
                    int bytesRead;
                    while ((bytesRead = videoStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        fileStream.Write(buffer, 0, bytesRead);
                    }
                }
            }
        }

        // Save the presentation as PDF (or any other format)
        pres.Save("output.pdf", Aspose.Slides.Export.SaveFormat.Pdf);

        // Clean up
        pres.Dispose();
    }

    // Simple helper to map MIME types to file extensions
    static string GetExtensionFromContentType(string contentType)
    {
        if (contentType.Equals("video/mp4", StringComparison.OrdinalIgnoreCase))
            return ".mp4";
        if (contentType.Equals("video/avi", StringComparison.OrdinalIgnoreCase))
            return ".avi";
        if (contentType.Equals("video/mov", StringComparison.OrdinalIgnoreCase))
            return ".mov";
        // Default fallback
        return ".bin";
    }
}