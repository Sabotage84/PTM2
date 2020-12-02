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

        public BufferOffer(ObservableCollection<BaseEquipment> offereq)
        {
            OfferList = offereq.ToList();
            Header = "Здравствуйте, ";
            Footer = @"Оборудование марки Метроном производит / поставляет (продает),
обеспечивает гарантийную, постгарантийную и сервисную поддержку,
а также является держателем всех сертификатов на оборудование
только компания Прайм Тайм.";
            BufferMessage = "";
            BufferMessage += Header + "\n\n";
            foreach (var item in OfferList)
            {

                BufferMessage += item.FullName + "\n";
                BufferMessage += item.Description + "\n";
                BufferMessage += "Цена " + ((int)item.Price).ToString() + " Евро с НДС. \n";
                BufferMessage += "\n";
            }
            BufferMessage += Footer;

        }
        string bufferMessage;

        public string BufferMessage { get => bufferMessage; set => bufferMessage = value; }
        public List<BaseEquipment> OfferList { get => offerList; set => offerList = value; }
        public string Header { get => header; set => header = value; }
        public string Footer { get => footer; set => footer = value; }
    }
}
