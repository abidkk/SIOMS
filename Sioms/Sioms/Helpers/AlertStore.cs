namespace SIOMS.Helpers
{
    public static class AlertStore
    {
        private static List<string> _alerts = new();

        public static void Add(string message)
        {
            _alerts.Add(message);
        }

        public static List<string> GetAll()
        {
            var copy = _alerts.ToList();
            _alerts.Clear(); // show only once
            return copy;
        }
    }
}
