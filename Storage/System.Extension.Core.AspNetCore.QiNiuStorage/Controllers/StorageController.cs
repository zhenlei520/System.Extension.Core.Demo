using System.Linq;
using System.Threading.Tasks;
using EInfrastructure.Core.Configuration.Ioc.Plugs.Storage;
using EInfrastructure.Core.Configuration.Ioc.Plugs.Storage.Param;
using Microsoft.AspNetCore.Mvc;

namespace System.Extension.Core.AspNetCore.QiNiuStorage.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class StorageController : Controller
    {
        private readonly IStorageProvider _storageProvider;

        public StorageController(IStorageProvider storageProvider)
        {
            _storageProvider = storageProvider;
        }

        /// <summary>
        /// 文件上传
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Upload()
        {
            var fileList = HttpContext.Request.Form.Files.Select(x => new
            {
                name = x.Name,
                stream = x.OpenReadStream()
            }).ToList();
            fileList.ForEach(file =>
            {
                _storageProvider.UploadStream(new UploadByStreamParam("test_"+Guid.NewGuid()+".jp", file.stream));
            });
            return Json("ok");
        }
    }
}