using System.Text.RegularExpressions;
using Inventor;

namespace Revisioner
{
    public static class Utility
    {
        public static bool DocumentChecker(string allowedDocument, Inventor.Application inventorObject)
        {
            bool isValid;
            switch (allowedDocument)
            {
                case "Assembly":
                    isValid = inventorObject.ActiveDocumentType == DocumentTypeEnum.kAssemblyDocumentObject ? true : false;
                    break;
                case "Drawing":
                    isValid = inventorObject.ActiveDocumentType == DocumentTypeEnum.kDrawingDocumentObject ? true : false;
                    break;
                case "Part":
                    isValid = inventorObject.ActiveDocumentType == DocumentTypeEnum.kPartDocumentObject ? true : false;
                    break;
                default:
                    isValid = false;
                    break;
            }

            return isValid;
        }

        public static bool RevisionChecker(string documentName)
        {
            var rgx = new Regex(@"(?i)rev");
            return rgx.IsMatch(documentName);
        }

        public static string NummericRevision(string documentName)
        {
            var delimiter = documentName.LastIndexOf('.');
            var currentRevision = int.Parse(documentName.Substring(delimiter + 1));
            var nextRevision = (++currentRevision).ToString();
            return nextRevision.Length == 1 ? $"0{nextRevision}" : nextRevision;
        }



    }
}