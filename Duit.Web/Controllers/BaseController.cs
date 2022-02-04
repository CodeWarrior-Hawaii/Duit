using Duit.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Duit.Web.Controllers
{
    public class BaseController : Controller
    {
        internal DuitContext Context;
        public BaseController(DuitContext context)
        {
            Context = (DuitContext)context;
        }
    }
}
