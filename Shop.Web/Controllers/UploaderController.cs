using MarketPlace.Application.Extensions;
using MarketPlace.Application.Utils;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shop.Application.Utils;

namespace Shop.Web.Controllers
{
    public class UploaderController : Controller
    {
        [HttpPost]
        public IActionResult UploadImage(IFormFile upload, string CKEditorFuncName, string CKEditor, string LangCode)
        {
            if (upload.Length <= 0) return null;

            if (!upload.IsImage())
            {
                var notImageMessage = "لطفا یک تصویر انتخاب کنید";
                var notImage = JsonConvert.DeserializeObject("{'uploaded':0, 'error': {'message': \" " + notImageMessage + " \"}}");
                return Json(notImage);
            }
            var fileName = Guid.NewGuid() + Path.GetExtension(upload.FileName).ToLower();
            upload.AddImageToServer(fileName, FilePath.UploadImageServer, null, null);

            return Json(new
            {
                uploaded = true,
                url = $"{FilePath.UploadImage}{fileName}"
            });
        }
    }
}
