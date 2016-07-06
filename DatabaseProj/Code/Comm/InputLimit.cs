using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseProj.Code.Comm {
    public class CInputLimit {
        public static void textBoxNumLimitProc (ref object sender, ref System.Windows.Forms.KeyPressEventArgs e)
        {
            if ( '\b' == e.KeyChar ) {
                return;
            }

            System.Windows.Forms.TextBox textBox = (System.Windows.Forms.TextBox)sender;
            string str = textBox.Text + e.KeyChar;

            if ( !CRegExpr.regExNum.IsMatch( str ) ) {
                e.KeyChar = (char)0;
            }
        }

        public static void textBoxIdentLimitProc (ref object sender, ref System.Windows.Forms.KeyPressEventArgs e)
        {
            if ( '\b' == e.KeyChar ) {
                return;
            }

            System.Windows.Forms.TextBox textBox = (System.Windows.Forms.TextBox)sender;
            if ( !CRegExpr.regExIdentCHar.IsMatch( e.KeyChar.ToString() ) ) {
                e.KeyChar = (char)0;
            }
        }
    }
}
