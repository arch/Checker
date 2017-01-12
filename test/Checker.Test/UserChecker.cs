namespace Checking.FluentApi.Test
{
    public class UserChecker : CheckerBase<User>
    {
        public UserChecker()
        {
            RuleFor(u => u.Username).NotEmpty();
            RuleFor(u => u.Password).NotEmpty();
            RuleFor(u => u.Age).LessThan(100);
        }
    }
}
