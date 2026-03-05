using System;
using System.IO;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;

namespace AsposeSlidesSoundDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Load audio file into a byte array
            byte[] audioData = File.ReadAllBytes("sample.mp3");

            // Add the audio to the presentation's audio collection
            Aspose.Slides.IAudio audio = presentation.Audios.AddAudio(audioData);

            // Add an audio frame to the first slide and embed the audio
            Aspose.Slides.IAudioFrame audioFrame = presentation.Slides[0].Shapes.AddAudioFrameEmbedded(
                10,   // X position
                10,   // Y position
                100,  // Width
                100,  // Height
                audio // Embedded audio
            );

            // Optionally set a hyperlink for the audio frame
            audioFrame.HyperlinkClick = new Aspose.Slides.Hyperlink("https://www.example.com/");
            audioFrame.HyperlinkClick.Tooltip = "Visit example.com";

            // Set transition sound for the first slide
            presentation.Slides[0].SlideShowTransition.Sound = audio;
            presentation.Slides[0].SlideShowTransition.SoundName = "SampleTransitionSound";

            // Save the presentation in PPT format
            presentation.Save("OutputPresentation.ppt", Aspose.Slides.Export.SaveFormat.Ppt);
        }
    }
}