using PTM2.equipment;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTM2.Offers
{
    class BufferOffer
    {
        List<BaseEquipment> offerList = new List<BaseEquipment>();
        string header;
        string footer;
        string explainPoverka;

        public BufferOffer(ObservableCollection<BaseEquipment> offereq)
        {
            OfferList = offereq.ToList();
            Header = "Здравствуйте, ";
            Footer = @"Оборудование марки Метроном производит / поставляет (продает),
обеспечивает гарантийную, постгарантийную и сервисную поддержку,
а также является держателем всех сертификатов на оборудование
только компания Прайм Тайм.";
            ExplainPoverka = @"
Примечание:
В зависимости от сферы применения оборудование может поставляться с
определенными опциями (начиная с версии Метроном-300).
Опции устанавливаются только при заказе оборудования.
Особенно это важно, если нужна поверка
http://www.ptime.ru/si.html
(меняется название оборудования и обязательное использование опционного
внутреннего генератора OCXO-HQ).
Ознакомьтесь, пожалуйста, с памяткой:
http://www.ptime.ru/Downloads/pamyatka_Metronom.pdf


В качестве примера, если нужен Метроном-300 с поверкой, то это будет:
Устройство синхронизации частоты и времени Метроном-300/GNS-HQ
2 x NTP LAN Ethernet 10/100, RJ45; 2xRS232, 1x10МГц (TTL), 1x1PPS, генератор
OCXO-HQ, эл.пит. ~220В.
6350 Евро с НДС.
Антенна ГЛОНАСС/GPS со встроенным грозоразрядником.
435 Евро с НДС.
Антенный кабель 50 м.
140 Евро с НДС.
Организация поверки (получение свидетельства о поверке)
600 Евро с НДС.

http://www.ptime.ru/Metronom/si/Metronom300si.html
Оплата в рублях по курсу ЦБ.
Склад Москва 14-16 недель (12 недель + 2-4 недели поверка).
3 года гарантии. (Расширение гарантии до 5 лет +20% к стоимости)
Паспорт на изделие. Декларация соответствия ТС (EAC). Свидетельство о поверке.";

            BufferMessage = "";
            BufferMessage += Header + "\n\n";
            BufferMessage += CreateOfferFromList(OfferList);

            BufferMessage += ExplainPoverka;
            BufferMessage += Footer;

        }

        private string CreateOfferFromList(List<BaseEquipment> lst)
        {
            string res = "";
            foreach (var item in lst)
            {

                res += item.FullName + "\n";
                res += item.Description + "\n";
                res += "Цена " + ((int)item.Price).ToString() + " Евро с НДС. \n";
                res += "\n";
            }
            return res;
        }

        string bufferMessage;

        public string BufferMessage { get => bufferMessage; set => bufferMessage = value; }
        public List<BaseEquipment> OfferList { get => offerList; set => offerList = value; }
        public string Header { get => header; set => header = value; }
        public string Footer { get => footer; set => footer = value; }
        public string ExplainPoverka { get => explainPoverka; set => explainPoverka = value; }
    }
}
