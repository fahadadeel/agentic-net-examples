using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
            {
                // Get the first slide
                Aspose.Slides.ISlide slide = pres.Slides[0];

                // Load audio data from a file (replace with a valid path)
                byte[] audioData = File.ReadAllBytes("sampleaudio.wav");

                // Add the audio to the presentation's audio collection
                Aspose.Slides.IAudio audio = pres.Audios.AddAudio(audioData);

                // Add an audio frame to the slide using the embedded audio
                Aspose.Slides.IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(50f, 150f, 100f, 100f, audio);

                // Change audio play options
                audioFrame.PlayMode = Aspose.Slides.AudioPlayModePreset.OnClick;
                audioFrame.Volume = Aspose.Slides.AudioVolumeMode.Low;
                audioFrame.PlayAcrossSlides = true;
                audioFrame.PlayLoopMode = false;
                audioFrame.HideAtShowing = true;
                audioFrame.RewindAudio = true;

                // Save the presentation in PPTX format
                pres.Save("AudioFrameChanged.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}