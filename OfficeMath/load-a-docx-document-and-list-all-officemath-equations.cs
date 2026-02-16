using System;
using Aspose.Words;
using Aspose.Words.Math;

class ListOfficeMath
{
    static void Main()
    {
        // Load the DOCX document.
        string docPath = "input.docx";
        Document doc = new Document(docPath);

        // Retrieve all OfficeMath nodes in the document (including nested ones).
        NodeCollection officeMathNodes = doc.GetChildNodes(NodeType.OfficeMath, true);

        Console.WriteLine($"Total OfficeMath equations found: {officeMathNodes.Count}");

        // Iterate through each OfficeMath node and output its type and textual representation.
        foreach (OfficeMath officeMath in officeMathNodes)
        {
            string equationText = officeMath.Range.Text.Trim();
            Console.WriteLine($"- Type: {officeMath.MathObjectType}, Text: \"{equationText}\"");
        }
    }
}
