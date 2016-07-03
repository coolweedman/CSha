using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;


namespace DatabaseProj.Code.Comm {
    public class CRegExpr {

        public static Regex regExNum = new Regex( @"^[0-9]*$" );
        public static Regex regExIdent = new Regex( @"(^\d{18}$)|(^\d{15}$)" );
        public static Regex regExPhone = new Regex( @"^[1]+[3,5]+\d{9}" );
    }
}
