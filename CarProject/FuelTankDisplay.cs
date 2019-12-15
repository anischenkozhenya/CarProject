﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CarProject
{
    public class FuelTankDisplay : IFuelTankDisplay
    {
        private IFuelTank _fuelTank;

        public FuelTankDisplay(IFuelTank fuelTank)
        {
            _fuelTank = fuelTank;
        }

        public double FillLevel
        {
            get
            {
                return Math.Round(_fuelTank.FillLevel, 2);
            }
        }

        public bool IsOnReserve
        {
            get
            {
                return _fuelTank.IsOnReserve;
            }
        }

        public bool IsComplete
        {
            get
            {
                return _fuelTank.IsComplete;
            }
        }
    }

}
