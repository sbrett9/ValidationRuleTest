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


        public MainViewModel()
        {
            OnLoad = new RelayCommand(ExecuteOnLoad);
        }

        private void ExecuteOnLoad()
        {
            RaisePropertyChanged(()=>Email);
            RaisePropertyChanged(()=>RepeatEmail);
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