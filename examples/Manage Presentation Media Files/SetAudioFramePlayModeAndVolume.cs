using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SetAudioFramePlayModeAndVolume
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation.
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Get the first slide.
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Load an audio file from disk.
            System.IO.FileStream audioStream = new System.IO.FileStream("sampleaudio.wav", System.IO.FileMode.Open, System.IO.FileAccess.Read);

            // Add an audio frame to the slide.
            Aspose.Slides.IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(50f, 150f, 100f, 100f, audioStream);

            // Close the audio stream as it is no longer needed.
            audioStream.Close();

            // Set the play mode and volume for the audio frame.
            audioFrame.PlayMode = Aspose.Slides.AudioPlayModePreset.Auto;
            audioFrame.Volume = Aspose.Slides.AudioVolumeMode.Loud;

            // Save the presentation in PPTX format.
            pres.Save("SetAudioPlayModeAndVolume_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

            // Release resources.
            pres.Dispose();
        }
    }
}