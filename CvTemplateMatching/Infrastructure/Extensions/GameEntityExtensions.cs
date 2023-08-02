using CvTemplateMatching.Consts;
using CvTemplateMatching.Entities;

namespace CvTemplateMatching.Infrastructure.Extensions
{
    public static class GameEntityExtensions
    {
        private static string _iconGameDirectoryName => "game_icons";
        private static string _iconGameFullPath => 
            Path.Combine(EnvironmentConsts.ProjectPath, _iconGameDirectoryName);
        public static GameEntity FromCSV(this GameEntity entity, string csvLine)
        {
            string[] values = csvLine.Split(',');
            entity.Id = Convert.ToInt32(values[0]);
            entity.GameName = Convert.ToString(values[1]);
            entity.IconPath= Path.Combine(_iconGameFullPath, Convert.ToString(values[2]));

            return entity;
        }
    }
}
