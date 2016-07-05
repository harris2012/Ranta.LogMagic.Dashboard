using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranta.LogMagic.Display.Core.Convertors
{
    internal static class LogEventConvertor
    {
        internal static Model.LogEvent ToModel(Dal.Entity.LogEvent entity)
        {
            Model.LogEvent model = null;

            if (entity != null)
            {
                model = new Model.LogEvent();

                model.Id = entity.Id;
                model.Guid = entity.Guid;
                model.AppId = entity.AppId;
                model.LogTypeId = entity.LogTypeId;
                model.Source = entity.Source;
                model.CreateTime = entity.CreateTime;
                model.Title = entity.Title;
                model.Content = entity.Content;
            }

            return model;
        }
    }
}
