using System;
using System.IO;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Load audio file bytes (replace with your audio file path)
        byte[] audioData = File.ReadAllBytes("sampleaudio.mp3");

        // Add audio to the presentation's audio collection
        Aspose.Slides.IAudio audio = pres.Audios.AddAudio(audioData);

        // Get the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add an embedded audio frame to the slide using the added audio
        Aspose.Slides.IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 150, 100, 100, audio);

        // Set playback mode and volume (optional)
        audioFrame.PlayMode = Aspose.Slides.AudioPlayModePreset.Auto;
        audioFrame.Volume = Aspose.Slides.AudioVolumeMode.Loud;

        // Save the presentation
        pres.Save("AudioPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}