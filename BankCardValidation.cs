using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace DeveloperAssistant
{
    public enum Banks
    {
        Melli = "بانک ملی ایران",
        Sepah = "بانک سپه",
        TosehSaderat = "بانک توسعه صادرات",
        SanaatVaMaadan = "بانک صنعت و معدن",
        BankKeshavarzi = "بانک کشاورزی",
        BankMaskan = "بانک مسکن",
       PostBank= "پست بانک ایران",
        TosehTaavon= "بانک توسعه تعاون",
        EghtesadNovin=  "بانک اقتصاد نوین",
       Parsian= "بانک پارسیان",
       Pasargad= "بانک پاسارگاد",
        Ghavamin = "بانک قوامین",
        Karafarin ="بانک کارآفرین",
        Saman="بانک سامان",
       Sina= "بانک سینا",
        Sarmayeh = "بانک سرمایه",
        Shahr ="بانک شهر",
       Day= "بانک دی",
        Saderat = "بانک صادرات",
        Mellat=  "بانک ملت",
        Tejarat = "بانک تجارت",
        Refah = "بانک رفاه",
        Ansar="بانک انصار",
        MehrEqtesad=  "بانک مهر اقتصاد",
        CreditInstitutionNoor = "موسسه اعتباری نور",
        CreditInstitutionToseh="موسسه اعتباری توسعه",
        CreditInstitutionKosar= "موسسه اعتباری کوثر",
        CreditInstitutionMelal= "موسسه اعتباری ملل (عسکریه",
        CreditInstitutionMehrIranian="بانک قرض الحسنه مهرایرانیان"
    }


    public class BankCardValidation
    {
        public static bool CheckCardValidation(string card)
        {
            //Regex Pattern To Select Just Digit's
            card = Regex.Replace(card, @"\D", "");

            if (card.Length != 16)
            {
                return false;
            }

            var cardTypes = new[] { '4', '5', '6', '9', '2' };
            if (cardTypes.Contains(card[0]) == false)
            {
                return false;
            }

            int sum = 0;
            for (int i = 0; i < card.Length; i++)
            {
                if ((i % 2) == 1)
                { //اعداد فرد شماره کارت با ضریب 2
                    int res = card[i] * 2;

                    //اگر نتیجه دو رقمی باشد 9 را از حاصل کم می‌کنیم
                    if (res > 9)
                    {
                        res -= 9;
                    }

                    sum += res;
                }
                else
                {//اعداد زوج شماره کارت با ضریب یک
                    sum += card[i];
                }
            }

            return sum % 10 == 0 ? true : false;
        }

        public static string GetBankName(string card)
        {
            //Regex Pattern To Select Just Digit's
            card = Regex.Replace(card, @"\D", "");

            Dictionary<string, string> banksPrefix = new Dictionary<string, Banks>();
            banksPrefix.Add("603799", Banks.Melli);
            banksPrefix.Add("589210", Banks.Sepah);
            banksPrefix.Add("627648", Banks.TosehSaderat);
            banksPrefix.Add("627961", Banks.SanaatVaMaadan);
            banksPrefix.Add("603770", Banks.BankKeshavarzi);
            banksPrefix.Add("628023", Banks.BankMaskan);
            banksPrefix.Add("627760", Banks.PostBank);
            banksPrefix.Add("502908", Banks.TosehTaavon);
            banksPrefix.Add("207177", Banks.TosehSaderat);
            banksPrefix.Add("627412", Banks.EghtesadNovin);
            banksPrefix.Add("622106", Banks.Parsian);
            banksPrefix.Add("502229", Banks.Pasargad);
            banksPrefix.Add("639599", Banks.Ghavamin);
            banksPrefix.Add("627488", Banks.Karafarin);
            banksPrefix.Add("621986", Banks.Saman);
            banksPrefix.Add("639346", Banks.Sina);
            banksPrefix.Add("639607", Banks.Sarmayeh);
            banksPrefix.Add("502806", Banks.Shahr);
            banksPrefix.Add("504706", Banks.Shahr);
            banksPrefix.Add("502938", Banks.Day);
            banksPrefix.Add("603769", Banks.Saderat);
            banksPrefix.Add("610433", Banks.Mellat);
            banksPrefix.Add("991975", Banks.Mellat);
            banksPrefix.Add("627353", Banks.Tejarat);
            banksPrefix.Add("585983", Banks.Tejarat);
            banksPrefix.Add("589463", Banks.Refah);
            banksPrefix.Add("627381", Banks.Ansar);
            banksPrefix.Add("639370", Banks.MehrEqtesad);
            banksPrefix.Add("507677", Banks.CreditInstitutionNoor);
            banksPrefix.Add("628157", Banks.CreditInstitutionToseh);
            banksPrefix.Add("505801", Banks.CreditInstitutionKosar);
            banksPrefix.Add("606256", Banks.CreditInstitutionMelal);
            banksPrefix.Add("606373", Banks.CreditInstitutionMehrIranian);

            string cardPrefix = card.Substring(0, 6);

            return banksPrefix.First(x => cardPrefix.StartsWith(x.Key)).Value;
        }


    }
}
