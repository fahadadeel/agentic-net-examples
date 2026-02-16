using System;
using Aspose.Words;
using Aspose.Words.Markup;

class ExtractBetweenNodes
{
    static void Main()
    {
        // Load the PDF file into an Aspose.Words Document.
        // Aspose.Words can directly load PDF files.
        Document doc = new Document("input.pdf");

        // Assume the PDF (now a Word document) contains two bookmarks:
        // "StartBookmark" marks the beginning and "EndBookmark" marks the end of the region to extract.
        // Retrieve the bookmark objects.
        Bookmark startBookmark = doc.Range.Bookmarks["StartBookmark"];
        Bookmark endBookmark = doc.Range.Bookmarks["EndBookmark"];

        if (startBookmark == null || endBookmark == null)
        {
            Console.WriteLine("Required bookmarks not found.");
            return;
        }

        // The BookmarkStart node marks the first node of the region,
        // the BookmarkEnd node marks the node just after the region.
        Node startNode = startBookmark.BookmarkStart;
        Node endNode = endBookmark.BookmarkEnd;

        // Build a temporary document that will contain only the nodes between the two bookmarks.
        Document extracted = new Document();
        NodeImporter importer = new NodeImporter(doc, extracted, ImportFormatMode.KeepSourceFormatting);

        // Iterate through the nodes starting after the start bookmark until we reach the end bookmark.
        Node curNode = startNode.NextSibling;
        while (curNode != null && curNode != endNode)
        {
            // Import the node into the new document and append it.
            Node importedNode = importer.ImportNode(curNode, true);
            extracted.FirstSection.Body.AppendChild(importedNode);
            curNode = curNode.NextSibling;
        }

        // The extracted document now contains the desired content.
        // Save it as plain text (or any other format you need).
        extracted.Save("extracted.txt", SaveFormat.Text);

        Console.WriteLine("Content extracted and saved to extracted.txt");
    }
}
