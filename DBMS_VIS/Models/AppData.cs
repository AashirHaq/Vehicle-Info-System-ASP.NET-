using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DBMS_VIS.Models
{
    public class AppData
    { 
        [Display(Name ="Owner ID" )]
        [Required(ErrorMessage = "Owner ID is required.")]
        public int OwnerID { get; set; }

        [Display(Name = "Info ID")]
        [Required(ErrorMessage = "Info ID is required.")]
        public int InfoID { get; set; }

        [Display(Name = "Owner Name")]
        [Required(ErrorMessage ="Name is required.") ]
        public string OwnerName { get; set; }

        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Gender is required.")]
        public string Gender { get; set; }

        [Display(Name = "Vehicle Type")]
        [Required(ErrorMessage = "Vehicle Type is required.")]
        public string VType { get; set; }

        [Display(Name = "Color: ")]
        [Required(ErrorMessage = "Color is required.")]
        public string Color { get; set; }

        [Display(Name = "Registration Number")]
        [Required(ErrorMessage = "Registration Number is required.")]
        public string RegistrationNumber { get; set; }

        [Display(Name = "Chassis Number")]
        [Required(ErrorMessage = "Chassis Number is required.")]
        public string ChassisNumber { get; set; }

        [Display(Name = "Engine Number")]
        [Required(ErrorMessage = "Engine Number is required.")]
        public string EngineNumber { get; set; }

        [Display(Name = "Registration Date")]
        [Required(ErrorMessage = "Registration Date is required.")]
        public string RegistrationDate { get; set; }

        [Display(Name = "Model")]
        [Required(ErrorMessage = "Model is required.")]
        public int Model { get; set; }

        [Display(Name = "Manufactured By")]
        [Required(ErrorMessage = "Company name is required.")]
        public string ManufacturedBy { get; set; }

        [Display(Name = "Vehicle Name")]
        [Required(ErrorMessage = "Vehicle name is required.")]
        public string VehicleName { get; set; }
    }
}