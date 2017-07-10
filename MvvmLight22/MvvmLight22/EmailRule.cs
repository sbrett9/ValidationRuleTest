namespace MvvmLight22
{
    using System.Globalization;
    using System.Windows.Controls;
    using ViewModel;

    public class EmailRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var email = ViewModelLocator.Instance.Main.Email;
            var repeatEmail = ViewModelLocator.Instance.Main.RepeatEmail;

            if (email != repeatEmail)
            {
                return new ValidationResult(false, "Emails are not identical.");
            }
            else
            {
                return ValidationResult.ValidResult;
            }
        }
    }
}
