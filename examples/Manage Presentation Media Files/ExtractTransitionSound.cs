using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the presentation from file
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Iterate through all slides
        for (int i = 0; i < presentation.Slides.Count; i++)
        {
            // Get the current slide
            Aspose.Slides.ISlide slide = presentation.Slides[i];

            // Access the slide show transition of the slide
            Aspose.Slides.ISlideShowTransition transition = slide.SlideShowTransition;

            // Get the embedded sound for the transition, if any
            Aspose.Slides.IAudio transitionSound = transition.Sound;

            if (transitionSound != null)
            {
                // Extract the binary audio data
                byte[] audioData = transitionSound.BinaryData;

                // Define output file name for the extracted sound
                string outputFile = $"Slide_{i + 1}_TransitionSound.bin";

                // Write the audio data to a file
                File.WriteAllBytes(outputFile, audioData);
            }
        }

        // Save the presentation (no modifications made) before exiting
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose the presentation object
        presentation.Dispose();
    }
}