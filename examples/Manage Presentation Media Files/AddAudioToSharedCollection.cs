using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Load audio file bytes
        byte[] audioBytes = File.ReadAllBytes("sampleaudio.mp3");

        // Add audio to the shared audio collection
        Aspose.Slides.IAudio audio = presentation.Audios.AddAudio(audioBytes);

        // Save the presentation
        presentation.Save("PresentationWithAudio.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}