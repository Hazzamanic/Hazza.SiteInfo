using System.Web.Mvc;
using Hazza.SiteInfo.ViewModels;
using Orchard;
using Orchard.Environment.Configuration;
using Orchard.Localization;
using Orchard.Security;

namespace Hazza.SiteInfo.Controllers {
    public class AdminController : Controller {
        private readonly ShellSettings _shellSettings;
        private readonly IOrchardServices _services;

        public AdminController(ShellSettings shellSettings, IOrchardServices services) {
            _shellSettings = shellSettings;
            _services = services;

            T = NullLocalizer.Instance;
        }

        public Localizer T { get; set; }

        public ActionResult Index() {
            if (!_services.Authorizer.Authorize(StandardPermissions.SiteOwner, T("Not authorized to manage settings")))
                return new HttpUnauthorizedResult();

            var vm = new SiteInfoViewModel {
                Name = _shellSettings.Name,
                DatabasePrefix = _shellSettings.DataTablePrefix
            };

            return View(vm);
        }
    }
}