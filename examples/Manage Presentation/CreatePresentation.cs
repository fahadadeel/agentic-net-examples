using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation (contains one empty slide)
            using (Presentation presentation = new Presentation())
            {
                // Save the presentation in PPTX format
                presentation.Save("NewPresentation.pptx", SaveFormat.Pptx);
            }
        }
    }
}