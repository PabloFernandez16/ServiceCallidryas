using System;
using System.Collections.Generic;

namespace WebApi_Callidryas.Models;

public partial class Driver
{
    public int Id { get; set; }

    public string DriverName { get; set; } = null!;

    public string DriverLastName { get; set; } = null!;

    public virtual ICollection<DriverVehicleCheck> DriverVehicleChecks { get; set; } = new List<DriverVehicleCheck>();
}
