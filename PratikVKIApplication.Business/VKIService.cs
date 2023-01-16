using PratikVKIApplication.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PratikVKIApplication.Business
{
    public class VKIService
    {
        private static List<VKI> vkiList = new List<VKI>();

        public static void SaveVKI(VKI vki)
        {
            GetVKIList();
            vkiList.Add(vki);

            string json = JsonSerializer.Serialize(vkiList, new JsonSerializerOptions { IncludeFields = true });

            DosyaIslemleri.Yaz(json);
        }

        public static IReadOnlyCollection<VKI> GetVKIList()
        {
            string json = DosyaIslemleri.Oku();
            if (!string.IsNullOrEmpty(json))
                vkiList = JsonSerializer.Deserialize<List<VKI>>(json, new JsonSerializerOptions { IncludeFields = true });

            return vkiList.AsReadOnly();
        }

        public static IReadOnlyCollection<VKI> SearchWithName(string hastaAdi)
        {
            GetVKIList();
            var sonuc = new List<VKI>();
            foreach (var item in vkiList)
            {
                if(item.hastaAdi.ToLower()==hastaAdi)
                    sonuc.Add(item);
            }
            return sonuc.AsReadOnly();
        }

        

        public static List<VKI> DeletedVKIForName(string hastaAdi)
        {
            
            GetVKIList();
            for (int i = vkiList.Count-1; i >= 0; i--)
            {
                if (vkiList[i].hastaAdi.ToLower() == hastaAdi.ToLower())
                {
                    vkiList.Remove(vkiList[i]);
                }
                
            }
            string json = JsonSerializer.Serialize(vkiList, new JsonSerializerOptions { IncludeFields = true });

            DosyaIslemleri.Yaz(json);           
            return vkiList;
        }

        public static List<VKI> UpdateVKIForName(string hastaninAdi,string yeniHastaAdi)
        {
            GetVKIList();
            foreach (var item in vkiList)
            {
                if (item.hastaAdi.ToLower() == hastaninAdi)
                    item.hastaAdi = yeniHastaAdi;
            }
            string json = JsonSerializer.Serialize(vkiList, new JsonSerializerOptions { IncludeFields = true });

            DosyaIslemleri.Yaz(json);
            return vkiList;
        }


            
        
    }
}
