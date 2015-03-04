using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Favela
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*if (!Reservas.IsUserInRole("Admin")) PRECISO REVER ESTA OPÇÃO
            {
                MenuItemCollection menuItems = NavigationMenu.Items;
                MenuItem adminItem = new MenuItem();
                foreach (MenuItem menuItem in menuItems)
                {
                    if (menuItem.Text == "Reservas")
                        adminItem = menuItem;
                }
                menuItems.Remove(adminItem);
            }*/

        }
    }
}
