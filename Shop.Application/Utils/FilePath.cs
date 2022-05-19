using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Utils
{
    public class FilePath
    {

        public static string AvatarDefault = "/images/user-no-image.jpg";


        public static string AvatarOrigin = "/Content/Images/UserAvatar/origin/";
        public static string AvatarThumb = "/Content/Images/UserAvatar/Thumb/";

        public static string StoreOrigin = "/Content/Images/Store/origin";
        public static string StoreThumb = "/Content/Images/Store/Thumb";


        public static string AvatarServerOrigin = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Content/Images/UserAvatar/origin/");
        public static string AvatarServerThumb = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Content/Images/UserAvatar/Thumb/");

        public static string StoreServerOrigin = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Content/Images/Store/origin/");
        public static string StoreServerThumb = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Content/Images/Store/Thumb/");



        //CkEditor Upload Images
        public static string UploadImage = "/img/upload/";
        public static string UploadImageServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/upload/");



        //Product
        public static string ProductOrigin = "/Content/Images/Product/origin/";
        public static string ProductThumb = "/Content/Images/Product/Thumb/";

        public static string ProductServerOrigin = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Content/Images/Product/origin/");
        public static string ProductServerThumb = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Content/Images/Product/Thumb/");




        //ProductGallery

        public static string ProductGalleryImage = "/content/images/product-gallery/origin/";

        public static string ProductGalleryImageServer =
            Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/content/images/product-gallery/origin/");

        public static string ProductGalleryThumbnailImage = "/content/images/product-gallery/thumb/";

        public static string ProductGalleryThumbnailImageServer =
            Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/content/images/product-gallery/thumb/");

    }
}
