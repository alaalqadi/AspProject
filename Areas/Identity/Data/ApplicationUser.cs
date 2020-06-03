using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Areas.Identity.Data
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string FirstName { get; set; }
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string LastName { get; set; }

        [Display(Name = "Are you a Technician?")]
        public bool IsTechnician { get; set; }

        [Display(Name = "Owner?")]
        public bool IsOwner { get; set; }
    }

    public class Vehicle
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int CreationYear { get; set; }
        public int Milage { get; set; }
        public DateTime LastMaintainanceDate { get; set; }
    }

    public class VehiclePart
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        public string PartName { get; set; }
        public int Condition { get; set; }
        public int PhoneNumber { get; set; }
        public string Manufacturer{ get; set; }
        public float Price { get; set; }
        public int CreationYear { get; set; }
    }
    public class ViewModel
    {
        public List<Vehicle> Vehicles { get; set; }
        public List<VehiclePart> VehicleParts { get; set; }
    }
}
