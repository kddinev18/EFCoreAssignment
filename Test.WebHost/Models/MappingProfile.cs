// <copyright file="MappingProfile.cs" company="ORB">
// Copyright (c) ORB. All rights reserved.
// </copyright>

using AutoMapper;
// using Test.Domain.Models.Reservation;
using Test.Domain.Models.User;
using Test.Data.Models;

namespace Test.WebHost.Models;

/// <summary>
/// Defines mapping profiles for AutoMapper to handle object-to-object mappings.
/// </summary>
public class MappingProfile : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MappingProfile"/> class and defines mappings.
    /// </summary>
    public MappingProfile()
    {
        // Map from User to UserVM
        this.CreateMap<User, UserVM>();

        // Map from UserUM to User
        this.CreateMap<UserUM, User>();

        // Map from ReservationIM to Reservation
        // this.CreateMap<ReservationIM, Reservation>();

        // Map from Reservation to ReservationVM
        // this.CreateMap<Reservation, ReservationVM>();
    }
}