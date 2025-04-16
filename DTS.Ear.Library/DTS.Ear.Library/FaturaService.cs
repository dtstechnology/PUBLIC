using DTS.Ear.Library.Configuration;
using System.Net.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTS.Ear.Library.Models;
using DTS.Ear.Library.Services;
using DTS.Ear.Library.Commands;
using DTS.Ear.Library.Models.UpdateInvoice;

namespace DTS.Ear.Library
{
    public class FaturaService
    {
        private const string DATE_FORMAT = "dd/MM/yyyy";
        protected IFaturaServiceConfiguration _configuration;

        public FaturaService() : this(FaturaServiceConfigurationFactory.Create()) { }

        public FaturaService(IFaturaServiceConfiguration configuration)
        {
            _configuration = configuration;
            // GetToken();
        }

        public async Task GetToken()
        {
            var httpServices = new HttpServices<LoginModel>(_configuration);
            LoginModel loginModel = await httpServices.Login();

            _configuration.Token = loginModel.Token;
        }

        public async Task Logout()
        {
            var httpServices = new HttpServices<LoginModel>(_configuration);
            LoginModel loginModel = await httpServices.Logout();

        }

        public async Task<TestUserModel> GetTestUserID()
        {
            var httpServices = new HttpServices<TestUserModel>(_configuration);
            var testUserID = await httpServices.kullaniciOner();
            return testUserID;
        }


        /*------------------------------------------DTS---------------------------------------------*/

        public async Task<UpdatedInvoiceResponseModel> UpdateInvoice(FullInvoiceModel invoiceDetails)
        {
            return await UpdateInvoice(invoiceDetails, false);
        }

        public async Task<UpdatedInvoiceResponseModel> UpdateInvoice(FullInvoiceModel invoiceDetails, bool imza)
        {
            //TODO: FORM PARAMETRELERINDE SORUN VAR ??? NULL IFADELER VE BAZI DOUBLE IFADELER STRING E ÇEVİRİLMESİ GEREKİYOR !!!
            var data = new FullInvoiceUpdateModel()
            {
                faturaUuid = invoiceDetails.faturaUuid,
                belgeNumarasi = invoiceDetails.belgeNumarasi,
                aliciAdi = invoiceDetails.aliciAdi,
                aliciSoyadi = invoiceDetails.aliciSoyadi,
                aliciUnvan = invoiceDetails.aliciUnvan ?? "",
                faturaTarihi = invoiceDetails.faturaTarihi,
                saat = invoiceDetails.saat,
                vknTckn = invoiceDetails.vknTckn,
                vergiDairesi = invoiceDetails.vergiDairesi,
                matrah = invoiceDetails.matrah.ToString("F2").Replace(",", "."),
                malhizmetToplamTutari = invoiceDetails.malhizmetToplamTutari.ToString("F2").Replace(",", "."),
                hesaplanankdv = invoiceDetails.hesaplanankdv.ToString("F2").Replace(",", "."),
                vergilerToplami = invoiceDetails.vergilerToplami.ToString("F2").Replace(",", "."),
                vergilerDahilToplamTutar = invoiceDetails.vergilerDahilToplamTutar.ToString("F2").Replace(",", "."),
                odenecekTutar = invoiceDetails.odenecekTutar.ToString("F2").Replace(",", "."),
                bulvarcaddesokak = invoiceDetails.bulvarcaddesokak,

            };
            //data.iadeTable.Add(new UpdateIadeTable());

            data.not = Utils.Helpers
                .CurrencyToWordsTransformer(invoiceDetails.odenecekTutar, _configuration.Language, _configuration.Currency) + " EDITED :" + DateTime.Now.ToString();

            data.malHizmetTable.Add(new UpdateMalHizmetTable(invoiceDetails.malHizmetTable[0]));

            var command = new CreateDraftInvoiceCommand<UpdatedInvoiceResponseModel>(_configuration) { Data = data };

            UpdatedInvoiceResponseModel response = await command.Dispatch();

            return response;//return null; //
        }


        /*------------------------------------------DTS---------------------------------------------*/


