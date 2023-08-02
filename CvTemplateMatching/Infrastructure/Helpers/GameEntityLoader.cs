using CvTemplateMatching.Consts;
using CvTemplateMatching.Entities;
using CvTemplateMatching.Infrastructure.Extensions;

namespace CvTemplateMatching.Infrastructure.Helpers
{
    public class GameEntityLoader
    {
        private static string _gameCsvDirectoryPath => "GameCollection";
        private static string _gameCsvFileName => "games.csv";
        private static string GamePath =>
            Path.Combine(EnvironmentConsts.ProjectPath, _gameCsvDirectoryPath, _gameCsvFileName);

        public static ICollection<GameEntity> LoadGame()
        {
            List<GameEntity> games = File.ReadAllLines(GamePath)
                .Select(x =>
                {
                    var game = new GameEntity()
                                    .FromCSV(x);
                    return game;
                })
                .ToList();

            return games;
        }
    }
}
