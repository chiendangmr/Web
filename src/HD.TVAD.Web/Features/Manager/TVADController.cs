using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HD.TVAD.Web.Models;
using System.ComponentModel.DataAnnotations;
using HD.TVAD.Web.Infrastructure;

namespace HD.TVAD.Web.Features.Manager
{
    [SetTheme]
    public class TVADController : Controller
    {
        public TVADController()
        {

        }

        public IActionResult JsonResponse(int result, ActionType actionType)
        {
            var jsonResponse = new JsonResponse();
            if (result > 0)
            {
                jsonResponse.result = StatusType.OK.GetDisplayName();

                switch (actionType)
                {
                    case ActionType.None:
                        break;
                    case ActionType.Create:
                        jsonResponse.message = ActionType.Create.GetDisplayName();
                        break;
                    case ActionType.Edit:
                        jsonResponse.message = ActionType.Edit.GetDisplayName();
                        break;
                    case ActionType.Delete:
                        jsonResponse.message = ActionType.Delete.GetDisplayName();
                        break;

                    default:
                        jsonResponse.message = StatusType.OK.GetDisplayName();
                        break;
                }

            }
            else
                if (result == 0)
            {
                jsonResponse.result = StatusType.ERROR.GetDisplayName();
                jsonResponse.message = StatusType.None.GetDisplayName();
            }
            else
            {
                jsonResponse.result = StatusType.ERROR.GetDisplayName();
                jsonResponse.message = StatusType.ERROR.GetDisplayName();

            }


            return Json(jsonResponse);
		}
		public IActionResult JsonResponse(int result, ActionType actionType, object data)
		{
			var jsonResponse = new JsonResponse();
			if (result > 0)
			{
				jsonResponse.result = StatusType.OK.GetDisplayName();

				switch (actionType)
				{
					case ActionType.None:
						break;
					case ActionType.Create:
						jsonResponse.message = ActionType.Create.GetDisplayName();
						break;
					case ActionType.Edit:
						jsonResponse.message = ActionType.Edit.GetDisplayName();
						break;
					case ActionType.Delete:
						jsonResponse.message = ActionType.Delete.GetDisplayName();
						break;

					default:
						jsonResponse.message = StatusType.OK.GetDisplayName();
						break;
				}

			}
			else
				if (result == 0)
			{
				jsonResponse.result = StatusType.ERROR.GetDisplayName();
				jsonResponse.message = StatusType.None.GetDisplayName();
			}
			else
			{
				jsonResponse.result = StatusType.ERROR.GetDisplayName();
				jsonResponse.message = StatusType.ERROR.GetDisplayName();

			}
			jsonResponse.data = data;

			return Json(jsonResponse);
		}
		public IActionResult JsonResponse(int result, ActionType actionType, Guid id)
		{
			var jsonResponse = new JsonResponse();
			if (result > 0)
			{
				jsonResponse.result = StatusType.OK.GetDisplayName();

				switch (actionType)
				{
					case ActionType.None:
						break;
					case ActionType.Create:
						jsonResponse.message = ActionType.Create.GetDisplayName();
						break;
					case ActionType.Edit:
						jsonResponse.message = ActionType.Edit.GetDisplayName();
						break;
					case ActionType.Delete:
						jsonResponse.message = ActionType.Delete.GetDisplayName();
						break;

					default:
						jsonResponse.message = StatusType.OK.GetDisplayName();
						break;
				}

			}
			else
				if (result == 0)
			{
				jsonResponse.result = StatusType.ERROR.GetDisplayName();
				jsonResponse.message = StatusType.None.GetDisplayName();
			}
			else
			{
				jsonResponse.result = StatusType.ERROR.GetDisplayName();
				jsonResponse.message = StatusType.ERROR.GetDisplayName();

			}
			jsonResponse.id = id;

			return Json(jsonResponse);
		}
		public IActionResult JsonResponse(int result, string message, Guid id)
		{
			var jsonResponse = new JsonResponse();
			if (result > 0)
			{
				jsonResponse.result = StatusType.OK.GetDisplayName();
				jsonResponse.message = message;

			}
			else
				if (result == 0)
			{
				jsonResponse.result = StatusType.ERROR.GetDisplayName();
				jsonResponse.message = StatusType.None.GetDisplayName();
			}
			else
			{
				jsonResponse.result = StatusType.ERROR.GetDisplayName();
				jsonResponse.message = StatusType.ERROR.GetDisplayName();

			}
			jsonResponse.id = id;

			return Json(jsonResponse);
		}
		public IActionResult JsonResponse(int result, string message)
		{
			var jsonResponse = new JsonResponse();
			if (result > 0)
			{
				jsonResponse.result = StatusType.OK.GetDisplayName();
				jsonResponse.message = message;

			}
			else
				if (result == 0)
			{
				jsonResponse.result = StatusType.ERROR.GetDisplayName();
				jsonResponse.message = StatusType.None.GetDisplayName();
			}
			else
			{
				jsonResponse.result = StatusType.ERROR.GetDisplayName();
				jsonResponse.message = StatusType.ERROR.GetDisplayName();

			}

			return Json(jsonResponse);
		}
		public IActionResult JsonResponse(StatusType status, string message)
        {
            var jsonResponse = new JsonResponse();

            jsonResponse.result = status.GetDisplayName();
            jsonResponse.message = message;

            return Json(jsonResponse);
        }
        public IActionResult JsonResponse(StatusType status, object _object)
        {
            var jsonResponse = new JsonObjectResponse(status.GetDisplayName(), _object);


            return Json(jsonResponse);
        }
        public enum ActionType
        {
            [Display(Name = "None")]
            None,
            [Display(Name = "Created")]
            Create,
            [Display(Name = "Updated")]
            Edit,
            [Display(Name = "Deleted")]
            Delete,
			[Display(Name = "Changed")]
			Change,
		}
        public enum StatusType
        {
            [Display(Name = "Nothing change")]
            None,
            [Display(Name = "OK")]
            OK,
            [Display(Name = "ERROR")]
            ERROR,
        }
    }
}