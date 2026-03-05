using System;
using System.IO;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Load presentation from a file
        Aspose.Slides.Presentation presentationFromFile = new Aspose.Slides.Presentation("input.pptx");
        presentationFromFile.Save("output_from_file.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        presentationFromFile.Dispose();

        // Load presentation from a stream
        FileStream fileStream = new FileStream("input.pptx", FileMode.Open, FileAccess.Read);
        Aspose.Slides.Presentation presentationFromStream = new Aspose.Slides.Presentation(fileStream);
        presentationFromStream.Save("output_from_stream.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        presentationFromStream.Dispose();
        fileStream.Close();

        // Load presentation from a byte array
        byte[] data = File.ReadAllBytes("input.pptx");
        Aspose.Slides.PresentationFactory factory = new Aspose.Slides.PresentationFactory();
        Aspose.Slides.IPresentation ipresentation = factory.ReadPresentation(data);
        Aspose.Slides.Presentation presentationFromBytes = ipresentation as Aspose.Slides.Presentation;
        if (presentationFromBytes != null)
        {
            presentationFromBytes.Save("output_from_bytes.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            presentationFromBytes.Dispose();
        }
    }
}