using System;

class Program
{
    static void Main()
    {
        // Load the presentation from a file
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Compare each pair of slides in the presentation
        for (int i = 0; i < presentation.Slides.Count; i++)
        {
            for (int j = i + 1; j < presentation.Slides.Count; j++)
            {
                bool areEqual = presentation.Slides[i].Equals(presentation.Slides[j]);
                if (areEqual)
                {
                    Console.WriteLine(string.Format("Slide #{0} is equal to Slide #{1}", i, j));
                }
                else
                {
                    Console.WriteLine(string.Format("Slide #{0} is different from Slide #{1}", i, j));
                }
            }
        }

        // Save the presentation (even if unchanged) before exiting
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}