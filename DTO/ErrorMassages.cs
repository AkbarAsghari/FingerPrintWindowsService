using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public static class ErrorMassages
    {

        public static string DefaultError
        {
            get
            {
                return "عملیات با خطا مواجه شد.\n مجددا تلاش کنید";
            }
        }

        public static string DefaultSaveError
        {
            get
            {
                return "ذخیره سازی اطلاعات با خطا مواجه شد.";
            }
        }

        public static string ModelIsNotValid
        {
            get
            {
                return "اطلاعات وارد شده صحیح نمی باشد.";
            }
        }




        public static string FK_Error
        {
            get
            {
                return "این رکورد دارای اطلاعات وابسته است، اطلاعات وابسته را بررسی کنید.";
            }
        }

        public static string UniqeEntity
        {
            get
            {
                return "اطلاعات ورودی تکراری است. اطلاعات فیلد های یکتا را بررسی نمایید.";
            }
        }

        public static string MustChangePassword
        {
            get
            {
                return "رمز عبور شما از امنیت کافی برخوردار نمی باشد. رمز عبور خود را عوض کنید";
            }
        }

        public static string InValidConfirmPassword
        {
            get
            {
                return "تکرار رمز عبور را اشتباه وارد کرده اید";
            }
        }

        public static string InValidUsername
        {
            get
            {
                return "نام کاربری وارد شده صحیح نمی باشد. نام کاربری حتما باید لاتین باشد";
            }
        }

        public static string InValidName
        {
            get
            {
                return "نام وارد شده صحیح نمی باشد.";
            }
        }

        public static string InValidPhoneNumber
        {
            get
            {
                return "شماره تلفن وارد شده صحیح نمی باشد.";
            }
        }

        public static string InValidNationalCode
        {
            get
            {
                return "کد ملی وارد شده صحیح نمی باشد.";
            }
        }

        public static string NoPictureUploded
        {
            get
            {
                return "تصویری برای خبر انتخاب کنید";
            }
        }

        public static string InValidSymbol
        {
            get
            {
                return "نماد وارد شده صحیح نمی باشد.";
            }
        }

        public static string InValidLatinName
        {
            get
            {
                return "نام لاتین وارد شده صحیح نمی باشد.";
            }
        }

        public static string InValidPersianDate
        {
            get
            {
                return "تاریخ وارده شده صحیح نمی باشد";
            }
        }

        public static string InValidAddress
        {
            get
            {
                return "آدرس وارد شده صحیح نمی باشد";
            }
        }

        public static string InValidFax
        {
            get
            {
                return "شماره فکس وارد شده صحیح نمی باشد";
            }
        }

        public static string InValidCommericalCardNo
        {
            get
            {
                return "Commerical Card No وارد شده صحیح نمی باشد";
            }
        }

        public static string Unauthorized
        {
            get
            {
                return "نام کاربری یا رمز عبور اشتباه است.";
            }
        }

        public static string IncorectCurentLastPassword
        {
            get
            {
                return "رمزعبور اشتباه است";
            }
        }

        public static string UserMustHaveOneRole
        {
            get
            {
                return "کابر می بایست حداقل یک نقش داشته باشد";
            }
        }

        public static string InValidFamily
        {
            get
            {
                return "نام خانوادگی صحیح نمی باشد";
            }
        }

        public static string AccessDenied
        {
            get
            {
                return "شما به این صفحه دسترسی ندارید";
            }
        }

    }
}
