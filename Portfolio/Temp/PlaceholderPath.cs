namespace Portfolio.Temp
{
    public static class PlaceholderPath
    {
        private const string BASE_PATH = "Temp/post_placeholder_";
        private const string PNG       = ".png";

        private static int Counter = 0;
        private static string FullPath;

        public static string AssetPath()
        {
            FullPath = BASE_PATH + Counter + PNG;

            if (0 <= Counter && 7 > Counter)
            {
                Counter++;
            }
            else if (7 == Counter)
            {
                Counter = 0;
            }

            return FullPath;
        }
    }
}