using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.DOM.Ole;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Path to the file to embed as OLE object (e.g., an Excel workbook)
        string oleFilePath = "sample.xlsx";

        // Read the file data into a byte array
        byte[] oleFileData = System.IO.File.ReadAllBytes(oleFilePath);

        // Create OLE embedded data info (file data and extension)
        Aspose.Slides.IOleEmbeddedDataInfo oleDataInfo = new Aspose.Slides.DOM.Ole.OleEmbeddedDataInfo(oleFileData, "xlsx");

        // Add an OLE object frame that covers the entire slide
        Aspose.Slides.IOleObjectFrame oleObjectFrame = slide.Shapes.AddOleObjectFrame(
            0,
            0,
            presentation.SlideSize.Size.Width,
            presentation.SlideSize.Size.Height,
            oleDataInfo);

        // Optionally display the OLE object as an icon
        oleObjectFrame.IsObjectIcon = true;

        // Save the presentation before exiting
        string outputPath = "ActiveX_OLE_Output.pptx";
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}