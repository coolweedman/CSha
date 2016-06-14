using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;



namespace DatabaseProj.Code.Debug {
    class CDebugPrint {

        /// <summary>
        /// 调试信息打印 方法详细信息
        /// </summary>
        /// <param name="hStackTrace"></param>
        public static void dbgMehtorMsgPrint (StackTrace hStackTrace)
        {
            StackFrame hStackFrame = hStackTrace.GetFrame(0);

            Trace.WriteLine( "File: " + hStackFrame.GetFileName() );
            Trace.WriteLine( "Line: " + hStackFrame.GetFileLineNumber() );
            Trace.WriteLine( "Methor: " + hStackFrame.GetMethod() );
        }

        /// <summary>
        /// 调试信息打印 异常信息
        /// </summary>
        /// <param name="hException"></param>
        public static void dbgExpectionMsgPrint (Exception hException)
        {
            Trace.WriteLine( hException.ToString() );
        }

        /// <summary>
        /// 调试信息打印 用户信息
        /// </summary>
        /// <param name="strMsg"></param>
        public static void dbgUserMsgPrint (string strMsg)
        {
            Trace.WriteLine( strMsg );
        }
    }
}
