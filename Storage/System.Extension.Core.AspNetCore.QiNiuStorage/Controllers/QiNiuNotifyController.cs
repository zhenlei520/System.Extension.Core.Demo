// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading.Tasks;
using EInfrastructure.Core.QiNiu.Storage.Auths;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace System.Extension.Core.AspNetCore.QiNiuStorage.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class QiNiuNotifyController : Controller
    {
        public QiNiuNotifyController()
        {
        }

        /// <summary>
        /// 增加QiNiuAuth自动完成鉴权，防止非七牛云存储的其他请求访问
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        [QiNiuAuth]
        public async Task<JsonResult> CallBack([FromBody] QiNiuCallBackRequest param)
        {
            return await Task.FromResult(new JsonResult("ok"));
        }

        public class QiNiuCallBackRequest
        {
            /// <summary>
            /// 文件key
            /// </summary>
            [JsonProperty(PropertyName = "key")]
            public string Key { get; set; }

            /// <summary>
            /// 文件hash
            /// </summary>
            [JsonProperty(PropertyName = "hash")]
            public string Hash { get; set; }

            /// <summary>
            /// 文件大小
            /// </summary>
            [JsonProperty(PropertyName = "size")]
            public double FSize { get; set; }

            /// <summary>
            /// 空间名
            /// </summary>
            [JsonProperty(PropertyName = "bucket")]
            public string Bucket { get; set; }

            /// <summary>
            /// 文件名称
            /// </summary>
            [JsonProperty(PropertyName = "name")]
            public string Name { get; set; }

            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "mimeType")]
            public string MimeType { get; set; }

            /// <summary>
            /// 上传资源的后缀名
            /// </summary>
            [JsonProperty(PropertyName = "ext")]
            public string Ext { get; set; }

            /// <summary>
            /// 店铺id
            /// </summary>
            [JsonProperty(PropertyName = "store_id")]
            public int StoreId { get; set; }

            /// <summary>
            /// 平台唯一标识
            /// </summary>
            [JsonProperty(PropertyName = "platform_code")]
            public string PlatformCode { get; set; }

            /// <summary>
            /// 校验码
            /// </summary>
            [JsonProperty(PropertyName = "check_code")]
            public string CheckCode { get; set; }

            /// <summary>
            /// 文件类型
            /// </summary>
            [JsonProperty(PropertyName = "file_type")]
            public int FileType { get; set; }

            /// <summary>
            /// 路径
            /// </summary>
            [JsonProperty("path")]
            public string Path { get; set; }

            /// <summary>
            /// 视频资源时长
            /// </summary>
            [JsonProperty(PropertyName = "videoduration")]
            public string VideoDuration { get; set; }

            /// <summary>
            /// 音频资源时长
            /// </summary>
            [JsonProperty(PropertyName = "audioduration")]
            public string AudioDuration { get; set; }

            /// <summary>
            /// 宽度
            /// </summary>
            [JsonProperty(PropertyName = "width")]
            public string Width { get; set; }

            /// <summary>
            /// 高度
            /// </summary>
            [JsonProperty(PropertyName = "height")]
            public string Height { get; set; }
        }
    }
}