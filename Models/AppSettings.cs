using System.Collections.Generic;

namespace buildxact_supplies.Models
{
    public class AppSettings
    {  
        public double AudUsdExchangeRate { get; set; }
        public List<SupplierSetting> SupplierSettingModel { get; set; }
    }

    public class SupplierSetting
    {  
        public string File { get; set; }      
        public bool Enable { get; set; }
        public string Type { get; set; }

        public int Cents { get; set; }
    }
}
