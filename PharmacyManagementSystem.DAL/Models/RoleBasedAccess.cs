using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyManagementSystem.DAL.Models
{
    public static class RoleBasedAccess
    {
        private static readonly Dictionary<string, List<string>> TabAccess = new Dictionary<string, List<string>>
    {
        { "Admin", new List<string> { "supplierTap", "accountTab", "salesTab", "purchaseTab", "customersTab", "reportsTab"  , "addNewProduct", "Stock" } },
        { "Pharmacist", new List<string> { "salesTab", "purchaseTab", "reportsTab" , "Stock" } },
        { "Manager", new List<string> { "salesTab", "purchaseTab" , "supplierTap", "reportsTab" , "Stock" } }
    };

        public static bool CanAccess(string role, string tabName)
        {
            return TabAccess.ContainsKey(role) && TabAccess[role].Contains(tabName);
        }
    }
}
