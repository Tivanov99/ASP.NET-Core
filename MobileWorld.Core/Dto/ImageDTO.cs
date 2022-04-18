namespace MobileWorld.Core.Dto
{
    public class ImageDTO
    {
        public ImageDTO(string imageTitle, string imagePath)
        {
            this.ImagePath = imagePath;
            this.ImageTitle = imageTitle;
        }
        public string ImageTitle { get; set; }

        public string ImagePath { get; set; }
    }
}
