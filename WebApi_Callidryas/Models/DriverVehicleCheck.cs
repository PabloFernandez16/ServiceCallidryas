using System;
using System.Collections.Generic;

namespace WebApi_Callidryas.Models;

public partial class DriverVehicleCheck
{
    public int Id { get; set; }

    public int DriverId { get; set; }

    public int MicroId { get; set; }

    public int InitialMileage { get; set; }

    public DateTime? ReviewDate { get; set; }

    public bool? WaterLevel { get; set; }

    public bool? Clarkson { get; set; }

    public bool? EngineOilLevel { get; set; }

    public bool? SteeringOilLevel { get; set; }

    public bool? BrakeFluidLevel { get; set; }

    public bool? BodyCondition { get; set; }

    public bool? RearviewMirrors { get; set; }

    public bool? TirePressure { get; set; }

    public bool? FirstAidKit { get; set; }

    public bool? Trash { get; set; }

    public bool? HydraulicJack { get; set; }

    public bool? JackRod { get; set; }

    public bool? ReflectiveVest { get; set; }

    public bool? FireExtinguisher { get; set; }

    public bool? Cleanliness { get; set; }

    public string? Remarks { get; set; }

    public virtual Driver Driver { get; set; } = null!;

    public virtual Micro Micro { get; set; } = null!;
}
