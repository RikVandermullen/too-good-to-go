namespace DomainServices.Services
{
    public class FormatterService
    {
        public FormatterService()
        {
        }

        public string ToString(string Enum)
        {
            return Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(Enum.ToLower());
        }

        public DateOnly FormatDateTime(DateTime dateTime)
        {
            return DateOnly.FromDateTime(dateTime);
        }
    }
}
