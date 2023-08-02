namespace CvTemplateMatching.Consts
{
    public class EnvironmentConsts
    {
        private static string _workingDirectory = Environment.CurrentDirectory;
        public static string ProjectPath => Directory.GetParent(_workingDirectory).Parent.Parent.FullName;
    }
}
