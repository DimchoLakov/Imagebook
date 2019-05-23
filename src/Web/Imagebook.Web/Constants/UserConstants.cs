namespace Imagebook.Web.Constants
{
    public class UserConstants
    {
        public const string FirstNameLengthErrorMessage = "The {0} must be at least {2} and at max {1} characters long.";

        public const string LastNameLengthErrorMessage = "The {0} must be at least {2} and at max {1} characters long.";

        public const int FirstNameMaxLength = 64;

        public const int FirstNameMinLength = 2;

        public const int LastNameMaxLength = 64;

        public const int LastNameMinLength = 2;

        public const int UserNameMaxLength = 35;
    }
}
