using System;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Load the source presentation
        using (Aspose.Slides.Presentation sourcePres = new Aspose.Slides.Presentation("source.pptx"))
        {
            // Get the slide collection
            Aspose.Slides.ISlideCollection slideCollection = sourcePres.Slides;

            // Clone the first slide and add it to the end of the collection
            Aspose.Slides.ISlide clonedSlide1 = slideCollection.AddClone(slideCollection[0]);

            // Clone the second slide and add it to the end of the collection
            Aspose.Slides.ISlide clonedSlide2 = slideCollection.AddClone(slideCollection[1]);

            // Save the modified presentation
            sourcePres.Save("cloned_output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}