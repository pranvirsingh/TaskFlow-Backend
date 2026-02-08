namespace TaskFlowBackend.Common
{
    public static class DateTimeZone
    {
        public static TimeZoneInfo India()
        {
            return TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        }
    }
}
