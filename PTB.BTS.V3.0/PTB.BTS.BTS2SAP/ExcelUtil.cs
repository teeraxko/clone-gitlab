using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace PTB.BTS.BTS2SAP
{
    public static class ExcelUtil
    {
        /// <summary>
        ///     Get Windows Thread Process Id
        /// </summary>
        /// <param name="hWnd">Window Handle (excel app)</param>
        /// <param name="lpdwProcessId">output variable</param>
        /// <returns>Windows Thread Process Id</returns>
        [DllImport("user32.dll")]
        public static extern int GetWindowThreadProcessId(int hWnd, out int lpdwProcessId);

        public static void KillExcelProcess(Excel.Application excelApp)
        {
            int pId;
            GetWindowThreadProcessId(excelApp.Hwnd, out pId);

            Process p = Process.GetProcessById(pId);

            p.Kill();
        }
    }
}
