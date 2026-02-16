using System;
using System.IO;
using Aspose.Words;
using Aspose.Words.Drawing;

class InsertOleObjectExample
{
    static void Main()
    {
        // Create a new blank document.
        Document doc = new Document();

        // Initialize DocumentBuilder for inserting content.
        DocumentBuilder builder = new DocumentBuilder(doc);

        // Path to the file that will be embedded as an OLE package (example: a ZIP archive).
        string dataDir = @"C:\Data\";
        string sourceFile = Path.Combine(dataDir, "cat001.zip");

        // Read the source file into a byte array.
        byte[] fileBytes = File.ReadAllBytes(sourceFile);

        // Insert the OLE object using a memory stream.
        using (MemoryStream stream = new MemoryStream(fileBytes))
        {
            // InsertOleObject parameters:
            //   stream          – the data stream of the file to embed.
            //   progId          – "Package" indicates an OLE package.
            //   isIcon          – true to display the object as an icon.
            //   iconFileName    – null to use the default icon.
            Shape oleShape = builder.InsertOleObject(stream, "Package", true, null);

            // Set the display name and file name that Word will show for the OLE package.
            oleShape.OleFormat.OlePackage.FileName = "Package file name.zip";
            oleShape.OleFormat.OlePackage.DisplayName = "Package display name.zip";
        }

        // Save the document in DOCX format.
        string outputFile = Path.Combine(dataDir, "InsertOlePackage.docx");
        doc.Save(outputFile);
    }
}
