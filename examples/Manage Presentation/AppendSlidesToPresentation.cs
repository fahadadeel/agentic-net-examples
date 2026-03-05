using System;

class Program
{
    static void Main(string[] args)
    {
        // Paths to the source and target presentations
        string sourcePath = "source.pptx";
        string targetPath = "target.pptx";
        string outputPath = "merged.pptx";

        // Load the source presentation
        Aspose.Slides.Presentation sourcePres = new Aspose.Slides.Presentation(sourcePath);
        // Load the target presentation
        Aspose.Slides.Presentation targetPres = new Aspose.Slides.Presentation(targetPath);

        // Get slide collections
        Aspose.Slides.ISlideCollection sourceSlides = sourcePres.Slides;
        Aspose.Slides.ISlideCollection targetSlides = targetPres.Slides;

        // Append each slide from the source to the target
        for (int i = 0; i < sourceSlides.Count; i++)
        {
            Aspose.Slides.ISlide sourceSlide = sourceSlides[i];
            targetSlides.AddClone(sourceSlide);
        }

        // Save the merged presentation
        targetPres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up resources
        sourcePres.Dispose();
        targetPres.Dispose();
    }
}