using System;
using Kowalsky.Controllers.Dtos;
using Kowalsky.Models;

namespace Kowalsky.Controllers.Sanitizers
{
    public class HomeSanitizer : IHomeSanitizer
    {
        public ContactInfo SanitizeContactInfo(ContactInfoDto dto)
        {
            if (dto == null)
            {
                throw new Exception("ContactInfo is null");
            }

            if (string.IsNullOrWhiteSpace(dto.Name))
            {
                throw new Exception("Name is empty");
            }

            if (string.IsNullOrWhiteSpace(dto.Email))
            {
                throw new Exception("Email is empty");
            }

            if (!IsValidEmail(dto.Email))
            {
                throw new Exception("Email is not valid");
            }

            if (string.IsNullOrWhiteSpace(dto.Phone))
            {
                throw new Exception("Phone is empty");
            }

            //if (!dto.DssAggreementAccepted)
            //{
            //    throw new Exception("Data security statement was not accepted");
            //}

            return new ContactInfo(dto.Name, dto.Email, dto.Phone, dto.Comment);
        }


        /// <summary>
        /// https://stackoverflow.com/questions/1365407/c-sharp-code-to-validate-email-address
        /// </summary>
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
