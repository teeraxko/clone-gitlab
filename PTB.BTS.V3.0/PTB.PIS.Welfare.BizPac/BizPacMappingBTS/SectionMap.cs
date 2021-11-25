using System;
using System.Collections.Generic;
using System.Text;
using PTB.PIS.Welfare.BizPac.BizPacEntities;
using PTB.PIS.Welfare.BizPac.DataAccess;


namespace PTB.PIS.Welfare.BizPac.BizPacMappingBTS {
    public class SectionMapManager {
        private static List<BizSectionMap> SectionMapTable = null;
        //public static BizSectionMap GetBizSectionMap(string deptCode, string secCode) {
        //    if (SectionMapTable == null) SectionMapTable = BizPacMappingCodeDB.FillAll();
        //    BizSectionMap result = null;
        //    foreach (BizSectionMap item in SectionMapTable) {
        //        if (item.BTSDeptCode.Trim() == deptCode.Trim() && item.BTSSecCode.Trim() == secCode.Trim()) {
        //            result = item;
        //            break;
        //        }
        //    }
        //}

        public static string GetBizSectionCode(string deptCode, string secCode) {
            if (SectionMapTable == null) SectionMapTable = BizPacMappingCodeDB.FillAll(Common.CurrentCompany.CompanyCode);
            string result = string.Empty;
            foreach (BizSectionMap item in SectionMapTable) {
                if (item.BTSDeptCode.Trim() == deptCode.Trim() && item.BTSSecCode.Trim() == secCode.Trim()) {
                    result = item.BizSecCode;
                    break;
                }
            }
            return result;
        }

        
    }
}
