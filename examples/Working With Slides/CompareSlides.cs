using System;

namespace CompareSlidesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths to the source presentations
            string inputPath1 = "Presentation1.pptx";
            string inputPath2 = "Presentation2.pptx";

            // Path for the output presentation (required to save before exit)
            string outputPath = "Result.pptx";

            // Load the two presentations
            Aspose.Slides.Presentation presentation1 = new Aspose.Slides.Presentation(inputPath1);
            Aspose.Slides.Presentation presentation2 = new Aspose.Slides.Presentation(inputPath2);

            // Compare master slides using BaseSlide.Equals
            for (int i = 0; i < presentation1.Masters.Count; i++)
            {
                for (int j = 0; j < presentation2.Masters.Count; j++)
                {
                    if (presentation1.Masters[i].Equals(presentation2.Masters[j]))
                    {
                        Console.WriteLine($"Master slide #{i} of presentation1 is equal to master slide #{j} of presentation2");
                    }
                }
            }

            // Compare regular slides using BaseSlide.Equals
            for (int i = 0; i < presentation1.Slides.Count; i++)
            {
                for (int j = 0; j < presentation2.Slides.Count; j++)
                {
                    if (presentation1.Slides[i].Equals(presentation2.Slides[j]))
                    {
                        Console.WriteLine($"Slide #{i} of presentation1 is equal to slide #{j} of presentation2");
                    }
                }
            }

            // Save one of the presentations before exiting (required by the task)
            presentation1.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Clean up resources
            presentation1.Dispose();
            presentation2.Dispose();
        }
    }
}