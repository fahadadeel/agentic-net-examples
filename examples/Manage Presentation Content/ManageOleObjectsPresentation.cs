using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.DOM.Ole;

class Program
{
    static void Main()
    {
        // Output directory for the generated presentation
        string outDir = "Output";
        if (!Directory.Exists(outDir))
            Directory.CreateDirectory(outDir);

        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Load the file to be embedded as OLE (example: an Excel file)
        byte[] oleFileData = File.ReadAllBytes("sample.xlsx");

        // Create OLE embedded data info (fully qualified type)
        Aspose.Slides.IOleEmbeddedDataInfo dataInfo = new Aspose.Slides.DOM.Ole.OleEmbeddedDataInfo(oleFileData, "xlsx");

        // Add an OLE object frame to the slide using the data info
        Aspose.Slides.IOleObjectFrame oleObjectFrame = slide.Shapes.AddOleObjectFrame(
            0,                                   // X position
            0,                                   // Y position
            presentation.SlideSize.Size.Width,   // Width
            presentation.SlideSize.Size.Height,  // Height
            dataInfo);

        // Set the OLE object to be displayed as an icon and give it a title
        oleObjectFrame.IsObjectIcon = true;
        oleObjectFrame.SubstitutePictureTitle = "Embedded Excel";

        // Save the presentation in PPTX format before exiting
        presentation.Save(Path.Combine(outDir, "OleObjectPresentation.pptx"), Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}