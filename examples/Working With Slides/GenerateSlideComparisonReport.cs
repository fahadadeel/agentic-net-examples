using System;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Load the source presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Get the total number of slides
        int slideCount = presentation.Slides.Count;

        // Compare each pair of slides
        for (int i = 0; i < slideCount; i++)
        {
            Aspose.Slides.ISlide slideI = presentation.Slides[i];
            for (int j = i + 1; j < slideCount; j++)
            {
                Aspose.Slides.ISlide slideJ = presentation.Slides[j];
                bool areEqual = slideI.Equals(slideJ);
                if (areEqual)
                {
                    Console.WriteLine(string.Format("Slide #{0} is equal to Slide #{1}", i, j));
                }
            }
        }

        // Save the (potentially unchanged) presentation before exiting
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}