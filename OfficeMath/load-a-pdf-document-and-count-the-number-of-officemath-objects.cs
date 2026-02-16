using System;
using Aspose.Words;
using Aspose.Words.Math;
using Aspose.Words.Loading;

class Program
{
    static void Main()
    {
        // Path to the PDF file to be loaded.
        const string pdfPath = "input.pdf";

        // Load the PDF document using PdfLoadOptions.
        var loadOptions = new PdfLoadOptions();
        Document doc = new Document(pdfPath, loadOptions);

        // Retrieve all OfficeMath nodes in the document (including those in child nodes).
        NodeCollection officeMathNodes = doc.GetChildNodes(NodeType.OfficeMath, true);

        // Count the number of OfficeMath objects.
        int officeMathCount = officeMathNodes.Count;

        // Output the result.
        Console.WriteLine($"Number of OfficeMath objects: {officeMathCount}");
    }
}
