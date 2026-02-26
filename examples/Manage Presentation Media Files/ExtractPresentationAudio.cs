using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputAudioPath = "extractedAudio.wav";

        // Load the presentation
        Presentation pres = new Presentation(inputPath);

        // Get the first slide
        ISlide slide = pres.Slides[0];

        // Get the main sequence of animations on the slide
        ISequence effectsSequence = slide.Timeline.MainSequence;

        // Extract audio from the first effect, if any
        if (effectsSequence.Count > 0)
        {
            IEffect firstEffect = effectsSequence[0];
            IAudio audio = firstEffect.Sound;
            if (audio != null && audio.BinaryData != null)
            {
                File.WriteAllBytes(outputAudioPath, audio.BinaryData);
            }
        }

        // Save the (unchanged) presentation before exiting
        pres.Save("output.pptx", SaveFormat.Pptx);
        pres.Dispose();
    }
}