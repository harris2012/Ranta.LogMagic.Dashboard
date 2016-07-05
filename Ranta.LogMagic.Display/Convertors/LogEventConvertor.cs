using Ranta.LogMagic.Display.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ranta.LogMagic.Display.Convertors
{
    public static class LogEventConvertor
    {
        public static ViewModel.LogEvent ToViewModel(LogEvent model)
        {
            ViewModel.LogEvent viewModel = null;

            if (model != null)
            {
                viewModel = new ViewModel.LogEvent();

                viewModel.Id = model.Id;
                viewModel.Guid = model.Guid;
                viewModel.AppId = model.AppId;
                viewModel.LogTypeId = model.LogTypeId;
                viewModel.Source = model.Source;
                viewModel.CreateTime = model.CreateTime;
                viewModel.Title = model.Title;
                viewModel.Content = model.Content;

                switch (model.LogTypeId)
                {
                    case 1://Debug
                        viewModel.LogTypeText = "调试";
                        viewModel.LogTypeCss = "panel-info";
                        break;
                    case 2://Info
                        viewModel.LogTypeText = "提示";
                        viewModel.LogTypeCss = "panel-primary";
                        break;
                    case 3://Warn
                        viewModel.LogTypeText = "警告";
                        viewModel.LogTypeCss = "panel-success";
                        break;
                    case 4://Error
                        viewModel.LogTypeText = "异常";
                        viewModel.LogTypeCss = "panel-warning";
                        break;
                    case 5://Fault
                        viewModel.LogTypeText = "严重";
                        viewModel.LogTypeCss = "panel-danger";
                        break;
                    default:
                        break;
                }
            }

            return viewModel;
        }
    }
}