        public async Task<DraftInvoiceResponseModel> CreateDraftInvoice(InvoiceDetailsModel invoiceDetails)
        {
            var data = new DraftInvoiceModel()
            {
                aliciAdi = invoiceDetails.name,
                aliciSoyadi = invoiceDetails.surname,
                aliciUnvan = invoiceDetails.title,
                faturaTarihi = invoiceDetails.date,
                saat = invoiceDetails.time,
                vknTckn = invoiceDetails.taxIDOrTRID,
                vergiDairesi = invoiceDetails.taxOffice,
                matrah = invoiceDetails.grandTotal.ToString("F2").Replace(",", "."),
                malhizmetToplamTutari = invoiceDetails.grandTotal.ToString("F2").Replace(",", "."),
                hesaplanankdv = invoiceDetails.totalVAT.ToString("F2").Replace(",", "."),
                vergilerToplami = invoiceDetails.totalVAT.ToString("F2").Replace(",", "."),
                vergilerDahilToplamTutar = invoiceDetails.grandTotalInclVAT.ToString("F2").Replace(",", "."),
                odenecekTutar = invoiceDetails.paymentTotal.ToString("F2").Replace(",", "."),
                bulvarcaddesokak = invoiceDetails.fullAddress
            };

            data.not = Utils.Helpers
                .CurrencyToWordsTransformer(invoiceDetails.paymentTotal, _configuration.Language, _configuration.Currency);
            for (int i = 0; i < invoiceDetails.items.Count; i++)
            {
                data.malHizmetTable.Add(new MalHizmetTableModel(invoiceDetails.items[i]));
            }

            var command = new CreateDraftInvoiceCommand<DraftInvoiceResponseModel>(_configuration) { Data = data };

            DraftInvoiceResponseModel response = await command.Dispatch();
            response.date = data.faturaTarihi;
            response.uuid = data.faturaUuid;

            return response;//return null; //
        }

        public async Task<FoundDraftInvoiceResponseModel> GetAllInvoicesByDateRange(DateTime start, DateTime end)
        {
            return await GetAllInvoicesByDateRange(start.ToString(DATE_FORMAT).Replace(".", "/"), end.ToString(DATE_FORMAT).Replace(".", "/"));
        }

        public async Task<FoundDraftInvoiceResponseModel> GetAllInvoicesByDateRange(string start, string end)
        {
            // InvoicesByDateRangeCommand
            var command = new InvoicesByDateRangeCommand<FoundDraftInvoiceResponseModel>(_configuration)
            {
                Data = new { baslangic = start, bitis = end, hangiTip = "5000/30000" }
            };

            FoundDraftInvoiceResponseModel response = await command.Dispatch();
            return response;
        }

        public async Task<FoundDraftInvoiceModel> FindDraftInvoice(DateTime date, string uuid)
        {
            return await FindDraftInvoice(date.ToString(DATE_FORMAT), uuid);
        }

        public async Task<FoundDraftInvoiceModel> FindDraftInvoice(string date, string uuid)
        {
            var invoices = await GetAllInvoicesByDateRange(date, date);
            for (int i = 0; i < invoices.data.Count; i++)
            {
                if (invoices.data[i].ettn == uuid)
                {
                    return invoices.data[i];
                }
            }
            return null;
        }

        public async Task<SignDraftInvoiceModel> SignDraftInvoice(FoundDraftInvoiceModel invoice)
        {
            var command = new SignDraftInvoiceCommand<SignDraftInvoiceModel>(_configuration)
            {
                Data = new { imzalanacaklar = invoice }
            };

            SignDraftInvoiceModel signedInvoice = await command.Dispatch();
            return signedInvoice;
        }

        public async Task<SignDraftInvoiceModel> SignDraftInvoice(FullInvoiceModel invoiceDetails)
        {
            FoundDraftInvoiceModel invoice = await FindDraftInvoice(invoiceDetails.faturaTarihi, invoiceDetails.faturaUuid);

            return await SignDraftInvoice(invoice);
        }

        /*------------------------------------------DTS---------------------------------------------*/



        public async Task<FullInvoiceModel> GetIncomingInvoices(DateTime start, DateTime end)
        {
            return await GetIncomingInvoices(start.ToString(DATE_FORMAT).Replace(".", "/"), end.ToString(DATE_FORMAT).Replace(".", "/"));
        }

        public async Task<FullInvoiceModel> GetIncomingInvoices(string start, string end)
        {
            // InvoicesByDateRangeCommand
            var command = new GetIncomingInvoiceCommand<FullInvoiceModel>(_configuration)
            {
                Data = new { baslangic = start, bitis = end }
            };

            FullInvoiceModel response = await command.Dispatch();
            return response;
        }

        /*------------------------------------------DTS---------------------------------------------*/

        public async Task<FullInvoiceResponseModel> GetInvFul(string uuid)
        {
            return await GetInvFul(uuid, true);
        }

        public async Task<FullInvoiceResponseModel> GetInvFul(string uuid, bool signed)
        {
            var command = new GetFullInvoiceCommand<FullInvoiceResponseModel>(_configuration)
            {
                Data = new { ettn = uuid, onayDurumu = signed ? "Onaylandı" : "Onaylanmadı" }
            };


            FullInvoiceResponseModel html = await command.Dispatch();
            return html;
        }


        /*---------------------------------------------------------------------------------------*/

        public async Task<GIBResponseModel<string>> GetInvoiceHTML(string uuid)
        {
            return await GetInvoiceHTML(uuid, true);
        }

