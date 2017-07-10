namespace MvvmLight22.ViewModel
{
    #region Using Declarations

    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;

    #endregion

    public class MainViewModel : ValidatableModel
    {
        private string _userName = "foo";
        private string _email = "bleah@bleah.bleah";
        private string _repeatEmail = "bleah@bleah.blea";

        public RelayCommand OnLoad { get; set; }

        [Required]
        [StringLength(20)]
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; RaisePropertyChanged("UserName"); }
        }

        [Required]
        [EmailAddress]
        [StringLength(60)]
        public string Email
        {
            get { return _email; }
            set { _email = value; RaisePropertyChanged("Email"); }
        }

        [Required]
        [EmailAddress]
        [StringLength(60)]
        [CustomValidation(typeof(MainViewModel), "SameEmailValidate")]
        public string RepeatEmail
        {
            get { return _repeatEmail; }
            set { _repeatEmail = value; RaisePropertyChanged("RepeatEmail"); }
        }

        public string Explanation
        {
            get
            {
                string x =
                    "INotifyDataErrorInfo and Validation Rules are two approaches for validation in WPF.\n" +
                    "The validation logic involves checking to see if two email addresses in two seperate text boxes are identical.\n" +
                    "The expected behavior for both techniques is that on load, if the data is not identical, validation error templates should surround the controls in error.\n" +
                    "The observed behavior is that validation using INotifyDataErrorInfo does not show the validation error template on data load, and that Validation Rule usage does.\n" +
                    "The reason for this is due to the fact that Validation Rules can be made to execute their validation on binding expression read (as opposed to write, or setting of the data).\n" +
                    "There does not seem to be a way to accomplish the same feat when using the INotifyDataErrorInfo approach.\n" +
                    "\n" +
                    "The Validation using INotifyDataErrorInfo requires the user to perform an update to the text field in order for it to re-evaluate its validation rule.\n" +
                    "The Validation using ValidationRules does not require this.";

                return x;
            }
        }

        public MainViewModel()
        {
            OnLoad = new RelayCommand(ExecuteOnLoad);
        }

        private void ExecuteOnLoad()
        {
            //Manually signal properties changed in order to force INotifyDataErrorInfo validation.
            //Bear in mind, INotifyDataErrorInfo requires the user perform some operation like this in order to 
            //establish validation errors on the ui controls, whereas ValidationRules do it as a matter of course 
            //((ValidatableModel)this).RaisePropertyChanged(nameof(Email));
            //((ValidatableModel)this).RaisePropertyChanged(nameof(RepeatEmail));
        }

        public static ValidationResult SameEmailValidate(object obj, ValidationContext context)
        {
            var user = (MainViewModel)context.ObjectInstance;
            if (user.Email != user.RepeatEmail)
            {
                return new ValidationResult("The emails are not equal",
                    new List<string> { "Email", "RepeatEmail" });
            }
            return ValidationResult.Success;
        }

    }
}