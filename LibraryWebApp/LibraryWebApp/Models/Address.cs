using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWebApp.Models
{
    public class Address : IValidatableObject
    {
        public int AddressId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Street { get; set; }

        [Required]
        [Range(1, 999, ErrorMessage = "Building's number must be between 1 to 999.")]
        [DisplayName("Building's number")]
        public int BuildingNr { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string City { get; set; }

        public Address()
        {
        }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (City == "Gdansk" && Street == "Jagiellonska" && (BuildingNr<15 || BuildingNr>25))
            {
                yield return new ValidationResult(
                    "Jagiellonska street in Gdansk has only bulding numbers in the range of 15-25.",
                    new[] { nameof(BuildingNr) });
            }
        }
        public string FullAddress
        {
            get
            {
                return this.Street + " " + this.BuildingNr + ", " + this.City;
            }
        }
    }
}
