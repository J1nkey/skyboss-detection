namespace CvTemplateMatching.Infrastructure.Helpers
{
    public static class FileResolver
    {
        public static bool IsFileExist(string path)
        {
            if (File.Exists(path))
            {
                return true;
            }

            return false;
        }
    }
}
