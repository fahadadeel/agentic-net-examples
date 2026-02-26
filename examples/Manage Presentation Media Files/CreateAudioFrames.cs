using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Paths for audio file and output presentation
        string dataDir = Directory.GetCurrentDirectory();
        string audioPath = Path.Combine(dataDir, "sampleaudio.wav");
        string outputPath = Path.Combine(dataDir, "AudioFrame_out.pptx");

        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add audio to the presentation's audio collection
        Aspose.Slides.IAudio audio = pres.Audios.AddAudio(File.ReadAllBytes(audioPath));

        // Add an embedded audio frame to the slide
        Aspose.Slides.IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(50f, 150f, 100f, 100f, audio);

        // Configure audio playback settings
        audioFrame.PlayAcrossSlides = true;
        audioFrame.RewindAudio = true;
        audioFrame.Volume = Aspose.Slides.AudioVolumeMode.Loud;
        audioFrame.PlayMode = Aspose.Slides.AudioPlayModePreset.Auto;

        // Save the presentation
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up resources
        pres.Dispose();
    }
}