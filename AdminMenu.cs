using Orchard;
using Orchard.Security;
using Orchard.UI.Navigation;

namespace Hazza.SiteInfo {
    public class AdminMenu : Component, INavigationProvider {
        public string MenuName { get { return "admin"; } }


        public void GetNavigation(NavigationBuilder builder) {
            builder//.AddImageSet("imagename")
              .Add(T("Tenant Information"), "11",
                  menu => menu.Action("Index", "Admin", new { area = "TenantInfo" }).Permission(StandardPermissions.SiteOwner)
                    //.Add(T("Site Information 2"), "1", e => e.Action("Index", "AdminController", new { area = "Hazza.SiteInfo" })//.Permission(Permissions.MyPermission))
              );


        }
    }
}