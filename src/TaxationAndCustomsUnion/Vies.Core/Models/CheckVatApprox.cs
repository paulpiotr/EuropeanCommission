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
    [XmlRoot("checkVatApproxResponse")]
    [Table("CheckVatApprox", Schema = "etvc")]
    public class CheckVatApprox : BaseEntity, INotifyPropertyChanged
    {
        #region public CheckVat()

        /// <summary>
        ///     Konstruktor
        ///     Construktor
        /// </summary>
        public CheckVatApprox()
        {
            SetUniqueIdentifierOfTheLoggedInUser();
        }

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

        #region private string _traderName; public string TraderName

        private string _traderName;

        [XmlElement(ElementName = "traderName")]
        [JsonProperty(nameof(TraderName))]
        [Column(nameof(TraderName), TypeName = "varchar(128)")]
        [Display(Name = "Atrybut TraderName", Prompt = "Wpisz atrybut TraderName", Description = "Atrybut TraderName")]
        [Required]
        [StringLength(256)]
        public string TraderName
        {
            get => _traderName;
            set
            {
                if (value != _traderName)
                {
                    _traderName = value;
                    OnPropertyChanged(nameof(TraderName));
                }
            }
        }

        #endregion

        #region private string _traderCompanyType; public string TraderCompanyType

        private string _traderCompanyType;

        /// <summary>
        ///     [A-Z]{2}\-[1-9][0-9]?
        /// </summary>
        [XmlElement(ElementName = "traderCompanyType")]
        [JsonProperty(nameof(TraderCompanyType))]
        [Column(nameof(TraderCompanyType), TypeName = "varchar(16)")]
        [Display(Name = "Atrybut TraderCompanyType", Prompt = "Wpisz atrybut TraderCompanyType",
            Description = "Atrybut TraderCompanyType")]
        [Required]
        [StringLength(256)]
        public string TraderCompanyType
        {
            get => _traderCompanyType;
            set
            {
                if (value != _traderCompanyType)
                {
                    _traderCompanyType = value;
                    OnPropertyChanged(nameof(TraderCompanyType));
                }
            }
        }

        #endregion

        #region private string _traderAddress; public string TraderAddress

        private string _traderAddress;

        [XmlElement(ElementName = "traderAddress")]
        [JsonProperty(nameof(TraderAddress))]
        [Column(nameof(TraderAddress), TypeName = "varchar(256)")]
        [Display(Name = "Atrybut TraderAddress", Prompt = "Wpisz atrybut TraderAddress",
            Description = "Atrybut TraderAddress")]
        [Required]
        [StringLength(256)]
        public string TraderAddress
        {
            get => _traderAddress;
            set
            {
                if (value != _traderAddress)
                {
                    _traderAddress = value;
                    OnPropertyChanged(nameof(TraderAddress));
                }
            }
        }

        #endregion

        #region private string _traderStreet; public string TraderStreet

        private string _traderStreet;

        [XmlElement(ElementName = "traderStreet")]
        [JsonProperty(nameof(TraderStreet))]
        [Column(nameof(TraderStreet), TypeName = "varchar(64)")]
        [Display(Name = "Atrybut TraderStreet", Prompt = "Wpisz atrybut TraderStreet",
            Description = "Atrybut TraderStreet")]
        [StringLength(64)]
        public string TraderStreet
        {
            get => _traderStreet;
            set
            {
                if (value != _traderStreet)
                {
                    _traderStreet = value;
                    OnPropertyChanged(nameof(TraderStreet));
                }
            }
        }

        #endregion

        #region private string _traderPostcode; public string TraderPostcode

        private string _traderPostcode;

        [XmlElement(ElementName = "traderPostcode")]
        [JsonProperty(nameof(TraderPostcode))]
        [Column(nameof(TraderPostcode), TypeName = "varchar(32)")]
        [Display(Name = "Atrybut TraderPostcode", Prompt = "Wpisz atrybut TraderPostcode",
            Description = "Atrybut TraderPostcode")]
        [StringLength(32)]
        public string TraderPostcode
        {
            get => _traderPostcode;
            set
            {
                if (value != _traderPostcode)
                {
                    _traderPostcode = value;
                    OnPropertyChanged(nameof(TraderPostcode));
                }
            }
        }

        #endregion

        #region private string _traderCity; public string TraderCity

        private string _traderCity;

        [XmlElement(ElementName = "traderCity")]
        [JsonProperty(nameof(TraderCity))]
        [Column(nameof(TraderCity), TypeName = "varchar(64)")]
        [Display(Name = "Atrybut TraderCity", Prompt = "Wpisz atrybut TraderCity", Description = "Atrybut TraderCity")]
        [StringLength(64)]
        public string TraderCity
        {
            get => _traderCity;
            set
            {
                if (value != _traderCity)
                {
                    _traderCity = value;
                    OnPropertyChanged(nameof(TraderCity));
                }
            }
        }

        #endregion

        #region private ushort _traderNameMatch; public ushort TraderNameMatch

        private ushort _traderNameMatch;

        [XmlElement(ElementName = "traderNameMatch")]
        [JsonProperty(nameof(TraderNameMatch))]
        [Column(nameof(TraderNameMatch), TypeName = "smallint")]
        [Display(Name = "Atrybut TraderNameMatch", Prompt = "Wpisz atrybut TraderNameMatch",
            Description = "Atrybut TraderNameMatch")]
        [Range(ushort.MinValue, ushort.MaxValue)]
        public ushort TraderNameMatch
        {
            get => _traderNameMatch;
            set
            {
                if (value != _traderNameMatch)
                {
                    _traderNameMatch = value;
                    OnPropertyChanged(nameof(TraderNameMatch));
                }
            }
        }

        #endregion

        #region private ushort _traderCompanyTypeMatch; public ushort TraderCompanyTypeMatch

        private ushort _traderCompanyTypeMatch;

        [XmlElement(ElementName = "traderCompanyTypeMatch")]
        [JsonProperty(nameof(TraderCompanyTypeMatch))]
        [Column(nameof(TraderCompanyTypeMatch), TypeName = "smallint")]
        [Display(Name = "Atrybut TraderCompanyTypeMatch", Prompt = "Wpisz atrybut TraderCompanyTypeMatch",
            Description = "Atrybut TraderCompanyTypeMatch")]
        [Range(ushort.MinValue, ushort.MaxValue)]
        public ushort TraderCompanyTypeMatch
        {
            get => _traderCompanyTypeMatch;
            set
            {
                if (value != _traderCompanyTypeMatch)
                {
                    _traderCompanyTypeMatch = value;
                    OnPropertyChanged(nameof(TraderCompanyTypeMatch));
                }
            }
        }

        #endregion

        #region private ushort _traderStreetMatch; public ushort TraderStreetMatch

        private ushort _traderStreetMatch;

        [XmlElement(ElementName = "traderStreetMatch")]
        [JsonProperty(nameof(TraderStreetMatch))]
        [Column(nameof(TraderStreetMatch), TypeName = "smallint")]
        [Display(Name = "Atrybut TraderStreetMatch", Prompt = "Wpisz atrybut TraderStreetMatch",
            Description = "Atrybut TraderStreetMatch")]
        [Range(ushort.MinValue, ushort.MaxValue)]
        public ushort TraderStreetMatch
        {
            get => _traderStreetMatch;
            set
            {
                if (value != _traderStreetMatch)
                {
                    _traderStreetMatch = value;
                    OnPropertyChanged(nameof(TraderStreetMatch));
                }
            }
        }

        #endregion

        #region private ushort _traderPostcodeMatch; public ushort TraderPostcodeMatch

        private ushort _traderPostcodeMatch;

        [XmlElement(ElementName = "traderPostcodeMatch")]
        [JsonProperty(nameof(TraderPostcodeMatch))]
        [Column(nameof(TraderPostcodeMatch), TypeName = "smallint")]
        [Display(Name = "Atrybut TraderPostcodeMatch", Prompt = "Wpisz atrybut TraderPostcodeMatch",
            Description = "Atrybut TraderPostcodeMatch")]
        [Range(ushort.MinValue, ushort.MaxValue)]
        public ushort TraderPostcodeMatch
        {
            get => _traderPostcodeMatch;
            set
            {
                if (value != _traderPostcodeMatch)
                {
                    _traderPostcodeMatch = value;
                    OnPropertyChanged(nameof(TraderPostcodeMatch));
                }
            }
        }

        #endregion

        #region private ushort _traderCityMatch; public ushort TraderCityMatch

        private ushort _traderCityMatch;

        [XmlElement(ElementName = "traderCityMatch")]
        [JsonProperty(nameof(TraderCityMatch))]
        [Column(nameof(TraderCityMatch), TypeName = "smallint")]
        [Display(Name = "Atrybut TraderCityMatch", Prompt = "Wpisz atrybut TraderCityMatch",
            Description = "Atrybut TraderCityMatch")]
        [Range(ushort.MinValue, ushort.MaxValue)]
        public ushort TraderCityMatch
        {
            get => _traderCityMatch;
            set
            {
                if (value != _traderCityMatch)
                {
                    _traderCityMatch = value;
                    OnPropertyChanged(nameof(TraderCityMatch));
                }
            }
        }

        #endregion

        #region private string _requestIdentifier; public string RequestIdentifier

        private string _requestIdentifier;

        [XmlElement(ElementName = "requestIdentifier")]
        [JsonProperty(nameof(RequestIdentifier))]
        [Column(nameof(RequestIdentifier), TypeName = "varchar(16)")]
        [Display(Name = "Atrybut RequestIdentifier", Prompt = "Wpisz atrybut RequestIdentifier",
            Description = "Atrybut RequestIdentifier")]
        [Required]
        [StringLength(16)]
        [MinLength(16)]
        [MaxLength(16)]
        public string RequestIdentifier
        {
            get => _requestIdentifier;
            set
            {
                if (value != _requestIdentifier)
                {
                    _requestIdentifier = value;
                    OnPropertyChanged(nameof(RequestIdentifier));
                }
            }
        }

        #endregion
    }
}
