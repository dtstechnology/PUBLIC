using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTS.Ear.Library.Models.UpdateInvoice
{
    //FullInvoiceResponseModel
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);


    public class FullInvoiceUpdateModel
    {
        public FullInvoiceUpdateModel()
        {
            malHizmetTable = new List<UpdateMalHizmetTable>();

        }
        public string faturaUuid { get; set; } = "";
        public string belgeNumarasi { get; set; } = "";
        public string faturaTarihi { get; set; } = DateTime.Now.ToString("dd/MM/yyyy");
        public string saat { get; set; } = DateTime.Now.ToString("HH:mm:ss");
        public string paraBirimi { get; set; } = "TRY";
        public string dovzTLkur { get; set; } = "0";
        public string faturaTipi { get; set; } = FaturaTipi.SATIS.ToString();
        public string hangiTip { get; set; } = "5000/30000";
        public string vknTckn { get; set; } = "11111111111";
        public string aliciUnvan { get; set; } = "";
        public string aliciAdi { get; set; } = "";
        public string aliciSoyadi { get; set; } = "";
        public string binaAdi { get; set; } = "";
        public string binaNo { get; set; } = "";
        public string kapiNo { get; set; } = "";
        public string kasabaKoy { get; set; } = "";
        public string vergiDairesi { get; set; } = "";
        public string ulke { get; set; } = "Türkiye";
        public string bulvarcaddesokak { get; set; } = "";
        public string mahalleSemtIlce { get; set; } = "";
        public string sehir { get; set; } = " ";
        public string postaKodu { get; set; } = "";
        public string tel { get; set; } = "";
        public string fax { get; set; } = "";
        public string eposta { get; set; } = "";
        public string websitesi { get; set; } = "";
        public string[] iadeTable { get; set; } = new List<string>().ToArray();
        //public List<UpdateIadeTable> iadeTable { get; set; } = new List<UpdateIadeTable>();
        public string vergiCesidi { get; set; } = " ";
        public List<UpdateMalHizmetTable> malHizmetTable { get; set; }
        public string tip { get; set; } = "İskonto";
        public string matrah { get; set; } = "";//
        public string malhizmetToplamTutari { get; set; } = "";//
        public string toplamIskonto { get; set; } = "0";
        public string hesaplanankdv { get; set; } = "";//
        public string vergilerToplami { get; set; } = "";//
        public string vergilerDahilToplamTutar { get; set; } = "";//
        public string odenecekTutar { get; set; } = "";//
        public string not { get; set; } = "";//
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

    public class UpdateIadeTable
    {
        public string faturaNo { get; set; }
        public string duzenlenmeTarihi { get; set; }
    }

    public class UpdateMalHizmetTable
    {


        public string malHizmet { get; set; }
        public decimal miktar { get; set; } = 1;
        public string birim { get; set; } = "C62";
        public string birimFiyat { get; set; }
        public string fiyat { get; set; }
        public int iskontoOrani { get; set; } = 0;
        public string iskontoTutari { get; set; } = "0";
        public string iskontoNedeni { get; set; } = "";
        public string malHizmetTutari { get; set; }
        public string kdvOrani { get; set; }
        public int vergiOrani { get; set; } = 0;
        public string kdvTutari { get; set; }
        public string vergininKdvTutari { get; set; } = "0";
        public string ozelMatrahTutari { get; set; } = "0";
        public string hesaplananotvtevkifatakatkisi { get; set; } = "0";

        public UpdateMalHizmetTable(MalHizmetTable invoiceDetailsItem)
        {
            malHizmet = invoiceDetailsItem.malHizmet;
            miktar = invoiceDetailsItem.miktar;
            birimFiyat = decimal.Round(invoiceDetailsItem.birimFiyat, 2).ToString().Replace(",", ".");
            fiyat = decimal.Round(invoiceDetailsItem.fiyat, 2).ToString().Replace(",", ".");
            malHizmetTutari = decimal.Round(invoiceDetailsItem.miktar * invoiceDetailsItem.birimFiyat, 2).ToString().Replace(",", ".");
            kdvOrani = invoiceDetailsItem.kdvOrani.ToString().Replace(",", ".");
            kdvTutari = decimal.Round(invoiceDetailsItem.kdvTutari, 2).ToString().Replace(",", ".");
        }

        //public string iskontoArttm { get; set; } 
        //public string V0021Orani { get; set; } 
        //public string V0061Orani { get; set; } 
        //public string V0071Orani { get; set; } 
        //public string V0073Orani { get; set; } 
        //public string V0074Orani { get; set; } 
        //public string V0075Orani { get; set; } 
        //public string V0076Orani { get; set; } 
        //public string V0077Orani { get; set; } 
        //public string V1047Orani { get; set; } 
        //public string V1048Orani { get; set; } 
        //public string V4080Orani { get; set; } 
        //public string V4081Orani { get; set; } 
        //public string V9015Orani { get; set; } 
        //public string V9021Orani { get; set; } 
        //public string V9077Orani { get; set; } 
        //public string V8001Orani { get; set; } 
        //public string V8002Orani { get; set; } 
        //public string V4071Orani { get; set; } 
        //public string V8004Orani { get; set; } 
        //public string V8005Orani { get; set; } 
        //public string V8006Orani { get; set; } 
        //public string V8007Orani { get; set; } 
        //public string V8008Orani { get; set; } 
        //public string V0003Orani { get; set; } 
        //public string V0011Orani { get; set; } 
        //public string V9040Orani { get; set; } 
        //public string V4171Orani { get; set; } 
        //public string V9944Orani { get; set; } 
        //public string V0059Orani { get; set; } 
        //public string V0021Tutari { get; set; } 
        //public string V0061Tutari { get; set; } 
        //public string V0061KdvTutari { get; set; } 
        //public string V0071Tutari { get; set; } 
        //public string V0071KdvTutari { get; set; } 
        //public string V0073Tutari { get; set; } 
        //public string V0073KdvTutari { get; set; } 
        //public string V0074Tutari { get; set; } 
        //public string V0074KdvTutari { get; set; } 
        //public string V0075Tutari { get; set; } 
        //public string V0075KdvTutari { get; set; } 
        //public string V0076Tutari { get; set; } 
        //public string V0076KdvTutari { get; set; } 
        //public string V0077Tutari { get; set; } 
        //public string V0077KdvTutari { get; set; } 
        //public string V1047Tutari { get; set; } 
        //public string V1047KdvTutari { get; set; } 
        //public string V1048Tutari { get; set; } 
        //public string V4080Tutari { get; set; } 
        //public string V4081Tutari { get; set; } 
        //public string V9015Tutari { get; set; } 
        //public string V9021Tutari { get; set; } 
        //public string V9077Tutari { get; set; } 
        //public string V9077KdvTutari { get; set; } 
        //public string V8001Tutari { get; set; } 
        //public string V8002Tutari { get; set; } 
        //public string V8002KdvTutari { get; set; } 
        //public string V4071Tutari { get; set; } 
        //public string V4071KdvTutari { get; set; } 
        //public string V8004Tutari { get; set; } 
        //public string V8004KdvTutari { get; set; } 
        //public string V8005Tutari { get; set; } 
        //public string V8005KdvTutari { get; set; } 
        //public string V8006Tutari { get; set; } 
        //public string V8007Tutari { get; set; } 
        //public string V8008Tutari { get; set; } 
        //public string V0003Tutari { get; set; } 
        //public string V0011Tutari { get; set; } 
        //public string V9040Tutari { get; set; } 
        //public string V4171Tutari { get; set; } 
        //public string V9944Tutari { get; set; } 
        //public string V9944KdvTutari { get; set; } 
        //public string V0059Tutari { get; set; } 
        //public string hesaplananotvtevkifatakatkisi2 { get; set; } 
    }




}