using System;
using System.Collections.Generic;
using System.Text;

namespace CarProject
{
    public class Engine : IEngine
    {
        
        public event Action EngineStart=null;
        public event Action EngineStop=null;
        private bool _isRunning = false;
        private IFuelTank _fuelTank;

        public Engine(IFuelTank fuelTank)
        {
            _fuelTank = fuelTank;
        }

        public bool IsRunning
        {
            get
            {
                return _isRunning;
            }
        }

        public void Consume(double liters)
        {
            if (_isRunning)
            {
                _fuelTank.Consume(liters);
                if (_fuelTank.FillLevel == 0)
                {
                    Stop();                    
                }
            }
        }

        public void Start()
        {
            _isRunning = true;
            this.EngineStart();
        }

        public void Stop()
        {
            _isRunning = false;
            this.EngineStop();
        }
    }

}
