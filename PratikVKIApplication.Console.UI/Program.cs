using Microsoft.VisualBasic.FileIO;
using System.ComponentModel.Design;
using System.Data;

namespace PratikVKIApplication.Business
{
    public class Pragram
    {
        public static void Main()
        {
            Menu();
        }

        private static void Menu()
        {
            Console.Clear();
            Console.WriteLine($"1. Yeni VKI Hesabı\n2. VKI Listesi\n3. Arama\n4. VKI Silme\n5.Güncelle\n6.Çıkış");
            MenuSelection();
        }

        private static void MenuSelection()
        {
            Console.Write("Yapılacak İşlemi Seçiniz :");
            string choose = Console.ReadLine();
            switch (choose)
            {
                case "1":
                    NewVKI();
                    break;
                case "2":
                    ListOfVKI();
                    break;
                case "3":
                    Search();
                    break;
                case "4":
                    Delete();
                    break;
                case "5":
                    Update();
                    break;
                case "6":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Hatlı Seçim");
                    MenuSelection();
                    break;
            }

        }

        private static void Update()
        {
            Console.WriteLine("Güncellenecek olan Hasta Adı :");
            string hastaAdi = Console.ReadLine();
            Console.WriteLine("Yeni Hasta Adı :");
            string yeniHastaAdi = Console.ReadLine();
            VKIService.UpdateVKIForName(hastaAdi, yeniHastaAdi);
            Console.WriteLine("Hasta İsmi Güncellendi");
            Again();
        }

        private static void Delete()
        {
            Console.Write("Silinecek Hasta Adı :");
            string hastaAdi = Console.ReadLine().ToLower();
            VKIService.DeletedVKIForName(hastaAdi);
            Console.WriteLine("Hasta Silindi");
            Again();
        }

        private static void NewVKI()
        {
            VKI newVKI = new VKI();
            Console.WriteLine("Hastanın Adı :");
            newVKI.hastaAdi = Console.ReadLine();
            Console.WriteLine("Hastanın Boyu :");
            newVKI.boy = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Hastanın Kilosu :");
            newVKI.kilo = Convert.ToDouble(Console.ReadLine());

            VKIService.SaveVKI(newVKI);
            WriteToSecreen(newVKI);
            Again();
        }

        private static void ListOfVKI()
        {
            var vkiList = VKIService.GetVKIList();
            WriteFromList(vkiList);
            Again();
        }

        private static void WriteFromList(IReadOnlyCollection<VKI> vki)
        {
            foreach (VKI item in vki)
            {
                WriteToSecreen(item);
            }
        }

        private static void WriteToSecreen(VKI vki)
        {
            Console.WriteLine($"Hasta Adı : {vki.hastaAdi}, Hastanın Boyu :{vki.boy}, Hastanın Kilosu : {vki.kilo},  VKI Oranı :{vki.VKIHesaplama()}");
        }

        private static void Again()
        {
            Console.WriteLine("Menüye dönmek için ENTER");
            Console.ReadLine();
            Menu();
        }

        private static void Search()
        {
            Console.Write("Aranacak Hasta Adı :");
            string hastaAdi = Console.ReadLine().ToLower();
            var data=VKIService.SearchWithName(hastaAdi);

            WriteFromList(data);
            Again();
        }

    }
}


