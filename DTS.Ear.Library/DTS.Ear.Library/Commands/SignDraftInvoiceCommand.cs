﻿using DTS.Ear.Library.Configuration;

namespace DTS.Ear.Library.Commands
{
    public class SignDraftInvoiceCommand<T> : CommandDispatcherBase<T>
    {
        public SignDraftInvoiceCommand(IFaturaServiceConfiguration configuration) : base(configuration)
        {
            CommandName = "EARSIV_PORTAL_FATURA_HSM_CIHAZI_ILE_IMZALA";
            PageName = "RG_BASITTASLAKLAR";
        }
    }
}
