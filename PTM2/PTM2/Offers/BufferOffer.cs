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

        public BufferOffer(ObservableCollection<BaseEquipment> offereq)
        {
            OfferList = offereq.ToList();
            BufferMessage = "";
            foreach (var item in OfferList)
            {
                BufferMessage += item.FullName + "\n";
                BufferMessage += item.Description + "\n";
                BufferMessage += "Цена " + ((int)item.Price).ToString() + " Евро с НДС. \n";
                BufferMessage += "\n";
            }

        }
        string bufferMessage;

        public string BufferMessage { get => bufferMessage; set => bufferMessage = value; }
        public List<BaseEquipment> OfferList { get => offerList; set => offerList = value; }
    }
}
