using System;

namespace InsertSlidesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source presentation containing the slide to be inserted
            string sourcePath = "source.pptx";
            // Path where the resulting presentation will be saved
            string outputPath = "output.pptx";

            // Load the source presentation
            Aspose.Slides.Presentation srcPres = new Aspose.Slides.Presentation(sourcePath);
            // Create a new destination presentation (initially contains one empty slide)
            Aspose.Slides.Presentation destPres = new Aspose.Slides.Presentation();

            // Get the slide collection of the destination presentation
            Aspose.Slides.ISlideCollection slideCollection = destPres.Slides;

            // Insert a clone of the first slide from the source presentation
            // at position 1 (i.e., after the first slide) in the destination presentation
            slideCollection.InsertClone(1, srcPres.Slides[0]);

            // Save the modified presentation in PPTX format
            destPres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Release resources
            srcPres.Dispose();
            destPres.Dispose();
        }
    }
}