        public async Task<GIBResponseModel<string>> GetInvoiceHTML(string uuid, bool signed)
        {
            var command = new GetInvoiceHTMLCommand<GIBResponseModel<string>>(_configuration)
            {
                Data = new { ettn = uuid, onayDurumu = signed ? "Onaylandı" : "Onaylanmadı" }
            };

            GIBResponseModel<string> html = await command.Dispatch();
            return html;
        }

        public string GetDownloadURL(string uuid, bool signed)
        {
            string signStatus = System.Web.HttpUtility.UrlEncode(signed ? "Onaylandı" : "Onaylanmadı");
            return $"{_configuration.BaseUrl}/earsiv-services/download?token={_configuration.Token}&ettn={uuid}&belgeTip=FATURA&onayDurumu={signStatus}&cmd=downloadResource";
        }



        public async Task<CreatedInvoiceModel> CreateInvoice(InvoiceDetailsModel invoiceDetails)
        {
            return await CreateInvoice(invoiceDetails, true);
        }

        public async Task<CreatedInvoiceModel> CreateInvoice(InvoiceDetailsModel invoiceDetails, bool signInvoice)
        {
            DraftInvoiceResponseModel draftInvoice = await CreateDraftInvoice(invoiceDetails);
            FoundDraftInvoiceModel invoice = await FindDraftInvoice(draftInvoice.date, draftInvoice.uuid);

            if (signInvoice) { await SignDraftInvoice(invoice); }

            return new CreatedInvoiceModel()
            {
                uuid = draftInvoice.uuid,
                signed = signInvoice
            };
        }

        public async Task<string> CreateInvoiceAndGetDownloadURL(InvoiceDetailsModel invoiceDetails, bool signInvoice)
        {
            CreatedInvoiceModel invoice = await CreateInvoice(invoiceDetails, signInvoice);
            return GetDownloadURL(invoice.uuid, invoice.signed);
        }

        public async Task<GIBResponseModel<string>> CreateInvoiceAndGetHTML(InvoiceDetailsModel invoiceDetails, bool signInvoice)
        {
            CreatedInvoiceModel invoice = await CreateInvoice(invoiceDetails, signInvoice);
            return await GetInvoiceHTML(invoice.uuid, invoice.signed);
        }

        public async Task<GIBResponseModel<string>> CancelDraftInvoice(FoundDraftInvoiceModel invoice, string reason)
        {
            // todo: determine the proper response type
            var command = new CancelDraftInvoiceCommand<GIBResponseModel<string>>(_configuration)
            {
                Data = new { silinecekler = invoice, aciklama = reason }
            };

            return await command.Dispatch();
        }

        public async Task<GIBResponseModel<RecipientModel>> GetRecipientDataByTaxIDOrTRID(long taxId)
        {
            var data = new { vknTcknn = taxId };
            var command = new GetRecipientDataByIDCommand<GIBResponseModel<RecipientModel>>(_configuration) { Data = data };

            return await command.Dispatch();
        }

        public async Task<GIBResponseModel<TelefonNoResponseModel>> telefonNoSorgula()
        {
            var command = new TelefonNoSorgulaCommand<GIBResponseModel<TelefonNoResponseModel>>(_configuration) { };
            GIBResponseModel<TelefonNoResponseModel> response = await command.Dispatch();
            return response;
        }

        public async Task<GIBResponseModel<SMSCodeResponseModel>> SendSignSMSCode(string phone)
        {
            var data = new { CEPTEL = phone, KCEPTEL = false, TIP = "" };
            var command = new SendSignSMSCodeCommand<GIBResponseModel<SMSCodeResponseModel>>(_configuration) { Data = data };

            GIBResponseModel<SMSCodeResponseModel> response = await command.Dispatch();
            return response;
        }



        public async Task<GIBResponseModel<SMSCodeResponseModel>> VerifySignSMSCode(FoundDraftInvoiceResponseModel draftInvoice, string smsCode, string oid)
        {
            //FoundDraftInvoiceResponseModel invoice = await FindDraftInvoice(draftInvoice.faturaTarihi, draftInvoice.faturaUuid);
            var data = new { SIFRE = smsCode, OID = oid, OPR = 1, DATA = draftInvoice };

            var command = new VerifySignSMSCodeCommand<GIBResponseModel<SMSCodeResponseModel>>(_configuration) { Data = data };

            GIBResponseModel<SMSCodeResponseModel> response = await command.Dispatch();
            return response;
        }

        public async Task<UserModel> GetUserData()
        {
            var command = new GetUserDataCommand<UserModelDTO>(_configuration) { Data = new { } };
            UserModelDTO response = await command.Dispatch();

            return new UserModel(response);
        }

        public async Task<UserModel> UpdateUserData(UserModel user)
        {
            var command = new UpdateUserDataCommand<UserModelDTO>(_configuration) { Data = user };
            UserModelDTO response = await command.Dispatch();

            return new UserModel(response);
        }
    }
}
