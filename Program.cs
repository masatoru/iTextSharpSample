using System;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace iTextSharpSample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using var fs = new FileStream(@".\sample.pdf", FileMode.Create, FileAccess.Write, FileShare.None);
                var document = new Document(PageSize.A4, 25, 25, 30, 30);
                var writer = PdfWriter.GetInstance(document, fs);

                // Add meta information to the document
                document.AddAuthor("Satoru Fujimori");
                document.AddCreator("Sample application using iTestSharp");
                document.AddKeywords("PDF tutorial education");
                document.AddSubject("Document subject - Describing the steps creating a PDF document");
                document.AddTitle("The document title - PDF creation using iTextSharp");

                // Open the document to enable you to write to the document
                document.Open();

                // Add a simple and wellknown phrase to the document
                for (int x = 0; x != 100; x++)
                {
                    document.Add(new Paragraph("Paragraph - Hello World!"));
                }

                // Close the document
                document.Close();
                writer.Close();
                fs.Close();

                Console.WriteLine("Document saved to the pdf folder.");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"error msg={ex.Message}");
            }
        }
    }
}
