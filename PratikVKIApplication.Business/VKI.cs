namespace PratikVKIApplication.Business
{
    public class VKI
    {
        public string hastaAdi;
        public double boy;
        public double kilo;

        public double VKIHesaplama()
        {
            return kilo / (boy * boy);
        }
    }
}