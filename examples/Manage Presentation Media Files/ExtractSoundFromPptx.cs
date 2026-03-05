using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Load the PPTX presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Iterate through all slides
        for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
        {
            Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

            // Get the main sequence of animation effects for the slide
            Aspose.Slides.Animation.ISequence effectsSequence = slide.Timeline.MainSequence;

            // Iterate through each effect in the sequence
            foreach (Aspose.Slides.Animation.IEffect effect in effectsSequence)
            {
                // Check if the effect has an associated sound
                if (effect.Sound != null)
                {
                    // Extract the sound data as a byte array
                    byte[] audioData = effect.Sound.BinaryData;

                    // Example: save the extracted audio to a file
                    string outputFile = $"effect_sound_slide{slideIndex}_{Guid.NewGuid()}.wav";
                    File.WriteAllBytes(outputFile, audioData);
                }
            }
        }

        // Save the presentation before exiting
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}