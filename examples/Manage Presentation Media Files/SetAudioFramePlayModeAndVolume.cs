using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Load audio file bytes (ensure the file exists at the specified path)
        byte[] audioData = File.ReadAllBytes("sampleaudio.mp3");

        // Add the audio to the presentation's audio collection
        Aspose.Slides.IAudio audio = presentation.Audios.AddAudio(audioData);

        // Add an embedded audio frame to the slide
        Aspose.Slides.IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, audio);

        // Set the audio play mode to play on click
        audioFrame.PlayMode = Aspose.Slides.AudioPlayModePreset.OnClick;

        // Set the audio volume to loud
        audioFrame.Volume = Aspose.Slides.AudioVolumeMode.Loud;

        // Save the presentation to disk
        presentation.Save("AudioFrameSettings_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}