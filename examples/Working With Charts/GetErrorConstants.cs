using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation and save it (required before exiting)
        Aspose.Slides.Presentation validPresentation = new Aspose.Slides.Presentation();
        validPresentation.Save("ValidPresentation.pptx", SaveFormat.Pptx);
        validPresentation.Dispose();

        // Demonstrate handling of various Aspose.Slides exceptions
        try
        {
            // Attempt to load a non‑existent or corrupt file to trigger a read exception
            Aspose.Slides.Presentation corruptedPresentation = new Aspose.Slides.Presentation("CorruptedOrMissing.pptx");
            // If loading succeeds, attempt an edit operation that could cause an edit exception
            corruptedPresentation.Slides.AddEmptySlide(corruptedPresentation.Slides[0].LayoutSlide);
            corruptedPresentation.Save("EditedPresentation.pptx", SaveFormat.Pptx);
            corruptedPresentation.Dispose();
        }
        catch (Aspose.Slides.PptxReadException ex)
        {
            Console.WriteLine("Caught PptxReadException: " + ex.Message);
        }
        catch (Aspose.Slides.PptReadException ex)
        {
            Console.WriteLine("Caught PptReadException: " + ex.Message);
        }
        catch (Aspose.Slides.PptxEditException ex)
        {
            Console.WriteLine("Caught PptxEditException: " + ex.Message);
        }
        catch (Aspose.Slides.PptEditException ex)
        {
            Console.WriteLine("Caught PptEditException: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Caught general exception: " + ex.Message);
        }
    }
}