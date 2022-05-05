using MobileWorld.ControllerHelper.Contracts;
using MobileWorld.Infrastructure.Data.Models;

namespace MobileWorld.ControllerHelper
{
    public class ImageBinding : IImageBinding
    {
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment;
        private readonly string _wwwPath;
        private readonly string _contentPath ;
        private readonly string _path ;

        public ImageBinding(Microsoft.AspNetCore.Hosting.IHostingEnvironment environment)
        {
            _environment = environment;
            _wwwPath = this._environment.WebRootPath;
            _contentPath = this._environment.ContentRootPath;
            _path = Path.Combine(this._environment.WebRootPath, "Uploads");
        }

        public List<Image> BindImages(IFormFileCollection formFiles)
        {
            if (!Directory.Exists(_path))
            {
                Directory.CreateDirectory(_path);
            }

            List<Image> uploadedFiles = new List<Image>();
            foreach (IFormFile postedFile in formFiles)
            {
                string fileName = Path.GetFileName(postedFile.FileName);
                using (FileStream stream = new FileStream(Path.Combine(_path, fileName), FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                    uploadedFiles.Add(new Image()
                    {
                        ImagePath = this._path,
                        ImageTitle = fileName
                    });
                }
            }

            return uploadedFiles;
        }
    }
}
