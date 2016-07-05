using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Ranta.Common;
using Ranta.LogMagic.Display.Dal.Entity;
using System.Data;

namespace Ranta.LogMagic.Display.Dal
{
    public class LogHeaderDal
    {
        public PagingModel<LogHeader> GetLogList(QueryCriteria criteria, SqlConnection sqlConn)
        {
            var result = new PagingModel<LogHeader>();
            result.PageIndex = criteria.PageIndex;
            result.PageSize = criteria.PageSize;

            var sqlCmd = new SqlCommand("[Log].[GetLogList]", sqlConn);
            sqlCmd.CommandType = CommandType.StoredProcedure;

            sqlCmd.Parameters.AddWithValue(@"PageIndex", criteria.PageIndex);
            sqlCmd.Parameters.AddWithValue(@"PageSize", criteria.PageSize);

            var reader = sqlCmd.ExecuteReader();
            if (reader.Read())
            {
                result.TotalCount = Convert.ToInt32(reader["TotalCount"]);
            }
            if (reader.NextResult())
            {
                result.Items = new List<LogHeader>();
                while (reader.Read())
                {
                    var header = new LogHeader();

                    header.Id = Convert.ToInt32(reader["Id"]);
                    header.Guid = Guid.Parse(reader["Guid"].ToString());
                    header.Title = reader["Title"].ToString();
                    header.CreateTime = Convert.ToDateTime(reader["CreateTime"]);

                    result.Items.Add(header);
                }
            }

            return result;
        }

        public LogEvent GetLogByGuid(Guid guid, SqlConnection sqlConn)
        {
            LogEvent entity = null;

            var sqlCmd = new SqlCommand("[Log].[GetLogByGuid]", sqlConn);
            sqlCmd.CommandType = CommandType.StoredProcedure;

            sqlCmd.Parameters.AddWithValue(@"Guid", guid);

            var reader = sqlCmd.ExecuteReader();
            if (reader.Read())
            {
                entity = new LogEvent();

                entity.Id = Convert.ToInt32(reader["Id"]);
                entity.Guid = Guid.Parse(reader["Guid"].ToString());
                entity.AppId = Convert.ToInt32(reader["AppId"]);
                entity.LogTypeId = Convert.ToInt32(reader["LogTypeId"]);
                entity.Source = reader["Source"].ToString();
                entity.CreateTime = Convert.ToDateTime(reader["CreateTime"]);
                entity.Title = reader["Title"].ToString();
                entity.Content = reader["Content"].ToString();
            }

            return entity;
        }
    }
}
