using System.Configuration;

namespace DrawBoard.DrawSettings
{
    public class DrawSettingsHelper
    {
        public static string GetPath()
        {
            //config의 경로 얻어오기
            var path = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal).FilePath;

            return path;
        }
    }
}
