using Sakamoto.TCC2.CSU.Domain.Core.Models;

namespace Sakamoto.TCC2.CSU.Patients.Domain.ValueObjects
{
    public class CPF : ValueObject<CPF>
    {
        public CPF(string cpf)
        {
            Cpf = cpf;
        }

        public string Cpf { get; private set; }

        public bool IsValid()
        {
            var multiplier1 = new int[9] {10, 9, 8, 7, 6, 5, 4, 3, 2};
            var multiplier2 = new int[10] {11, 10, 9, 8, 7, 6, 5, 4, 3, 2};

            Cpf = Cpf.Trim().Replace(".", "").Replace("-", "");
            if (Cpf.Length != 11)
                return false;

            for (var j = 0; j < 10; j++)
                if (j.ToString().PadLeft(11, char.Parse(j.ToString())) == Cpf)
                    return false;

            var hasCpj = Cpf.Substring(0, 9);
            var sum = 0;

            for (var i = 0; i < 9; i++)
                sum += int.Parse(hasCpj[i].ToString()) * multiplier1[i];

            var rest = sum % 11;
            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            var digit = rest.ToString();
            hasCpj += digit;
            sum = 0;
            for (var i = 0; i < 10; i++)
                sum += int.Parse(hasCpj[i].ToString()) * multiplier2[i];

            rest = sum % 11;
            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            digit += rest.ToString();

            return Cpf.EndsWith(digit);
        }
    }
}