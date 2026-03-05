using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the first presentation
        using (Aspose.Slides.Presentation presentation1 = new Aspose.Slides.Presentation("presentation1.pptx"))
        {
            // Load the second presentation
            using (Aspose.Slides.Presentation presentation2 = new Aspose.Slides.Presentation("presentation2.pptx"))
            {
                // Iterate through all slides in the first presentation
                for (int i = 0; i < presentation1.Slides.Count; i++)
                {
                    Aspose.Slides.ISlide slide1 = presentation1.Slides[i];

                    // Iterate through all slides in the second presentation
                    for (int j = 0; j < presentation2.Slides.Count; j++)
                    {
                        Aspose.Slides.ISlide slide2 = presentation2.Slides[j];

                        // Compare slides using the Equals method
                        if (slide1.Equals(slide2))
                        {
                            Console.WriteLine(string.Format("Slide #{0} in presentation1 is equal to slide #{1} in presentation2", i, j));
                        }
                    }
                }
            }

            // Save the first presentation before exiting
            presentation1.Save("presentation1_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}