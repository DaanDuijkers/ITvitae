using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoneshop.Business
{
    public class PhoneService
    {
        private List<Phone> phones = new();

        public void Create(Phone phone)
        {
            this.phones.Add(phone);
        }

        public List<Phone> ReadAll ()
        {
            return this.phones;
        }

        public Phone Read (int id)
        {
            return phones.Find(x => x.Id == id);
        }
    }
}