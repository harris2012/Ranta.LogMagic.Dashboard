using Ranta.Common;
using Ranta.LogMagic.Display.Core.Convertors;
using Ranta.LogMagic.Display.Core.Model;
using Ranta.LogMagic.Display.Dal;
using Ranta.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranta.LogMagic.Display.Core
{
    public class LogBusiness
    {
        private LogHeaderDal logHeaderDal;

        #region 构造函数
        public LogBusiness()
            : this(new LogHeaderDal())
        {
        }

        public LogBusiness(LogHeaderDal jobHeaderDal)
        {
            this.logHeaderDal = jobHeaderDal;
        }
        #endregion

        public PagingModel<LogHeader> GetLogList(QueryCriteria criteria)
        {
            PagingModel<LogHeader> pagingModel = null;

            using (var sqlConn = SqlConnectionProvider.GetConnection(AppConst.RantaMaster))
            {
                var entity = logHeaderDal.GetLogList(criteria, sqlConn);

                pagingModel = LogHeaderConvertor.ToModel(entity);
            }

            return pagingModel;
        }

        public LogEvent GetLogEventByGuid(Guid guid)
        {
            LogEvent logEvent = null;

            using (var sqlConn = SqlConnectionProvider.GetConnection(AppConst.RantaMaster))
            {
                var entity = logHeaderDal.GetLogByGuid(guid, sqlConn);

                logEvent = LogEventConvertor.ToModel(entity);
            }

            return logEvent;
        }
    }
}
