﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DatabaseProj.Code.Main;

namespace DatabaseProj {
    static class Program {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main ()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault( false );
            Application.Run( new MainWindow() );
        //    Application.Run( new Form1() );
        }
    }
}
