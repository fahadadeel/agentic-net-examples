using System;
using System.IO;
using Aspose.Words;
using Aspose.Words.Drawing;

class ExtractOleObject
{
    static void Main()
    {
        // Path to the source DOCX file that contains the OLE object.
        string sourceDocPath = @"C:\Docs\input.docx";

        // Directory where the extracted OLE files will be saved.
        string outputDirectory = @"C:\Docs\ExtractedOle";
        Directory.CreateDirectory(outputDirectory);

        // Load the Word document.
        Document doc = new Document(sourceDocPath);

        // Get all Shape nodes in the document (they can contain OLE objects).
        NodeCollection shapes = doc.GetChildNodes(NodeType.Shape, true);

        foreach (Shape shape in shapes)
        {
            // Ensure the shape actually has an OLE object.
            if (shape.OleFormat == null)
                continue;

            // Determine a file name for the extracted OLE data.
            // Prefer the suggested file name; fall back to a generic name with the suggested extension.
            string fileName = shape.OleFormat.SuggestedFileName;
            if (string.IsNullOrEmpty(fileName))
            {
                string extension = shape.OleFormat.SuggestedExtension;
                fileName = "OleObject" + (string.IsNullOrEmpty(extension) ? ".bin" : "." + extension);
            }

            string outputPath = Path.Combine(outputDirectory, fileName);

            // Save the embedded OLE object to the file system.
            // OleFormat.Save writes the raw OLE data (or the packaged file) to the specified path.
            shape.OleFormat.Save(outputPath);

            Console.WriteLine($"Extracted OLE object saved to: {outputPath}");
        }
    }
}
