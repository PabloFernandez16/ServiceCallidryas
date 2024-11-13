using System;
using System.Collections.Generic;

namespace WebApi_Callidryas.Models;

public partial class Micro
{
    public int Id { get; set; }

    public string PlateNumber { get; set; } = null!;

    public string? Model { get; set; }

    public virtual ICollection<DriverVehicleCheck> DriverVehicleChecks { get; set; } = new List<DriverVehicleCheck>();
}
