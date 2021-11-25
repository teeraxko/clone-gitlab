using System;

namespace Presentation.CommonGUI
{
	/// <summary>
	/// Summary description for Common.
	/// </summary>
	internal class Common
	{
		public class FarPointUtility
		{
			public static void SearchDialog(System.Windows.Forms.Form  parent, FarPoint.Win.Spread.FpSpread fp, string searchString)
			{
				fp.SearchWithDialog(searchString);
			}

			public static void HilightSelection(object sheet)
			{
				FarPoint.Win.Spread.SheetView mySheet = (FarPoint.Win.Spread.SheetView)sheet;
				int rowIndex= mySheet.ActiveRowIndex;
				int colIndex= mySheet.ActiveColumnIndex;

				mySheet.ClearSelection();
				mySheet.Models.Selection.SetSelection(rowIndex,colIndex,1,1);
			}
		}

	}
}
