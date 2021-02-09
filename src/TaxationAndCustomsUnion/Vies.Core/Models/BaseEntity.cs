#region using

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;
using NetAppCommon;
using NetAppCommon.Helpers.Object;
using Newtonsoft.Json;

#endregion

namespace Vies.Core.Models
{
    public class BaseEntity : INotifyPropertyChanged
    {
        #region public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        ///     PropertyChangedEventHandler PropertyChanged
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region public void SetId(string s)

        /// <summary>
        ///     Ustaw identyfikator z dowolnego unikalnego ciągu znaków s
        ///     Set the identifier from any unique string s
        /// </summary>
        /// <param name="s">
        ///     Unikalny ciąg znaków s jako string
        ///     Unique string s as string
        /// </param>
        public void SetId(string s)
        {
            Id = new Guid();
            Id = ObjectHelper.GuidFromString(s);
        }

        #endregion

        #region public void SetUniqueIdentifierOfTheLoggedInUser()

        /// <summary>
        ///     Ustaw jednoznaczny identyfikator zalogowanego użytkownika
        ///     Set a unique identifier for the logged in user
        /// </summary>
        public void SetUniqueIdentifierOfTheLoggedInUser() => UniqueIdentifierOfTheLoggedInUser =
            HttpContextAccessor.AppContext.GetCurrentUserIdentityName();

        #endregion

        #region protected virtual void OnPropertyChanged(PropertyChangedEventArgs args)

        /// <summary>
        ///     protected virtual void OnPropertyChanged(PropertyChangedEventArgs args)
        /// </summary>
        /// <param name="args"></param>
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs args) => PropertyChanged?.Invoke(this, args);

        #endregion

        #region protected void OnPropertyChanged(string propertyName)

        /// <summary>
        ///     protected void OnPropertyChanged(string propertyName)
        /// </summary>
        /// <param name="propertyName"></param>
        protected void OnPropertyChanged(string propertyName) =>
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));

        //public static implicit operator Task<object>(CheckVat v)
        //{
        //    throw new NotImplementedException();
        //}

        #endregion

        #region private Guid _id; public Guid Id

        private Guid _id;

        /// <summary>
        ///     Guid Id identyfikator klucz główny
        ///     Guid Id identifier master key
        /// </summary>
        [XmlIgnore]
        [Key]
        [JsonProperty(nameof(Id))]
        [Display(Name = "Identyfikator w bazie danych", Prompt = "Wpisz identyfikator",
            Description = "Identyfikator klucz główny")]
        public Guid Id
        {
            get => _id;
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        #endregion

        #region private string _uniqueIdentifierOfTheLoggedInUser; public string UniqueIdentifierOfTheLoggedInUser

        private string _uniqueIdentifierOfTheLoggedInUser;

        /// <summary>
        ///     Jednoznaczny identyfikator zalogowanego użytkownika
        ///     Unique identifier of the logged in user
        /// </summary>
        [XmlIgnore]
        [JsonProperty(nameof(UniqueIdentifierOfTheLoggedInUser))]
        [Column(nameof(UniqueIdentifierOfTheLoggedInUser), TypeName = "varchar(512)")]
        [Display(Name = "Identyfikator zalogowanego użytkownika",
            Prompt = "Wybierz identyfikator zalogowanego użytkownika",
            Description = "Identyfikator zalogowanego użytkownika")]
        [StringLength(512)]
        [Required]
        public string UniqueIdentifierOfTheLoggedInUser
        {
            get => _uniqueIdentifierOfTheLoggedInUser;
            private set
            {
                if (_uniqueIdentifierOfTheLoggedInUser != value)
                {
                    _uniqueIdentifierOfTheLoggedInUser = value;
                    OnPropertyChanged(nameof(UniqueIdentifierOfTheLoggedInUser));
                }
            }
        }

        #endregion

        #region private DateTime _dateOfCreate; public DateTime DateOfCreate

        private DateTime _dateOfCreate;

        /// <summary>
        ///     Data utworzenia
        ///     Date of create
        /// </summary>
        [XmlIgnore]
        [JsonProperty(nameof(DateOfCreate))]
        [Column(nameof(DateOfCreate), TypeName = "datetime")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Display(Name = "Data Utworzenia", Prompt = "Wpisz lub wybierz datę utworzenia",
            Description = "Data utworzenia")]
        [DataType(DataType.Date)]
        public DateTime DateOfCreate
        {
            get => _dateOfCreate;
            set
            {
                if (_dateOfCreate != value)
                {
                    _dateOfCreate = value;
                    OnPropertyChanged(nameof(DateOfCreate));
                }
            }
        }

        #endregion

        #region private DateTime? _dateOfModification; public DateTime? DateOfModification

        private DateTime? _dateOfModification;

        /// <summary>
        ///     Data modyfikacji
        ///     Date of modification
        /// </summary>
        [XmlIgnore]
        [JsonProperty(nameof(DateOfModification))]
        [Column(nameof(DateOfModification), TypeName = "datetime")]
        [Display(Name = "Data Modyfikacji", Prompt = "Wpisz lub wybierz datę modyfikacji",
            Description = "Data modyfikacji")]
        [DataType(DataType.Date)]
        public DateTime? DateOfModification
        {
            get => _dateOfModification;
            set
            {
                if (_dateOfModification != value)
                {
                    _dateOfModification = value;
                    OnPropertyChanged(nameof(DateOfModification));
                }
            }
        }

        #endregion
    }
}
