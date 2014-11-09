using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace InternetShop.Models.Shop.Entities
{
    [Table("Persons")]
    public class Person
    {
        private const string PhoneRegex = @"^(\+97[\s]{0,1}[\-]{0,1}[\s]{0,1}1|0)50[\s]{0,1}[\-]{0,1}[\s]{0,1}[1-9]{1}[0-9]{6}$";

        [Key]
        public string UserName { get; set; }
        [DisplayName("Имя")]
        [Required(ErrorMessage="Обязательный параметр")]
        public string Name { get; set; }
        [DisplayName("Фамилия")]
        public string Surname { get; set; }
        [DisplayName("Телефон")]
        [Required(ErrorMessage = "Обязательный параметр")]
        public string Phone { get; set; }

        public List<KeyValuePair<string, string>> Validate()
        {
            var result = new List<KeyValuePair<string, string>>();
            return result;
            if (!string.IsNullOrEmpty(Phone) && !Regex.IsMatch(Phone, PhoneRegex))
            {
                result.Add(new KeyValuePair<string, string>("Phone", "Не правильный формат телефонного номера"));
            }
            
        }
    }
}