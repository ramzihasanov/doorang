using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorangWorld.Business.Helpers
{
    public static class Helper
    {
        public static string Save(string root,string folder,IFormFile file)
        {
            var url = file.FileName;
            url = url.Length > 64 ? url.Substring(url.Length - 64, 64) : url;
            url = Guid.NewGuid().ToString() + url;
            string path=Path.Combine(root,folder,url);
           using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }
           return url;
        }
        public static void Remove(string root,string folder,string ImageUrl)
        {
            var delurl=Path.Combine(root,folder,ImageUrl);
            if (File.Exists(delurl))
            {
                File.Delete(delurl);
            }
        }

    }
}
