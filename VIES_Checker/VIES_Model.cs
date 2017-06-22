using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace VIES_Checker
{
    class VIES_Model
    {
        //input
        public string countryCode;
        public string vatNumber;
        public string requesterCountryCode;
        public string requesterVatNumber;

        //io's
        public string traderName = "";

        public string traderCompanyType = "";
        public string traderStreet = "";
        public string traderPostcode = "";
        public string traderCity = "";

        //outputs
        public bool valid;
        public string requestIdentifier;
        public DateTime requestDate;
        public string traderAddress;

        public VIES_Model(string countryCode, string vatNumber)
        {
            this.countryCode = countryCode;
            this.vatNumber = vatNumber;
        }

        public void getDetailVAT()
        {
            eu.europa.ec.checkVatService checkVatService = new eu.europa.ec.checkVatService();
            requestDate = checkVatService.checkVat(ref countryCode, ref vatNumber, out valid, out traderName, out traderAddress);

        }


        public void getDetailVATWithVerification(string requesterCountryCode, string requesterVatNumber)
        {
            this.requesterCountryCode = requesterCountryCode;
            this.requesterVatNumber = requesterVatNumber;
            eu.europa.ec.checkVatService checkVatService = new eu.europa.ec.checkVatService();

            requestDate = checkVatService.checkVatApprox(ref countryCode, ref vatNumber, ref traderName, ref traderCompanyType, ref traderStreet,
                ref traderPostcode, ref traderCity, requesterCountryCode, requesterVatNumber, out valid, out traderAddress, out _, out bool traderNameMatchSpecified,
                out _, out bool traderCompanyTypeMatchSpecified, out _, out bool traderStreetMatchSpecified, out _, out bool traderPostcodeMatchSpecified, out _, out bool traderCirtyMatchSpecified, out requestIdentifier);


        }

        public void PrintInConsole()
        {
            Console.WriteLine("Trader Info:");
            Console.WriteLine(traderName + traderCompanyType + traderAddress);

            Console.WriteLine("Request Info:");
            Console.WriteLine(requestDate.ToLongDateString() + "\n" +  requestIdentifier);

            Console.ReadKey();
        }
    }
}
