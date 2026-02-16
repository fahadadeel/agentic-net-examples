using System;
using System.IO;
using System.Linq;
using Aspose.Words;
// The Comment class resides directly in the Aspose.Words namespace; no separate Comments namespace is required.

namespace CommentExtractionDemo
{
    class Program
    {
        /// <summary>
        /// Extracts comments from a DOCX file.
        /// If <paramref name="author"/> is null or empty, all comments are extracted.
        /// Otherwise only comments whose Author matches the supplied value are extracted.
        /// The extracted comments are written to a plain‑text file.
        /// </summary>
        static void Main(string[] args)
        {
            // Example usage:
            // args[0] – input DOCX file path
            // args[1] – output text file path
            // args[2] – (optional) author name to filter by
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: CommentExtractionDemo <input.docx> <output.txt> [author]");
                return;
            }

            string inputPath = args[0];
            string outputPath = args[1];
            string? authorFilter = args.Length >= 3 ? args[2] : null;

            ExtractComments(inputPath, outputPath, authorFilter);
        }

        /// <summary>
        /// Loads the document, gathers the required comments and writes them to a file.
        /// </summary>
        /// <param name="docPath">Path to the DOCX file.</param>
        /// <param name="outputPath">Path where the extracted comments will be saved.</param>
        /// <param name="author">Optional author name to filter comments.</param>
        public static void ExtractComments(string docPath, string outputPath, string? author = null)
        {
            // Load the document from disk.
            Document doc = new Document(docPath);

            // Retrieve all Comment nodes in the document (including nested comments).
            var allComments = doc.GetChildNodes(NodeType.Comment, true)
                                 .OfType<Comment>();

            // If an author filter is supplied, keep only matching comments.
            var filteredComments = string.IsNullOrEmpty(author)
                ? allComments
                : allComments.Where(c => string.Equals(c.Author, author, StringComparison.OrdinalIgnoreCase));

            // Write the extracted comments to the output file.
            using (StreamWriter writer = new StreamWriter(outputPath, false))
            {
                foreach (Comment comment in filteredComments)
                {
                    writer.WriteLine($"Comment Id: {comment.Id}");
                    writer.WriteLine($"Author   : {comment.Author}");
                    writer.WriteLine($"DateTime : {comment.DateTime}");
                    writer.WriteLine("Text     :");
                    writer.WriteLine(comment.GetText().Trim());
                    writer.WriteLine(new string('-', 40));
                }
            }

            Console.WriteLine($"Extracted {(author == null ? "all" : $"author \"{author}\"")} comments to \"{outputPath}\".");
        }
    }
}
