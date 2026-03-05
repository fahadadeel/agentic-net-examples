using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Path to the source presentation
        string inputPath = "input.pptx";

        // Directory where extracted audio files will be saved
        string outputDir = "ExtractedAudio";
        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        // Load the presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
        {
            // Get the collection of embedded audio files
            Aspose.Slides.IAudioCollection audioCollection = presentation.Audios;

            // Iterate through each audio and save it to a file
            for (int i = 0; i < audioCollection.Count; i++)
            {
                Aspose.Slides.IAudio audio = audioCollection[i];
                byte[] audioData = audio.BinaryData;

                // Determine file extension based on content type
                string extension = GetExtension(audio.ContentType);
                string outputPath = Path.Combine(outputDir, $"audio_{i + 1}{extension}");

                File.WriteAllBytes(outputPath, audioData);
            }

            // Save the presentation (even if unchanged) before exiting
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }

    // Helper method to map MIME types to file extensions
    private static string GetExtension(string contentType)
    {
        if (contentType == null)
            return ".bin";

        string lower = contentType.ToLowerInvariant();
        if (lower == "audio/mpeg")
            return ".mp3";
        if (lower == "audio/wav")
            return ".wav";
        if (lower == "audio/mp4")
            return ".mp4";
        if (lower == "audio/ogg")
            return ".ogg";

        return ".bin";
    }
}