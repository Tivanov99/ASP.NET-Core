namespace MobileWorld.Core.ViewModels.Contacts
{
    public interface IProtectionDetailViewModel
    {
        public bool Alarm { get; set; }

        public bool Armored { get; set; }

        public bool Immobilizer { get; set; }

        public bool Casco { get; set; }

        public bool CentralLocking { get; set; }
    }
}
