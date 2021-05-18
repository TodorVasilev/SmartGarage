﻿using SmartGarage.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SmartGarage.Service.DTOs.CreateDTOs
{
    public class CreateUserDTO
    {

        public User UserMap(CreateUserDTO createUserDTO)
        {
            var user = new User();

            user.UserName = createUserDTO.UserName;
            user.FirstName = createUserDTO.FirstName;
            user.LastName = createUserDTO.LastName;
            user.PhoneNumber = createUserDTO.PhoneNumber;
            user.Age = createUserDTO.Age;
            user.DrivingLicenseNumber = createUserDTO.DrivingLicenseNumber;
            user.Address = createUserDTO.Address;
            user.Email = createUserDTO.Email;
            return user;
        }
        [Required]
        [MinLength(2), MaxLength(20)]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [MinLength(2), MaxLength(20)]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2), MaxLength(20)]
        [Display(Name = "Family name")]
        public string LastName { get; set; }

        [StringLength(10)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        [Required]
        [Range(18, 100)]
        [Display(Name = "Age")]
        public int Age { get; set; }

        [Required]
        [Display(Name = "Driving license number")]
        public string DrivingLicenseNumber { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
    }
}

