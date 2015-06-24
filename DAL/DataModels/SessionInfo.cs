using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Enums;

namespace MyStoryDAL.DataModels
{
    public class SessionInfo
    {
        public SessionInfo(EnumLanguage language = EnumLanguage.English, EnumTimeZone timeZone= EnumTimeZone.UTC4)
        {
            LangId = language;
            TimeZone = timeZone;
        }
        public SessionInfo()
        {
            LangId = EnumLanguage.English;
            TimeZone = EnumTimeZone.UTC4;
        }
        public EnumLanguage LangId { get; set; }
        public EnumTimeZone TimeZone { get; set; }
    }
}
