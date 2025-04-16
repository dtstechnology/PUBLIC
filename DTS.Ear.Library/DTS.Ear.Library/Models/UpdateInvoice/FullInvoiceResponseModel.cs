using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTS.Ear.Library.Models.UpdateInvoice
{
    //FullInvoiceResponseModel
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

    public class Metadata
    {
        public string optime { get; set; }  
    }

    public class UpdatedInvoiceResponseModel
    {
        public string data { get; set; }
        public Metadata metadata { get; set; }
        public string error { get; set; }
        public List<MessageModel> messages { get; set; }
    }

    public class FullInvoiceResponseModel
    {
        public FullInvoiceModel data { get; set; }  
        public Metadata metadata { get; set; }
        public string error { get; set; }
        public List<MessageModel> messages { get; set; }
    }


    public class FullInvoiceModel
    {
        public string faturaUuid { get; set; } 
        public string faturaTarihi { get; set; } 
        public string faturaTipi { get; set; } 
        public string paraBirimi { get; set; } 
        public decimal dovzTLkur { get; set; } 
        public string vknTckn { get; set; } 
        public string aliciAdi { get; set; } 
        public string aliciSoyadi { get; set; } 
        public string aliciUnvan { get; set; }  
        public string bulvarcaddesokak { get; set; } 
        public string binaAdi { get; set; } 
        public string binaNo { get; set; } 
        public string kapiNo { get; set; } 
        public string kasabaKoy { get; set; } 
        public string mahalleSemtIlce { get; set; } 
        public string postaKodu { get; set; } 
        public string ulke { get; set; } 
        public string tel { get; set; } 
        public string fax { get; set; } 
        public string eposta { get; set; } 
        public string websitesi { get; set; } 
        public string sehir { get; set; } 
        public string vergiDairesi { get; set; } 
        public string belgeNumarasi { get; set; } 
        public decimal komisyonOrani { get; set; } 
        public decimal navlunOrani { get; set; } 
        public decimal hammaliyeOrani { get; set; } 
        public decimal nakliyeOrani { get; set; } 
        public decimal komisyonTutari { get; set; } 
        public decimal navlunTutari { get; set; } 
        public decimal hammaliyeTutari { get; set; } 
        public decimal nakliyeTutari { get; set; } 
        public decimal komisyonKDVOrani { get; set; } 
        public decimal navlunKDVOrani { get; set; } 
        public decimal hammaliyeKDVOrani { get; set; } 
        public decimal nakliyeKDVOrani { get; set; } 
        public decimal komisyonKDVTutari { get; set; } 
        public decimal navlunKDVTutari { get; set; } 
        public decimal hammaliyeKDVTutari { get; set; } 
        public decimal nakliyeKDVTutari { get; set; } 
        public decimal gelirVergisiOrani { get; set; } 
        public decimal bagkurTevkifatiOrani { get; set; } 
        public decimal gelirVergisiTevkifatiTutari { get; set; } 
        public decimal bagkurTevkifatiTutari { get; set; } 
        public decimal halRusumuOrani { get; set; } 
        public decimal ticaretBorsasiOrani { get; set; } 
        public decimal milliSavunmaFonuOrani { get; set; } 
        public decimal digerOrani { get; set; } 
        public decimal halRusumuTutari { get; set; } 
        public decimal ticaretBorsasiTutari { get; set; } 
        public decimal milliSavunmaFonuTutari { get; set; } 
        public decimal digerTutari { get; set; } 
        public decimal halRusumuKDVOrani { get; set; } 
        public decimal ticaretBorsasiKDVOrani { get; set; } 
        public decimal milliSavunmaFonuKDVOrani { get; set; } 
        public decimal digerKDVOrani { get; set; } 
        public decimal halRusumuKDVTutari { get; set; } 
        public decimal ticaretBorsasiKDVTutari { get; set; } 
        public decimal milliSavunmaFonuKDVTutari { get; set; } 
        public decimal digerKDVTutari { get; set; } 
        public List<MalHizmetTable> malHizmetTable { get; set; }
        public List<IadeTable> iadeTable { get; set; } 
        public decimal malhizmetToplamTutari { get; set; } 
        public decimal matrah { get; set; } 
        public decimal toplamIskonto { get; set; } 
        public decimal hesaplanankdv { get; set; } 
        public decimal vergilerDahilToplamTutar { get; set; } 
        public decimal toplamMasraflar { get; set; } 
        public decimal odenecekTutar { get; set; } 
        public decimal vergilerToplami { get; set; } 
        public string tip { get; set; } 
        public string not { get; set; } 
        public string saat { get; set; } 
        public decimal ozelMatrahTutari { get; set; } 
        public decimal ozelMatrahOrani { get; set; }  
        public decimal ozelMatrahVergiTutari { get; set; }
        //public string hata { get; set; }  
        public string siparisNumarasi { get; set; } = "";
        public string siparisTarihi { get; set; } = "";
        public string irsaliyeNumarasi { get; set; } = "";
        public string irsaliyeTarihi { get; set; } = "";
        public string fisNo { get; set; } = "";
        public string fisTarihi { get; set; } = "";
        public string fisSaati { get; set; } = "";
        public string fisTipi { get; set; } = "";
        public string zRaporNo { get; set; } = "";
        public string okcSeriNo { get; set; } = "";

    }

    public class IadeTable
    {
        public string faturaNo { get; set; } 
        public string duzenlenmeTarihi { get; set; } 
    }

    public partial class MalHizmetTable
    { 
        public string malHizmet { get; set; } 
        public decimal miktar { get; set; } 
        public string birim { get; set; } 
        public decimal birimFiyat { get; set; } 
        public decimal fiyat { get; set; } 
        public decimal iskontoOrani { get; set; } 
        public decimal iskontoTutari { get; set; } 
        public string iskontoNedeni { get; set; } 
        public decimal malHizmetTutari { get; set; } 
        public decimal kdvOrani { get; set; }
        public int vergiOrani { get; set; } = 0;
        public decimal kdvTutari { get; set; } 
        public string vergininKdvTutari { get; set; } = "0";
        public decimal ozelMatrahTutari { get; set; } 
        public string hesaplananotvtevkifatakatkisi { get; set; } = "0";




        //public string iskontoArttm { get; set; } 
        //public decimal V0021Orani { get; set; } 
        //public decimal V0061Orani { get; set; } 
        //public decimal V0071Orani { get; set; } 
        //public decimal V0073Orani { get; set; } 
        //public decimal V0074Orani { get; set; } 
        //public decimal V0075Orani { get; set; } 
        //public decimal V0076Orani { get; set; } 
        //public decimal V0077Orani { get; set; } 
        //public decimal V1047Orani { get; set; } 
        //public decimal V1048Orani { get; set; } 
        //public decimal V4080Orani { get; set; } 
        //public decimal V4081Orani { get; set; } 
        //public decimal V9015Orani { get; set; } 
        //public decimal V9021Orani { get; set; } 
        //public decimal V9077Orani { get; set; } 
        //public decimal V8001Orani { get; set; } 
        //public decimal V8002Orani { get; set; } 
        //public decimal V4071Orani { get; set; } 
        //public decimal V8004Orani { get; set; } 
        //public decimal V8005Orani { get; set; } 
        //public decimal V8006Orani { get; set; } 
        //public decimal V8007Orani { get; set; } 
        //public decimal V8008Orani { get; set; } 
        //public decimal V0003Orani { get; set; } 
        //public decimal V0011Orani { get; set; } 
        //public decimal V9040Orani { get; set; } 
        //public decimal V4171Orani { get; set; } 
        //public decimal V9944Orani { get; set; } 
        //public decimal V0059Orani { get; set; } 
        //public decimal V0021Tutari { get; set; } 
        //public decimal V0061Tutari { get; set; } 
        //public decimal V0061KdvTutari { get; set; } 
        //public decimal V0071Tutari { get; set; } 
        //public decimal V0071KdvTutari { get; set; } 
        //public decimal V0073Tutari { get; set; } 
        //public decimal V0073KdvTutari { get; set; } 
        //public decimal V0074Tutari { get; set; } 
        //public decimal V0074KdvTutari { get; set; } 
        //public decimal V0075Tutari { get; set; } 
        //public decimal V0075KdvTutari { get; set; } 
        //public decimal V0076Tutari { get; set; } 
        //public decimal V0076KdvTutari { get; set; } 
        //public decimal V0077Tutari { get; set; } 
        //public decimal V0077KdvTutari { get; set; } 
        //public decimal V1047Tutari { get; set; } 
        //public decimal V1047KdvTutari { get; set; } 
        //public decimal V1048Tutari { get; set; } 
        //public decimal V4080Tutari { get; set; } 
        //public decimal V4081Tutari { get; set; } 
        //public decimal V9015Tutari { get; set; } 
        //public decimal V9021Tutari { get; set; } 
        //public decimal V9077Tutari { get; set; } 
        //public decimal V9077KdvTutari { get; set; } 
        //public decimal V8001Tutari { get; set; } 
        //public decimal V8002Tutari { get; set; } 
        //public decimal V8002KdvTutari { get; set; } 
        //public decimal V4071Tutari { get; set; } 
        //public decimal V4071KdvTutari { get; set; } 
        //public decimal V8004Tutari { get; set; } 
        //public decimal V8004KdvTutari { get; set; } 
        //public decimal V8005Tutari { get; set; } 
        //public decimal V8005KdvTutari { get; set; } 
        //public decimal V8006Tutari { get; set; } 
        //public decimal V8007Tutari { get; set; } 
        //public decimal V8008Tutari { get; set; } 
        //public decimal V0003Tutari { get; set; } 
        //public decimal V0011Tutari { get; set; } 
        //public decimal V9040Tutari { get; set; } 
        //public decimal V4171Tutari { get; set; } 
        //public decimal V9944Tutari { get; set; } 
        //public decimal V9944KdvTutari { get; set; } 
        //public decimal V0059Tutari { get; set; } 
        //public decimal hesaplananotvtevkifatakatkisi2 { get; set; } 
    }

  




    //    public class FullInvoiceResponseModel
    //    {

    //        public List<FullInvoiceModel> data { get; set; } 
    //        public Metadata metadata { get; set; } 
    //        public string error { get; set; } 
    //        public List<MessageModel> messages { get; set; } 
    //        //public 
    //    }



    //    public class Metadata
    //    {
    //        public string optime { get; set; } 
    //    }

    //    public class FullInvoiceModel
    //    {
    //        public string faturaUuid { get; set; } 
    //        public string faturaTarihi { get; set; } 
    //        public string faturaTipi { get; set; } 
    //        public string paraBirimi { get; set; } 
    //        public decimal dovzTLkur { get; set; } 
    //        public string vknTckn { get; set; } 
    //        public string aliciAdi { get; set; } 
    //        public string aliciSoyadi { get; set; } 
    //        public string bulvarcaddesokak { get; set; } 
    //        public string binaAdi { get; set; } 
    //        public string binaNo { get; set; } 
    //        public string kapiNo { get; set; } 
    //        public string kasabaKoy { get; set; } 
    //        public string mahalleSemtIlce { get; set; } 
    //        public string postaKodu { get; set; } 
    //        public string ulke { get; set; } 
    //        public string tel { get; set; } 
    //        public string fax { get; set; } 
    //        public string eposta { get; set; } 
    //        public string websitesi { get; set; } 
    //        public string sehir { get; set; } 
    //        public string vergiDairesi { get; set; } 
    //        public string belgeNumarasi { get; set; } 
    //        public decimal komisyonOrani { get; set; } 
    //        public decimal navlunOrani { get; set; } 
    //        public decimal hammaliyeOrani { get; set; } 
    //        public decimal nakliyeOrani { get; set; } 
    //        public decimal komisyonTutari { get; set; } 
    //        public decimal navlunTutari { get; set; } 
    //        public decimal hammaliyeTutari { get; set; } 
    //        public decimal nakliyeTutari { get; set; } 
    //        public decimal komisyonKDVOrani { get; set; } 
    //        public decimal navlunKDVOrani { get; set; } 
    //        public decimal hammaliyeKDVOrani { get; set; } 
    //        public decimal nakliyeKDVOrani { get; set; } 
    //        public decimal komisyonKDVTutari { get; set; } 
    //        public decimal navlunKDVTutari { get; set; } 
    //        public decimal hammaliyeKDVTutari { get; set; } 
    //        public decimal nakliyeKDVTutari { get; set; } 
    //        public decimal gelirVergisiOrani { get; set; } 
    //        public decimal bagkurTevkifatiOrani { get; set; } 
    //        public decimal gelirVergisiTevkifatiTutari { get; set; } 
    //        public decimal bagkurTevkifatiTutari { get; set; } 
    //        public decimal halRusumuOrani { get; set; } 
    //        public decimal ticaretBorsasiOrani { get; set; } 
    //        public decimal milliSavunmaFonuOrani { get; set; } 
    //        public decimal digerOrani { get; set; } 
    //        public decimal halRusumuTutari { get; set; } 
    //        public decimal ticaretBorsasiTutari { get; set; } 
    //        public decimal milliSavunmaFonuTutari { get; set; } 
    //        public decimal digerTutari { get; set; } 
    //        public decimal halRusumuKDVOrani { get; set; } 
    //        public decimal ticaretBorsasiKDVOrani { get; set; } 
    //        public decimal milliSavunmaFonuKDVOrani { get; set; } 
    //        public decimal digerKDVOrani { get; set; } 
    //        public decimal halRusumuKDVTutari { get; set; } 
    //        public decimal ticaretBorsasiKDVTutari { get; set; } 
    //        public decimal milliSavunmaFonuKDVTutari { get; set; } 
    //        public decimal digerKDVTutari { get; set; } 
    //        public List<MalHizmetTable> malHizmetTable { get; set; } 
    //        public decimal malhizmetToplamTutari { get; set; } 
    //        public decimal matrah { get; set; } 
    //        public decimal toplamIskonto { get; set; } 
    //        public decimal hesaplanankdv { get; set; } 
    //        public decimal vergilerDahilToplamTutar { get; set; } 
    //        public decimal toplamMasraflar { get; set; } 
    //        public decimal odenecekTutar { get; set; } 
    //        public decimal vergilerToplami { get; set; } 
    //        public string tip { get; set; } 
    //        public string not { get; set; } 
    //        public string saat { get; set; } 
    //        public decimal ozelMatrahTutari { get; set; } 
    //        public decimal ozelMatrahOrani { get; set; } 
    //        public decimal ozelMatrahVergiTutari { get; set; } 
    //        public string hata { get; set; } 
    //    }

    //    public class MalHizmetTable
    //    {
    //        public string malHizmet { get; set; } 
    //        public decimal miktar { get; set; } 
    //        public decimal ozelMatrahTutari { get; set; } 
    //        public string birim { get; set; } 
    //        public decimal birimFiyat { get; set; } 
    //        public decimal iskontoOrani { get; set; } 
    //        public string iskontoNedeni { get; set; } 
    //        public string iskontoArttm { get; set; } 
    //        public decimal iskontoTutari { get; set; } 
    //        public decimal malHizmetTutari { get; set; } 
    //        public decimal kdvOrani { get; set; } 
    //        public decimal kdvTutari { get; set; } 
    //        public decimal fiyat { get; set; } 
    //        public decimal V0021Orani { get; set; } 
    //        public decimal V0061Orani { get; set; } 
    //        public decimal V0071Orani { get; set; } 
    //        public decimal V0073Orani { get; set; } 
    //        public decimal V0074Orani { get; set; } 
    //        public decimal V0075Orani { get; set; } 
    //        public decimal V0076Orani { get; set; } 
    //        public decimal V0077Orani { get; set; } 
    //        public decimal V1047Orani { get; set; } 
    //        public decimal V1048Orani { get; set; } 
    //        public decimal V4080Orani { get; set; } 
    //        public decimal V4081Orani { get; set; } 
    //        public decimal V9015Orani { get; set; } 
    //        public decimal V9021Orani { get; set; } 
    //        public decimal V9077Orani { get; set; } 
    //        public decimal V8001Orani { get; set; } 
    //        public decimal V8002Orani { get; set; } 
    //        public decimal V4071Orani { get; set; } 
    //        public decimal V8004Orani { get; set; } 
    //        public decimal V8005Orani { get; set; } 
    //        public decimal V8006Orani { get; set; } 
    //        public decimal V8007Orani { get; set; } 
    //        public decimal V8008Orani { get; set; } 
    //        public decimal V0003Orani { get; set; } 
    //        public decimal V0011Orani { get; set; } 
    //        public decimal V9040Orani { get; set; } 
    //        public decimal V4171Orani { get; set; } 
    //        public decimal V9944Orani { get; set; } 
    //        public decimal V0059Orani { get; set; } 
    //        public decimal V0021Tutari { get; set; } 
    //        public decimal V0061Tutari { get; set; } 
    //        public decimal V0061KdvTutari { get; set; } 
    //        public decimal V0071Tutari { get; set; } 
    //        public decimal V0071KdvTutari { get; set; } 
    //        public decimal V0073Tutari { get; set; } 
    //        public decimal V0073KdvTutari { get; set; } 
    //        public decimal V0074Tutari { get; set; } 
    //        public decimal V0074KdvTutari { get; set; } 
    //        public decimal V0075Tutari { get; set; } 
    //        public decimal V0075KdvTutari { get; set; } 
    //        public decimal V0076Tutari { get; set; } 
    //        public decimal V0076KdvTutari { get; set; } 
    //        public decimal V0077Tutari { get; set; } 
    //        public decimal V0077KdvTutari { get; set; } 
    //        public decimal V1047Tutari { get; set; } 
    //        public decimal V1047KdvTutari { get; set; } 
    //        public decimal V1048Tutari { get; set; } 
    //        public decimal V4080Tutari { get; set; } 
    //        public decimal V4081Tutari { get; set; } 
    //        public decimal V9015Tutari { get; set; } 
    //        public decimal V9021Tutari { get; set; } 
    //        public decimal V9077Tutari { get; set; } 
    //        public decimal V9077KdvTutari { get; set; } 
    //        public decimal V8001Tutari { get; set; } 
    //        public decimal V8002Tutari { get; set; } 
    //        public decimal V8002KdvTutari { get; set; } 
    //        public decimal V4071Tutari { get; set; } 
    //        public decimal V4071KdvTutari { get; set; } 
    //        public decimal V8004Tutari { get; set; } 
    //        public decimal V8004KdvTutari { get; set; } 
    //        public decimal V8005Tutari { get; set; } 
    //        public decimal V8005KdvTutari { get; set; } 
    //        public decimal V8006Tutari { get; set; } 
    //        public decimal V8007Tutari { get; set; } 
    //        public decimal V8008Tutari { get; set; } 
    //        public decimal V0003Tutari { get; set; } 
    //        public decimal V0011Tutari { get; set; } 
    //        public decimal V9040Tutari { get; set; } 
    //        public decimal V4171Tutari { get; set; } 
    //        public decimal V9944Tutari { get; set; } 
    //        public decimal V9944KdvTutari { get; set; } 
    //        public decimal V0059Tutari { get; set; } 
    //        public decimal hesaplananotvtevkifatakatkisi2 { get; set; } 
    //    }

    //    //public string faturaUuid { get; set; }  = Guid.NewGuid().ToString();
    //    //public string faturaTarihi { get; set; }  = DateTime.Now.ToString("dd/MM/yyyy");
    //    //public string faturaTipi { get; set; }  = FaturaTipi.Satis.ToString();
    //    //public string paraBirimi { get; set; }  = "TRY";
    //    //public string belgeNumarasi { get; set; }  
    //    //public string saat { get; set; }  = DateTime.Now.ToString("HH:mm:ss");
    //    //public string dovzTLkur { get; set; }  = "0";
    //    //public string hangiTip { get; set; }  = "5000/30000";
    //    //public string vknTckn { get; set; }  = "11111111111";
    //    //public string aliciUnvan { get; set; }  
    //    //public string aliciAdi { get; set; }  
    //    //public string aliciSoyadi { get; set; }  siparisTarihi
    //    //public string binaAdi { get; set; }  
    //    //public string binaNo { get; set; }  
    //    //public string kapiNo { get; set; }  
    //    //public string kasabaKoy { get; set; }  
    //    //public string vergiDairesi { get; set; }  
    //    //public string ulke { get; set; }  = "Türkiye";
    //    //public string bulvarcaddesokak { get; set; }  
    //    //public string mahalleSemtIlce { get; set; }  
    //    //public string sehir { get; set; }  = " ";
    //    //public string postaKodu { get; set; }  
    //    //public string tel { get; set; }  
    //    //public string fax { get; set; }  
    //    //public string eposta { get; set; }  
    //    //public string websitesi { get; set; }  
    //    //public string[] iadeTable { get; set; }  = new List<string>().ToArray();
    //    //public string vergiCesidi { get; set; }  = " ";
    //    //public List<MalHizmetTableModel> malHizmetTable { get; set; } 
    //    //public string tip { get; set; }  = "İskonto";
    //    //public string matrah { get; set; }  //
    //    //public string malhizmetToplamTutari { get; set; }  //
    //    //public string toplamIskonto { get; set; }  = "0";
    //    //public string hesaplanankdv { get; set; }  //
    //    //public string vergilerToplami { get; set; }  //
    //    //public string vergilerDahilToplamTutar { get; set; }  //
    //    //public string odenecekTutar { get; set; }  //
    //    //public string not { get; set; }  //
    //    //public string siparisNumarasi { get; set; }  
    //    //public string siparisTarihi { get; set; }  
    //    //public string irsaliyeNumarasi { get; set; }  
    //    //public string irsaliyeTarihi { get; set; }  
    //    //public string fisNo { get; set; }  
    //    //public string fisTarihi { get; set; }  
    //    //public string fisSaati { get; set; }  
    //    //public string fisTipi { get; set; }  
    //    //public string zRaporNo { get; set; }  
    //    //public string okcSeriNo { get; set; }  

    //    //public FullInvoiceModel()
    //    //    {
    //    //        malHizmetTable = new List<MalHizmetTableModel>();
    //    //    }

    //    //}
    //}
    //


}