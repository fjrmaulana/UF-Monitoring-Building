using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace I_HUB.Maintenance
{
    public class MenuTreeview
    {
        public MenuTreeview()
        {

        }

        public string Get_Access_Menu(string RoleID)
        {
            string menuStamp_ = AddMenuStamp(RoleID);
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<ul class=\"nav nav-pills nav-sidebar flex-column nav-child-indent\" data-widget=\"treeview\" role=\"menu\" data-accordion=\"false\">");
            sb.Append(menuStamp_);
            sb.Append("</ul>");
            return sb.ToString();
        }

        private static string AddMenuStamp(string RoleID)
        {
            // Di Dapat awal
            List<I_HUB.Maintenance.MenuMaster> menuMasters = I_HUB.Maintenance.MenuMaster.GetMenuMasterForDataSource();

            // Di filter sesuai Role
            var allCorrect = menuMasters.Where(a => a.MENU_ACTIVE == true && a.MENU_ROLE.ToLower().Contains(RoleID.ToLower()) && a.MENU_LEVEL.ToLower().Contains("master")).ToList();

            System.Text.StringBuilder MenuBuilder = new System.Text.StringBuilder();

            foreach (var x in allCorrect)
            {
                // MasterManu Start
                MenuBuilder.AppendLine("<li class='nav-item'>");
                MenuBuilder.AppendLine("    <a href='#' class='nav-link'>");
                MenuBuilder.AppendLine("        <i class='nav-icon " + x.MENU_IMG + " mr-1'></i>");
                MenuBuilder.AppendLine("         <p class='font-weight-bold'>");
                MenuBuilder.AppendLine(x.MENU_NAME);
                MenuBuilder.AppendLine("           <i class='fas fa-angle-left right'></i>");
                MenuBuilder.AppendLine("          <span class='badge badge-info right'>" + I_HUB.Maintenance.MenuMaster.Chil_Count(x.MENU_CODE) + "</span>");
                MenuBuilder.AppendLine("       </p>");
                MenuBuilder.AppendLine("    </a>");

                MenuBuilder.AppendLine(GetMenuChildFromMenuMaster(x.MENU_CODE, x.MENU_ROLE));

                MenuBuilder.AppendLine("</li>");
            }
            return MenuBuilder.ToString();
        }

        private static string GetMenuChildFromMenuMaster(string menuCode, string menuRole)
        {
            System.Text.StringBuilder b = new System.Text.StringBuilder();

            List<I_HUB.Maintenance.MenuMaster> menuMasters = I_HUB.Maintenance.MenuMaster.GetMenuMasterForDataSource();

            // Di filter sesuai Role
            var MenuChild = menuMasters.Where(a => a.MENU_LEVEL.ToLower().Contains("child") && a.MENU_MLM.ToLower().Contains(menuCode.ToLower())).ToList();
            foreach (var x in MenuChild)
            {
                b.AppendLine(" <ul class='nav nav-treeview'>");
                b.AppendLine("     <li class='nav-item'>");
                b.AppendLine("         <a href='" + "/" + x.MENU_AREA_NAME + "/" + x.MENU_CONTROLLERNAME + "/" + x.MENU_ACTION_NAME + "' class='nav-link'>");
                b.AppendLine("            <i class='nav-icon " + "fas fa-circle" + "' style='font-size: 10px;'></i>");
                b.AppendLine("           <p class='font-weight-bold'>" + x.MENU_NAME + "</p>");
                b.AppendLine("        </a>");
                b.AppendLine("    </li>");
                b.AppendLine(" </ul>");
            }
            return b.ToString();
        }

    }
}
