using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input PPTX file path
        string inputPath = "input.pptx";

        // Directory to save extracted audio files
        string outputDir = "ExtractedAudio";

        // Ensure the output directory exists
        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        // Load the presentation
        Presentation pres = new Presentation(inputPath);

        // Get the collection of embedded audios
        IAudioCollection audioCollection = pres.Audios;

        // Iterate through each audio and save it to a file
        for (int i = 0; i < audioCollection.Count; i++)
        {
            IAudio audio = audioCollection[i];
            byte[] data = audio.BinaryData;

            // Determine file extension from content type, default to bin if unavailable
            string extension = "bin";
            if (audio.ContentType != null)
            {
                int slashPos = audio.ContentType.LastIndexOf('/');
                if (slashPos >= 0 && slashPos < audio.ContentType.Length - 1)
                {
                    extension = audio.ContentType.Substring(slashPos + 1);
                }
            }

            string outPath = Path.Combine(outputDir, $"audio_{i}.{extension}");
            File.WriteAllBytes(outPath, data);
        }

        // Save the presentation before exiting (even if unchanged)
        pres.Save("output.pptx", SaveFormat.Pptx);

        // Dispose the presentation to release resources
        pres.Dispose();
    }
}