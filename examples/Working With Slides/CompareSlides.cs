using System;
using Aspose.Slides;

namespace CompareSlidesApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths to the presentations to compare
            string filePath1 = "Presentation1.pptx";
            string filePath2 = "Presentation2.pptx";

            // Load the presentations
            using (Aspose.Slides.Presentation pres1 = new Aspose.Slides.Presentation(filePath1))
            using (Aspose.Slides.Presentation pres2 = new Aspose.Slides.Presentation(filePath2))
            {
                // Compare master slides using the Equals method
                for (int i = 0; i < pres1.Masters.Count; i++)
                {
                    for (int j = 0; j < pres2.Masters.Count; j++)
                    {
                        if (pres1.Masters[i].Equals(pres2.Masters[j]))
                        {
                            Console.WriteLine(string.Format(
                                "Master slide #{0} in Presentation1 is equal to Master slide #{1} in Presentation2",
                                i, j));
                        }
                    }
                }

                // Optional: compare regular slides as well
                int slideCount = Math.Min(pres1.Slides.Count, pres2.Slides.Count);
                for (int k = 0; k < slideCount; k++)
                {
                    if (pres1.Slides[k].Equals(pres2.Slides[k]))
                    {
                        Console.WriteLine(string.Format(
                            "Slide #{0} is equal in both presentations", k));
                    }
                }

                // Save the first presentation (required by authoring rule)
                pres1.Save("ComparisonResult.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}