using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace MergePresentations
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths of source presentations to be merged
            string[] sourceFiles = new string[]
            {
                "Presentation1.pptx",
                "Presentation2.pptx",
                "Presentation3.pptx"
            };

            // Path for the merged output presentation
            string outputFile = "MergedPresentation.pptx";

            try
            {
                // Create a new empty presentation
                using (Presentation mergedPresentation = new Presentation())
                {
                    // Remove the default empty slide created by the constructor
                    if (mergedPresentation.Slides.Count > 0)
                    {
                        mergedPresentation.Slides.RemoveAt(0);
                    }

                    // Iterate over each source file and copy its slides
                    foreach (string sourcePath in sourceFiles)
                    {
                        // Load the source presentation
                        using (Presentation sourcePresentation = new Presentation(sourcePath))
                        {
                            // Clone each slide from the source into the merged presentation
                            foreach (ISlide sourceSlide in sourcePresentation.Slides)
                            {
                                mergedPresentation.Slides.AddClone(sourceSlide);
                            }
                        }
                    }

                    // Save the merged presentation in PPTX format
                    mergedPresentation.Save(outputFile, SaveFormat.Pptx);
                }

                Console.WriteLine("Presentations merged successfully into: " + outputFile);
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during the merge process
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}