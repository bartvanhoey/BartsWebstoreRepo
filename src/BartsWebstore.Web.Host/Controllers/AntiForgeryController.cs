using Microsoft.AspNetCore.Antiforgery;
using BartsWebstore.Controllers;

namespace BartsWebstore.Web.Host.Controllers
{
    public class AntiForgeryController : BartsWebstoreControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
