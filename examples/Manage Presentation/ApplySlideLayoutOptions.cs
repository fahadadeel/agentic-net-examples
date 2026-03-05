using System;

class Program
{
    static void Main(string[] args)
    {
        // Input file paths
        string sourcePath = "source.pptx";
        string destinationPath = "dest.pptx";
        string outputPath = "merged.pptx";

        // Load source and destination presentations
        Aspose.Slides.Presentation sourcePres = new Aspose.Slides.Presentation(sourcePath);
        Aspose.Slides.Presentation destPres = new Aspose.Slides.Presentation(destinationPath);

        // Clone layout slides from source to destination to preserve layout options
        Aspose.Slides.IGlobalLayoutSlideCollection destLayouts = destPres.LayoutSlides;
        foreach (Aspose.Slides.ILayoutSlide srcLayout in sourcePres.LayoutSlides)
        {
            destLayouts.AddClone(srcLayout);
        }

        // Merge slides from source into destination, cloning masters as needed
        foreach (Aspose.Slides.ISlide srcSlide in sourcePres.Slides)
        {
            Aspose.Slides.IMasterSlide srcMaster = srcSlide.LayoutSlide.MasterSlide;
            Aspose.Slides.IMasterSlide destMaster = destPres.Masters.AddClone(srcMaster);
            destPres.Slides.AddClone(srcSlide, destMaster, true);
        }

        // Save the merged presentation in PPTX format
        destPres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up resources
        sourcePres.Dispose();
        destPres.Dispose();
    }
}