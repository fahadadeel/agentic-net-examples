using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace MergePresentations
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation files
            System.String sourcePath = "SourcePresentation.pptx";
            System.String destinationPath = "DestinationPresentation.pptx";
            System.String outputPath = "MergedPresentation.pptx";

            // Load source and destination presentations
            Aspose.Slides.Presentation sourcePres = new Aspose.Slides.Presentation(sourcePath);
            Aspose.Slides.Presentation destPres = new Aspose.Slides.Presentation(destinationPath);

            // Ensure destination has a suitable layout slide (TitleAndObject or Title)
            // Using the add-layout-slides rule logic
            Aspose.Slides.IMasterLayoutSlideCollection destLayoutSlides = destPres.Masters[0].LayoutSlides;
            Aspose.Slides.ILayoutSlide destLayoutSlide = destLayoutSlides.GetByType(Aspose.Slides.SlideLayoutType.TitleAndObject) ??
                                                          destLayoutSlides.GetByType(Aspose.Slides.SlideLayoutType.Title);
            if (destLayoutSlide == null)
            {
                foreach (Aspose.Slides.ILayoutSlide ls in destLayoutSlides)
                {
                    if (ls.Name == "Title and Content")
                    {
                        destLayoutSlide = ls;
                        break;
                    }
                }
                if (destLayoutSlide == null)
                {
                    foreach (Aspose.Slides.ILayoutSlide ls in destLayoutSlides)
                    {
                        if (ls.Name == "Title")
                        {
                            destLayoutSlide = ls;
                            break;
                        }
                    }
                }
                if (destLayoutSlide == null)
                {
                    destLayoutSlide = destLayoutSlides.GetByType(Aspose.Slides.SlideLayoutType.Blank);
                    if (destLayoutSlide == null)
                    {
                        destLayoutSlide = destLayoutSlides.Add(Aspose.Slides.SlideLayoutType.TitleAndObject, "Title and Content");
                    }
                }
            }

            // Insert an empty slide at the beginning using the selected layout (optional)
            destPres.Slides.InsertEmptySlide(0, destLayoutSlide);

            // Clone each slide from source into destination, preserving master layout
            for (System.Int32 i = 0; i < sourcePres.Slides.Count; i++)
            {
                Aspose.Slides.ISlide sourceSlide = sourcePres.Slides[i];
                Aspose.Slides.IMasterSlide sourceMaster = sourceSlide.LayoutSlide.MasterSlide;
                Aspose.Slides.IMasterSlide destMaster = destPres.Masters.AddClone(sourceMaster);
                // Using the clone-to-another-presentation-with-master rule
                destPres.Slides.AddClone(sourceSlide, destMaster, true);
            }

            // Save the merged presentation
            destPres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose presentations
            sourcePres.Dispose();
            destPres.Dispose();
        }
    }
}