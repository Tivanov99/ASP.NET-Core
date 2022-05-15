namespace MobileWorld.Infrastructure.Data.QueriesAndSPDtoModels
{
    public class AdSpModel
    {
        public AdSpModel()
        {
            Images = new();
        }
        public AdInfoSpModel AdInfo { get; set; }

        public CarSpModel Car { get; set; }

        public EngineSpModel Engine { get; set; }

        public FeatureSpModel Feature { get; set; }

        public List<string> Images { get; set; }
    }
}
