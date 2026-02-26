using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Paths for the embedded Excel file and the output presentation
        string inputExcelPath = "input.xlsx";
        string outputPresentationPath = "PreventOleResize.pptx";

        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Read the Excel file into a byte array
        byte[] excelData = System.IO.File.ReadAllBytes(inputExcelPath);

        // Create OLE embedded data info (extension without dot)
        Aspose.Slides.IOleEmbeddedDataInfo dataInfo = new Aspose.Slides.DOM.Ole.OleEmbeddedDataInfo(excelData, "xlsx");

        // Add an OLE object frame that fills the whole slide
        Aspose.Slides.IOleObjectFrame oleObjectFrame = slide.Shapes.AddOleObjectFrame(
            0f,
            0f,
            presentation.SlideSize.Size.Width,
            presentation.SlideSize.Size.Height,
            dataInfo);

        // Prevent resizing and moving of the OLE object frame
        oleObjectFrame.ShapeLock.SizeLocked = true;
        // PositionLocked is part of IGraphicalObjectLock; set it if available
        oleObjectFrame.ShapeLock.PositionLocked = true;

        // Save the presentation in PPTX format
        presentation.Save(outputPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}