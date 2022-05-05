using MobileWorld.ControllerHelper.Contracts;
using MobileWorld.Infrastructure.Data.Models;

namespace MobileWorld.ControllerHelper
{
    public class ImageBinding : IImageBinding
    {
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment;
        private readonly string wwwPath;
        private readonly string contentPath ;
        private readonly string path ;

        public ImageBinding(Microsoft.AspNetCore.Hosting.IHostingEnvironment environment)
        {
            _environment = environment;
            wwwPath= this._environment.WebRootPath;
            contentPath = this._environment.ContentRootPath;
            path = Path.Combine(this._environment.WebRootPath, "Uploads");
        }

        public List<Image> BindImages(IFormFileCollection formFiles)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            List<Image> uploadedFiles = new List<Image>();
            foreach (IFormFile postedFile in formFiles)
            {
                string fileName = Path.GetFileName(postedFile.FileName);
                using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                    uploadedFiles.Add(new Image()
                    {
                        ImagePath = this.path,
                        ImageTitle = fileName
                    });
                }
            }

            return uploadedFiles;
        }
    }
}
