using System;
using System.Collections.Generic;
using System.Linq;
using Aspose.Words;
using Aspose.Words.Tables;

namespace AsposeWordsCellMergingDemo
{
    // Simple data model for demonstration.
    public class Product
    {
        public string Category { get; set; }
        public string Name { get; set; }

        public Product(string category, string name)
        {
            Category = category;
            Name = name;
        }
    }

    class Program
    {
        static void Main()
        {
            // Create a new blank document.
            Document doc = new Document();
            DocumentBuilder builder = new DocumentBuilder(doc);

            // Build the table header.
            Table table = builder.StartTable();
            builder.InsertCell();
            builder.Write("Category");
            builder.InsertCell();
            builder.Write("Product");
            builder.EndRow();

            // Sample data to be merged.
            List<Product> products = new List<Product>
            {
                new Product("Beverages", "Tea"),
                new Product("Beverages", "Coffee"),
                new Product("Beverages", "Juice"),
                new Product("Snacks", "Chips"),
                new Product("Snacks", "Cookies")
            };

            // Group products by Category using LINQ.
            var groups = products.GroupBy(p => p.Category);

            // Iterate over each group and create rows.
            foreach (var group in groups)
            {
                bool firstRowInGroup = true;

                foreach (var product in group)
                {
                    // Insert Category cell.
                    builder.InsertCell();

                    // For the first row of the group we start a vertical merge.
                    // Subsequent rows are merged to the previous cell.
                    builder.CellFormat.VerticalMerge = firstRowInGroup
                        ? CellMerge.First
                        : CellMerge.Previous;

                    // Write the category text only on the first row.
                    if (firstRowInGroup)
                        builder.Write(group.Key);

                    // Insert Product cell.
                    builder.InsertCell();
                    builder.Write(product.Name);

                    // End the current row.
                    builder.EndRow();

                    // After the first iteration reset the flag.
                    firstRowInGroup = false;
                }

                // Reset the merge setting so that following rows are not affected.
                builder.CellFormat.VerticalMerge = CellMerge.None;
            }

            // Finish the table.
            builder.EndTable();

            // Save the document in DOCX format.
            doc.Save("MergedCellsReport.docx");
        }
    }
}
