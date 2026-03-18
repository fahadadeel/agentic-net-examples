using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Input presentation files
            string[] sourceFiles = new string[] { "input1.pptx", "input2.pptx", "input3.pptx" };
            // Output combined presentation
            string outputFile = "CombinedPresentation.pptx";

            // Create a new empty presentation
            using (Aspose.Slides.Presentation resultPresentation = new Aspose.Slides.Presentation())
            {
                // Remove the default empty slide
                resultPresentation.Slides.RemoveAt(0);

                // Iterate over each source presentation
                foreach (string filePath in sourceFiles)
                {
                    using (Aspose.Slides.Presentation sourcePresentation = new Aspose.Slides.Presentation(filePath))
                    {
                        // Clone each slide into the result presentation
                        foreach (Aspose.Slides.ISlide sourceSlide in sourcePresentation.Slides)
                        {
                            resultPresentation.Slides.InsertClone(resultPresentation.Slides.Count, sourceSlide);
                        }
                    }
                }

                // Save the combined presentation
                resultPresentation.Save(outputFile, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}