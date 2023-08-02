namespace CvTemplateMatching.Infrastructure.Helpers
{
    public class FileExtensionHelper
    {
        public static string ConcatFilterExtension(params string[] extensions)
        {
            return string.Join("|", extensions);
        }
    }
}
