using System.ComponentModel.DataAnnotations;
using LocalInformationSystem.Web.Common;

namespace LocalInformationSystem.Web.ViewModels
{
    /// <summary>
    ///  Park view model.
    /// </summary>
    public class ParkViewModel
    {
        public int ParkId { get; set; }

        [Required(ErrorMessage = WebConstants.ParkNameIsRequired)]
        [StringLength(
            WebConstants.ParkNameMaxLen, 
            MinimumLength = WebConstants.ParkNameMinLen,
            ErrorMessage = WebConstants.InvalidParkNameLength
        )]
        [RegularExpression(
            WebConstants.ParkNameRegExValidator, 
            ErrorMessage = WebConstants.ParkNameShouldStartWithUppercase
        )]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = WebConstants.ParkTypeIsRequired)]
        [StringLength(
            WebConstants.ParkTypeMaxLen, 
            MinimumLength = WebConstants.ParkTypeMinLen,
            ErrorMessage = WebConstants.InvalidParkTypeLength
        )]
        public string Type { get; set; } = null!;

        [Required(ErrorMessage = WebConstants.ParkAreaIsRequired)]
        [Range(
            WebConstants.ParkAreaMin, 
            WebConstants.ParkAreaMax,
            ErrorMessage = WebConstants.InvalidParkAreaRange
        )]
        public decimal AreaSqKm { get; set; }

        [Range(
            WebConstants.ParkEstablishedYearMin, 
            WebConstants.ParkEstablishedYearMax,
            ErrorMessage = WebConstants.InvalidParkEstablishedYear
        )]
        public int? EstablishedYear { get; set; }

        [Required(ErrorMessage = WebConstants.ParkMountainIdIsRequired)]
        public int? MountainId { get; set; }

        public bool? UnescoSite { get; set; }

        public virtual MountainViewModel? Mountain { get; set; }
    }
}