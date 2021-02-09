#region using

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;
using Newtonsoft.Json;

#endregion

namespace Vies.Core.Models
{
    [Serializable]
    [XmlRoot("checkVatResponse")]
    [Table("CheckVat", Schema = "etvc")]
    public class CheckVat : BaseEntity, INotifyPropertyChanged
    {
        #region public CheckVat()

        /// <summary>
        ///     Konstruktor
        ///     Construktor
        /// </summary>
        public CheckVat()
        {
            SetUniqueIdentifierOfTheLoggedInUser();
        }

        #endregion

        #region private new void OnPropertyChanged(string propertyName)

        /// <summary>
        ///     private new void OnPropertyChanged(string propertyName)
        /// </summary>
        /// <param name="propertyName"></param>
        private new void OnPropertyChanged(string propertyName) =>
            //OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
            base.OnPropertyChanged(new PropertyChangedEventArgs(propertyName));

        #endregion

        #region private string _countryCode; public string CountryCode

        private string _countryCode;

        [XmlElement(ElementName = "countryCode")]
        [JsonProperty(nameof(CountryCode))]
        [Column(nameof(CountryCode), TypeName = "varchar(8)")]
        [Display(Name = "Atrybut CountryCode", Prompt = "Wpisz atrybut CountryCode",
            Description = "Atrybut CountryCode")]
        [Required]
        [StringLength(8)]
        public string CountryCode
        {
            get => _countryCode;
            set
            {
                if (value != _countryCode)
                {
                    _countryCode = value;
                    OnPropertyChanged(nameof(CountryCode));
                }
            }
        }

        #endregion

        #region private string _vatNumber; public string VatNumber

        private string _vatNumber;

        [XmlElement(ElementName = "vatNumber")]
        [JsonProperty(nameof(VatNumber))]
        [Column(nameof(VatNumber), TypeName = "varchar(16)")]
        [Display(Name = "Atrybut VatNumber", Prompt = "Wpisz atrybut VatNumber", Description = "Atrybut VatNumber")]
        [Required]
        [StringLength(16)]
        public string VatNumber
        {
            get => _vatNumber;
            set
            {
                if (value != _vatNumber)
                {
                    _vatNumber = value;
                    OnPropertyChanged(nameof(VatNumber));
                }
            }
        }

        #endregion

        #region private string _requestDate; public string RequestDate

        private DateTime _requestDate;

        [XmlElement(ElementName = "requestDate")]
        [JsonProperty(nameof(RequestDate))]
        [Column(nameof(RequestDate), TypeName = "datetime")]
        [Display(Name = "Atrybut RequestDate", Prompt = "Wpisz atrybut RequestDate",
            Description = "Atrybut RequestDate")]
        [Required]
        [DataType(DataType.Date)]

        public DateTime RequestDate
        {
            get => _requestDate;
            set
            {
                if (value != _requestDate)
                {
                    _requestDate = value;
                    OnPropertyChanged(nameof(RequestDate));
                }
            }
        }

        #endregion

        #region private string _valid; public string Valid

        private bool _valid;

        [XmlElement(ElementName = "valid")]
        [JsonProperty(nameof(Valid))]
        [Column(nameof(Valid), TypeName = "bit")]
        [Display(Name = "Atrybut Valid", Prompt = "Wpisz atrybut Valid", Description = "Atrybut Valid")]
        [Required]

        public bool Valid
        {
            get => _valid;
            set
            {
                if (value != _valid)
                {
                    _valid = value;
                    OnPropertyChanged(nameof(Valid));
                }
            }
        }

        #endregion

        #region private string _name; public string Name

        private string _name;

        [XmlElement(ElementName = "name")]
        [JsonProperty(nameof(Name))]
        [Column(nameof(Name), TypeName = "varchar(128)")]
        [Display(Name = "Atrybut Name", Prompt = "Wpisz atrybut Name", Description = "Atrybut Name")]
        [Required]
        [StringLength(128)]
        public string Name
        {
            get => _name;
            set
            {
                if (value != _name)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        #endregion

        #region private string _address; public string Address

        private string _address;

        [XmlElement(ElementName = "address")]
        [JsonProperty(nameof(Address))]
        [Column(nameof(Address), TypeName = "varchar(256)")]
        [Display(Name = "Atrybut Address", Prompt = "Wpisz atrybut Address", Description = "Atrybut Address")]
        [Required]
        [StringLength(256)]
        public string Address
        {
            get => _address;
            set
            {
                if (value != _address)
                {
                    _address = value;
                    OnPropertyChanged(nameof(Address));
                }
            }
        }

        #endregion
    }
}
