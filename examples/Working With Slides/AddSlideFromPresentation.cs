using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AddSlideExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string dataDir = Path.Combine(Environment.CurrentDirectory, "Data");
            string sourcePath = Path.Combine(dataDir, "SourcePresentation.pptx");
            string outputPath = Path.Combine(dataDir, "ResultPresentation.pptx");

            // Load the source presentation
            Aspose.Slides.Presentation sourcePres = new Aspose.Slides.Presentation(sourcePath);

            // Create a new destination presentation
            Aspose.Slides.Presentation destPres = new Aspose.Slides.Presentation();

            // Get the first slide from the source presentation
            Aspose.Slides.ISlide sourceSlide = sourcePres.Slides[0];

            // Get the master slide associated with the source slide
            Aspose.Slides.IMasterSlide sourceMaster = sourceSlide.LayoutSlide.MasterSlide;

            // Clone the master slide into the destination presentation
            Aspose.Slides.IMasterSlide destMaster = destPres.Masters.AddClone(sourceMaster);

            // Clone the source slide into the destination presentation using the cloned master
            destPres.Slides.AddClone(sourceSlide, destMaster, true);

            // Save the destination presentation
            destPres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Clean up resources
            sourcePres.Dispose();
            destPres.Dispose();
        }
    }
}