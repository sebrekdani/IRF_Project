using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IRF_Project
{
    public class LoginController
    {
        public void Controller(string email,string password)
        {
            if (!ValidateEmail(email)) throw new ValidationException("A megadott e-mail cím nem megfelelő!");
            if (!ValidatePassword(password)) throw new ValidationException("A megadott jelszó nem megfelelő!");
        }
        public bool ValidateEmail(string email)
        {
            return Regex.IsMatch(
                email,
                @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?");
        }
        public bool ValidatePassword(string password)
        {
            var containsSmallCharacters = new Regex(@"[a-z]+");
            var containsCapitalCharacters = new Regex(@"[A-Z]+");
            var containsNumber = new Regex(@"[0-9]+");
            var minCharacter = new Regex(@".{8,}");

            if (!containsSmallCharacters.IsMatch(password))
            {
                return false;
            }
            if (!containsCapitalCharacters.IsMatch(password))
            {
                return false;
            }
            if (!containsNumber.IsMatch(password))
            {
                return false;
            }
            if (!minCharacter.IsMatch(password))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
