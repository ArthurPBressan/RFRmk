﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class TeamStatus
{
    public Team Team { get; private set; }

    private Dictionary<VehicleType, int> RemainingVehicles;


    public TeamStatus(int[] remainingVehicles = null)
    {
        RemainingVehicles = new Dictionary<VehicleType, int>();
        foreach (var vehicleType in Utils.Vehicles)
        {
            RemainingVehicles.Add(vehicleType, 0);
        }
        if (remainingVehicles != null)
        {
            RemainingVehicles[VehicleType.Jeep] = remainingVehicles[0];
            if (remainingVehicles.Length > 1)
            {
                RemainingVehicles[VehicleType.Tank] = remainingVehicles[1];
            }
        }
    }

    public void RemoveVehicle(VehicleType vehicle)
    {
        RemainingVehicles[vehicle]--;
    }

    internal int GetRemainingVehicles(VehicleType vehicle)
    {
        return RemainingVehicles[vehicle];
    }
}
