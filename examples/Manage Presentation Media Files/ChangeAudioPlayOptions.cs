using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AudioPlayOptionsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load an existing presentation that contains an audio frame
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation("AudioFrameEmbed_out.pptx"))
            {
                // Get the first slide
                Aspose.Slides.ISlide slide = pres.Slides[0];

                // Retrieve the first shape on the slide and cast it to AudioFrame
                Aspose.Slides.AudioFrame audioFrame = (Aspose.Slides.AudioFrame)slide.Shapes[0];

                // Change audio play mode to play on click
                audioFrame.PlayMode = Aspose.Slides.AudioPlayModePreset.OnClick;

                // Set audio volume to low
                audioFrame.Volume = Aspose.Slides.AudioVolumeMode.Low;

                // Enable playing the audio across all slides
                audioFrame.PlayAcrossSlides = true;

                // Disable looping of the audio
                audioFrame.PlayLoopMode = false;

                // Hide the audio frame during the slide show
                audioFrame.HideAtShowing = true;

                // Rewind the audio to the start after it finishes playing
                audioFrame.RewindAudio = true;

                // Save the modified presentation
                pres.Save("AudioFrameEmbed_changed.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}