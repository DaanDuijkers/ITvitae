using Phoneshop.Domain;
using System.Diagnostics.CodeAnalysis;

namespace Phoneshop.Business.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class PhoneExtensions
    {
        public static double PriceWithVAT(this double price)
        {
            return price * 1.21;
        }

        public static double PriceWithoutVAT(this Phone phone)
        {
            return phone.Price / 1.21;
        }
    }
}