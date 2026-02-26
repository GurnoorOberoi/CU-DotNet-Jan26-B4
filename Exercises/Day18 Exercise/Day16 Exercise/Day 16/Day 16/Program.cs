namespace Day_16
{
    static class ApplicationConfig
    {
        public static string ApplicationName { get; set; }
        public static string Environment { get; set; }
        public static int AccessCount { get; set; }
        public static bool IsInitialized { get; set; }

        static ApplicationConfig()
        {
            ApplicationName = "MyApp";
            Environment = "Development";
            AccessCount = 0;
            IsInitialized = false;
            Console.WriteLine("Application Configuration Tracker Using Static Members");
            Console.WriteLine();
            Console.WriteLine("Static constructor executed");
        }
        public static void Initialize(string appName, string environment)
        {
            ApplicationName = appName;
            Environment = environment;
            IsInitialized = true;
            AccessCount++;
        }
        public static string GetConfigurationSummary()
        {
            AccessCount++;
            return $"Application Name = {ApplicationName}\n" +
                $"Environment = {Environment}\nAccess Count = {AccessCount}\nInitialization Status = {IsInitialized}";
        }
        public static void ResetConfiguration()
        {
            ApplicationName = "MyApp";
            Environment = "Development";
            IsInitialized = false;
            AccessCount++;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ApplicationConfig.ApplicationName);
            Console.WriteLine();
            ApplicationConfig.Initialize("Portal", "Testing");
            
            Console.WriteLine(ApplicationConfig.GetConfigurationSummary());
            Console.WriteLine();
            ApplicationConfig.ResetConfiguration();
            Console.WriteLine(ApplicationConfig.GetConfigurationSummary());
        }
    }
}
