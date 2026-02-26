using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
        {
            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Load audio file bytes (ensure the file exists at the specified path)
            byte[] audioData = File.ReadAllBytes("sampleaudio.mp3");

            // Add the audio to the presentation's audio collection
            Aspose.Slides.IAudio audio = presentation.Audios.AddAudio(audioData);

            // Add an embedded audio frame to the slide using the added audio
            Aspose.Slides.IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 150, 100, 100, audio);

            // Set playback mode and volume (optional)
            audioFrame.PlayMode = Aspose.Slides.AudioPlayModePreset.Auto;
            audioFrame.Volume = Aspose.Slides.AudioVolumeMode.Loud;

            // Save the presentation
            presentation.Save("AudioPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}