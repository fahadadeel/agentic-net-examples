using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the presentation from a file
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Iterate through all slides in the presentation
        for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
        {
            Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

            // Get the main sequence of animation effects for the current slide
            Aspose.Slides.Animation.ISequence mainSequence = slide.Timeline.MainSequence;

            int effectCounter = 0;

            // Iterate through each effect in the sequence
            foreach (Aspose.Slides.Animation.IEffect effect in mainSequence)
            {
                effectCounter++;

                // Skip effects that do not have an associated sound
                if (effect.Sound == null)
                {
                    continue;
                }

                // Extract the sound data as a byte array
                byte[] audioBytes = effect.Sound.BinaryData;

                // Save the extracted audio to a file (optional)
                string outputFileName = $"Slide{slideIndex + 1}_Effect{effectCounter}.mp3";
                File.WriteAllBytes(outputFileName, audioBytes);
            }
        }

        // Save the (potentially unchanged) presentation before exiting
        presentation.Save("output.pptx", SaveFormat.Pptx);
    }
}