using Ranta.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranta.LogMagic.Display.Core.Convertors
{
    internal static class LogHeaderConvertor
    {
        internal static PagingModel<Model.LogHeader> ToModel(PagingModel<Dal.Entity.LogHeader> entity)
        {
            PagingModel<Model.LogHeader> model = null;

            if (entity != null)
            {
                model = new PagingModel<Model.LogHeader>();

                model.PageIndex = entity.PageIndex;
                model.PageSize = entity.PageSize;
                model.TotalCount = entity.TotalCount;

                if (entity.Items != null && entity.Items.Count > 0)
                {
                    model.Items = new List<Model.LogHeader>();
                    foreach (var entityItem in entity.Items)
                    {
                        var modelItem = new Model.LogHeader();

                        modelItem.Id = entityItem.Id;
                        modelItem.Guid = entityItem.Guid;
                        modelItem.Title = entityItem.Title;
                        modelItem.CreateTime = entityItem.CreateTime;

                        model.Items.Add(modelItem);
                    }
                }
            }

            return model;
        }
    }
}
