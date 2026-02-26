using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the presentation from a file
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Get the collection of embedded audio files
        Aspose.Slides.IAudioCollection audioCollection = presentation.Audios;

        // Extract each audio file to the file system
        for (int index = 0; index < audioCollection.Count; index++)
        {
            Aspose.Slides.IAudio audio = audioCollection[index];
            byte[] audioData = audio.BinaryData;
            string outputFile = $"audio_{index + 1}.bin";
            File.WriteAllBytes(outputFile, audioData);
        }

        // Save the presentation (required before exiting)
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}