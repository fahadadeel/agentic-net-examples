using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AudioFrameExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Load WAV audio file into a stream
            FileStream audioStream = new FileStream("sampleaudio.wav", FileMode.Open, FileAccess.Read);

            // Add an embedded audio frame to the slide
            Aspose.Slides.IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(50f, 150f, 100f, 100f, audioStream);

            // Set audio playback properties
            audioFrame.PlayMode = Aspose.Slides.AudioPlayModePreset.Auto;
            audioFrame.Volume = Aspose.Slides.AudioVolumeMode.Loud;
            audioFrame.PlayAcrossSlides = true;
            audioFrame.PlayLoopMode = false;
            audioFrame.HideAtShowing = true;
            audioFrame.RewindAudio = true;

            // Close the audio stream
            audioStream.Close();

            // Save the presentation
            pres.Save("AudioFrameExample_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose the presentation
            pres.Dispose();
        }
    }
}