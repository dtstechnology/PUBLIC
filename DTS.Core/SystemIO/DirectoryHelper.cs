using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace DTS.Core.SystemIO
{
    public class DirectoryHelper
    {
        private IHostingEnvironment Environment;

        public DirectoryHelper(IHostingEnvironment _environment)
        {
            Environment = _environment;
        }
        public bool CreateProfileDirectory(string userID)
        { 
            string wwwPath = this.Environment.WebRootPath;
            string contentPath = this.Environment.ContentRootPath;

            string path = Path.Combine(wwwPath + "\\src\\Profile", userID);
            if (Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                return true;
            }
            else
            {
                return false;
            } 
        }
    }
}
