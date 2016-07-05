using Ranta.Common;
using Ranta.LogMagic.Display.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ranta.LogMagic.Display.Convertors
{
    public static class LogHeaderConvertor
    {
        internal static PagingModel<ViewModel.LogHeader> ToViewModel(PagingModel<LogHeader> model)
        {
            PagingModel<ViewModel.LogHeader> viewModel = null;

            if (model != null)
            {
                viewModel = new PagingModel<ViewModel.LogHeader>();

                viewModel.PageIndex = model.PageIndex;
                viewModel.PageSize = model.PageSize;
                viewModel.TotalCount = model.TotalCount;

                if (model.Items != null && model.Items.Count > 0)
                {
                    viewModel.Items = new List<ViewModel.LogHeader>();
                    foreach (var item in model.Items)
                    {
                        var viewItem = new ViewModel.LogHeader();

                        viewItem.Id = item.Id;
                        viewItem.Guid = item.Guid;
                        viewItem.Title = item.Title;
                        viewItem.CreateTime = item.CreateTime;

                        viewModel.Items.Add(viewItem);
                    }
                }
            }

            return viewModel;
        }

        internal static ViewModel.LogHeader ToViewModel(LogHeader model)
        {
            ViewModel.LogHeader viewModel = null;

            if (model != null)
            {
                viewModel = new ViewModel.LogHeader();

                viewModel.Id = model.Id;
                viewModel.Guid = model.Guid;
                viewModel.Title = model.Title;
                viewModel.CreateTime = model.CreateTime;

            }

            return viewModel;
        }
    }
}