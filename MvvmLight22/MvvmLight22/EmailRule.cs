namespace MvvmLight22
{
    using System.Globalization;
    using System.Windows.Controls;
    using ViewModel;

    public class EmailRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            return ValidationResult.ValidResult;
        }
    }
}
