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
        public BufferOffer(ObservableCollection<BaseEquipment> offerList)
        {

        }
        string bufferMessage;

        public string BufferMessage { get => bufferMessage; set => bufferMessage = value; }
    }
}
