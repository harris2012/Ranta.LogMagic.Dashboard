using Ranta.LogMagic.Display.Convertors;
using Ranta.LogMagic.Display.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ranta.LogMagic.Display.Controllers
{
    public class LogController : Controller
    {
        LogBusiness logBusiness;

        #region 构造函数
        public LogController()
            : this(new LogBusiness())
        {
        }

        public LogController(LogBusiness logBusiness)
        {
            this.logBusiness = logBusiness;
        }
        #endregion

        public ActionResult Page(int page)
        {
            var criteria = new Common.QueryCriteria();
            criteria.PageIndex = page;
            criteria.PageSize = 15;

            var model = logBusiness.GetLogList(criteria);

            var viewModel = LogHeaderConvertor.ToViewModel(model);

            return View(viewModel);
        }

        public ActionResult Detail(string name)
        {
            Guid guid = Guid.Empty;

            if (Guid.TryParse(name, out guid))
            {
                var model = logBusiness.GetLogEventByGuid(guid);
                if (model != null)
                {
                    var viewModel = LogEventConvertor.ToViewModel(model);

                    return View(viewModel);
                }
                else
                {
                    return Redirect("/");
                }
            }
            else
            {
                return Redirect("/");
            }
        }
    }
}