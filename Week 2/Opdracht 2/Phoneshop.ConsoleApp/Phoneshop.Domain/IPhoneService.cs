using System;
using System.Collections.Generic;

namespace Phoneshop.Domain
{
    public interface IPhoneService
    {
        void Create(Phone phone);
        List<Phone> ReadAll();
        Phone Read(int id);
    }
}