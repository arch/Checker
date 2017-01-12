namespace Checking.FluentApi
{
    public class CheckFailure
    {
        public string PropertyName { get; set; }

        public string ErrorMessage { get; set; }

        public override string ToString()
        {
            return ErrorMessage;
        }
    }
}
