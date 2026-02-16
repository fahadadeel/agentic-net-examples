using System;
using System.IO;
using System.Text;
using Aspose.Words;

class ExtractBetweenNodes
{
    static void Main()
    {
        // Load the DOCX file.
        Document doc = new Document("Input.docx");

        // Assume the content to extract is delimited by two bookmarks named "Start" and "End".
        // Retrieve the bookmarks from the document.
        Bookmark startBookmark = doc.Range.Bookmarks["Start"];
        Bookmark endBookmark = doc.Range.Bookmarks["End"];

        if (startBookmark == null || endBookmark == null)
        {
            Console.WriteLine("Required bookmarks not found.");
            return;
        }

        // Use the BookmarkStart and BookmarkEnd nodes – these are the actual nodes in the document tree.
        Node startNode = startBookmark.BookmarkStart;
        Node endNode = endBookmark.BookmarkEnd;

        // Collect text from all nodes that lie between the start and end nodes (exclusive).
        StringBuilder extractedText = new StringBuilder();

        // Move to the first node after the start bookmark.
        Node current = startNode.NextPreOrder(startNode);
        while (current != null && current != endNode)
        {
            extractedText.Append(current.GetText());
            current = current.NextPreOrder(current);
        }

        // Output the extracted text to the console.
        Console.WriteLine("Extracted Text:");
        Console.WriteLine(extractedText.ToString());

        // Optionally, save the extracted text to a plain‑text file.
        File.WriteAllText("ExtractedContent.txt", extractedText.ToString());
    }
}
