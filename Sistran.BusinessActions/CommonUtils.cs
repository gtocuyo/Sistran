using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Sistran.BusinessActions
{
    public class CommonUtils
    {
        public static bool SoloCaracteresAlfanumericos(string names)
        {
            return Regex.IsMatch(names, @"^[a-zA-Z0-9]*$");
        }

        public static bool SoloCaracteresAlfabeticosYLatinos(string names)
        {
            return Regex.IsMatch(names, @"^[\p{L}\p{M}' \.\-]+$");
        }

        public static bool ValidaListaEmail(List<string> emailAddresses)
        {
            bool result = true;

            foreach(string email in emailAddresses)
            {
                result = Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
                
                if (!result)
                    break;
            }

            return result;
        }

        public static bool ValidaListaTelefono(List<string> phoneNumbers)
        {
            bool result = true;

            foreach (string phone in phoneNumbers)
            {
                result = Regex.IsMatch(phone, @"^\d+$", RegexOptions.IgnoreCase);

                if (!result)
                    break;
            }

            return result;
        }
    }

}
