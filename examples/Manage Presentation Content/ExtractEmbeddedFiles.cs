using System;
using System.IO;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputDir = "ExtractedFiles";
        Directory.CreateDirectory(outputDir);

        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
        {
            // Extract embedded videos
            for (int i = 0; i < presentation.Videos.Count; i++)
            {
                Aspose.Slides.IVideo video = presentation.Videos[i];
                using (Stream videoStream = video.GetStream())
                {
                    string extension = Path.GetExtension(video.ContentType);
                    if (string.IsNullOrEmpty(extension))
                    {
                        extension = ".bin";
                    }
                    string outputPath = Path.Combine(outputDir, "video_" + i + extension);
                    using (FileStream fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                    {
                        videoStream.CopyTo(fileStream);
                    }
                }
            }

            // Extract embedded audios
            for (int i = 0; i < presentation.Audios.Count; i++)
            {
                Aspose.Slides.IAudio audio = presentation.Audios[i];
                using (Stream audioStream = audio.GetStream())
                {
                    string extension = Path.GetExtension(audio.ContentType);
                    if (string.IsNullOrEmpty(extension))
                    {
                        extension = ".bin";
                    }
                    string outputPath = Path.Combine(outputDir, "audio_" + i + extension);
                    using (FileStream fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                    {
                        audioStream.CopyTo(fileStream);
                    }
                }
            }

            // Save the presentation (unchanged) before exiting
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}