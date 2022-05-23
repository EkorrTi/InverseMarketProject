using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class FormProvider
    {
        public static RegistrationForm registrationForm
        {
            get
            {
                if (_registrationForm == null)
                    _registrationForm = new RegistrationForm();
                return _registrationForm;
            }
        }
        private static RegistrationForm? _registrationForm;

        public static AdvertForm? advertForm { get; set; }
        public static ListForm? listForm { get; set; }
        public static ReplyForm? replyForm { get; set; }
    }
}
