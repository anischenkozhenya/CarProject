using System;
using System.Collections.Generic;
using System.Text;

namespace CarProject
{
    public class FuelTank : IFuelTank
    {
        private double _fillLevel;

        private double _tankSize = 60;

        public FuelTank()
        {
            _fillLevel = 20;
        }

        public FuelTank(double fillLevel)
        {
            if (fillLevel < 0)
            {
                fillLevel = 0;
            }
            if (fillLevel > _tankSize)
            {
                fillLevel = _tankSize;
            }

            _fillLevel = fillLevel;
        }

        public double FillLevel
        {
            get
            {
                return _fillLevel;
            }
        }

        public bool IsOnReserve
        {
            get
            {
                return _fillLevel < 5;
            }
        }

        public bool IsComplete
        {
            get
            {
                return _fillLevel == _tankSize;
            }
        }

        public void Consume(double liters)
        {
            _fillLevel -= liters;
            if (_fillLevel < 0)
            {
                _fillLevel = 0;
            }
            _fillLevel = Math.Round(_fillLevel, 10);
        }

        public void Refuel(double liters)
        {
            _fillLevel += liters;
            if (_fillLevel > 60)
            {
                _fillLevel = 60;
            }
            _fillLevel = Math.Round(_fillLevel, 10);
        }
    }

}
