using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExtractAudioExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PPTX file path
            System.String inputPath = "input.pptx";
            // Output directory for extracted audio files
            System.String outputDir = "ExtractedAudio";
            System.IO.Directory.CreateDirectory(outputDir);

            // Load the presentation
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
            {
                // Get the collection of embedded audios
                Aspose.Slides.IAudioCollection audioCollection = pres.Audios;

                // Iterate through each audio and save it to a file
                for (int i = 0; i < audioCollection.Count; i++)
                {
                    Aspose.Slides.IAudio audio = audioCollection[i];
                    if (audio != null && audio.BinaryData != null)
                    {
                        // Determine file extension from content type (e.g., "audio/mpeg" -> "mpeg")
                        System.String contentType = audio.ContentType;
                        int slashPos = contentType.LastIndexOf('/');
                        System.String extension = (slashPos >= 0 && slashPos < contentType.Length - 1)
                            ? contentType.Substring(slashPos + 1)
                            : "bin";

                        System.String outPath = System.IO.Path.Combine(outputDir, $"audio_{i}.{extension}");
                        System.IO.File.WriteAllBytes(outPath, audio.BinaryData);
                    }
                }

                // Save the presentation before exiting (no modifications made)
                pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}