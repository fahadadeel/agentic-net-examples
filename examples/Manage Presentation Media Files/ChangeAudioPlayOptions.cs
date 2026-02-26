using System;
using System.IO;
using Aspose.Slides;

class Program
{
    static void Main(string[] args)
    {
        // Paths to the input presentation, audio file, and output presentation
        string dataDir = "C:\\Data";
        string inputPath = Path.Combine(dataDir, "input.pptx");
        string audioPath = Path.Combine(dataDir, "sampleaudio.wav");
        string outputPath = Path.Combine(dataDir, "output.pptx");

        // Load the existing presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

        // Get the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Open the audio file stream
        FileStream audioStream = new FileStream(audioPath, FileMode.Open, FileAccess.Read);

        // Add an embedded audio frame to the slide
        Aspose.Slides.IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(50f, 150f, 100f, 100f, audioStream);

        // Change audio play options
        audioFrame.PlayMode = Aspose.Slides.AudioPlayModePreset.OnClick;      // Play on click
        audioFrame.Volume = Aspose.Slides.AudioVolumeMode.Low;               // Low volume
        audioFrame.PlayAcrossSlides = true;                                 // Play across slides
        audioFrame.PlayLoopMode = false;                                    // No looping
        audioFrame.HideAtShowing = true;                                    // Hide during slide show
        audioFrame.RewindAudio = true;                                      // Rewind after playing

        // Set fade in/out durations (in milliseconds)
        audioFrame.FadeInDuration = 200f;                                   // Fade in 200 ms
        audioFrame.FadeOutDuration = 500f;                                  // Fade out 500 ms

        // Set trimming times (in milliseconds)
        audioFrame.TrimFromStart = 1500f;                                   // Trim first 1.5 seconds
        audioFrame.TrimFromEnd = 2000f;                                     // Trim last 2 seconds

        // Save the modified presentation
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up resources
        audioStream.Close();
        pres.Dispose();
    }
}