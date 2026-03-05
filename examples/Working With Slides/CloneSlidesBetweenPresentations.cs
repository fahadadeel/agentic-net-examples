using System;

class Program
{
    static void Main(string[] args)
    {
        // Paths to the source and destination presentations
        string sourcePath = "source.pptx";
        string destinationPath = "dest.pptx";

        // Load the source presentation
        Aspose.Slides.Presentation srcPres = new Aspose.Slides.Presentation(sourcePath);

        // Create a new (empty) destination presentation
        Aspose.Slides.Presentation destPres = new Aspose.Slides.Presentation();

        // Get the first slide from the source presentation
        Aspose.Slides.ISlide sourceSlide = srcPres.Slides[0];

        // Get the master slide associated with the source slide's layout
        Aspose.Slides.IMasterSlide sourceMaster = sourceSlide.LayoutSlide.MasterSlide;

        // Clone the source master slide into the destination presentation
        Aspose.Slides.IMasterSlide destMaster = destPres.Masters.AddClone(sourceMaster);

        // Clone the source slide into the destination presentation using the cloned master
        destPres.Slides.AddClone(sourceSlide, destMaster, true);

        // Save the destination presentation
        destPres.Save(destinationPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up resources
        srcPres.Dispose();
        destPres.Dispose();
    }
}