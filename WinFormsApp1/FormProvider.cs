using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class FormProvider
    {
        public static RegistrationForm? registrationForm { get; set; }
        public static LoginForm? loginForm { get; set; }
        public static AddAdvertForm? addAdvertForm { get; set; }
        public static AdvertForm? advertForm { get; set; }
        public static ListForm? listForm { get; set; }
        public static ReplyForm? replyForm { get; set; }
    }
}
