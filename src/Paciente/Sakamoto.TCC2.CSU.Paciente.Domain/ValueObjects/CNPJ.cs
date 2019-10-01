using Sakamoto.TCC2.CSU.Domain.Core.Models;

namespace Sakamoto.TCC2.CSU.Patients.Domain.ValueObjects
{
    public class CNPJ : ValueObject<CNPJ>
    {
        public CNPJ(string cnpj)
        {
            Cnpj = cnpj;
        }

        public string Cnpj { get; private set; }

        public bool IsValid()
        {
            var multiplier1 = new int[12] {5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2};
            var multiplier2 = new int[13] {6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2};

            Cnpj = Cnpj.Trim().Replace(".", "").Replace("-", "").Replace("/", "");
            if (Cnpj.Length != 14)
                return false;

            var hasCnpj = Cnpj.Substring(0, 12);
            var sum = 0;

            for (var i = 0; i < 12; i++)
                sum += int.Parse(hasCnpj[i].ToString()) * multiplier1[i];

            var rest = sum % 11;
            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            var digit = rest.ToString();
            hasCnpj += digit;
            sum = 0;
            for (var i = 0; i < 13; i++)
                sum += int.Parse(hasCnpj[i].ToString()) * multiplier2[i];

            rest = sum % 11;
            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            digit += rest.ToString();

            return Cnpj.EndsWith(digit);
        }
    }
}