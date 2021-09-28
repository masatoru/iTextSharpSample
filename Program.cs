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
                // StreamUtil.AddToResourceSearch(System.Reflection.Assembly.Load("iTextAsian"));
                // StreamUtil.AddToResourceSearch(System.Reflection.Assembly.Load("iTextAsianCmaps"));

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

                //［1］ MSゴシック
                Font fnt1 = new Font(BaseFont.CreateFont
                    (@"c:\windows\fonts\msgothic.ttc,0", BaseFont.IDENTITY_H, true), 40);
                document.Add(new Paragraph($"こんにちは！！ MS ゴシック", fnt1));

                Font fnt2 = new Font(BaseFont.CreateFont
                    (@"c:\windows\fonts\msmincho.ttc,0", BaseFont.IDENTITY_H, true), 40);
                document.Add(new Paragraph($"こんにちは！！ MS 明朝", fnt2));

                // Subset=false で OK
                var baseFont = BaseFont.CreateFont
                (@"C:\Users\sator\AppData\Local\Microsoft\Windows\Fonts\ヒラギノ明朝 ProN W6.otf", BaseFont.IDENTITY_H,
                    true);
                baseFont.Subset = false;
                Font fnt4 = new Font(baseFont, 40);
                document.Add(new Paragraph($"こんにちは！！ ヒラギノ明朝 ProN W6", fnt4));

                // Close the document
                document.Close();
                writer.Close();
                fs.Close();

                Console.WriteLine("Document saved to the pdf folder.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"error msg={ex.Message}");
            }
        }
    }
}
