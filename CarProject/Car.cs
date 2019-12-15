using System;
using System.Collections.Generic;
using System.Text;

namespace CarProject
{
    public class Car : ICar
    {
        public IDrivingInformationDisplay drivingInformationDisplay;

        public IFuelTankDisplay fuelTankDisplay;

        private IDrivingProcessor drivingProcessor;

        private IEngine engine;

        private IFuelTank fuelTank;

        public IOnBoardComputerDisplay onBoardComputerDisplay; // car #3

        private IOnBoardComputer onBoardComputer; // car #3

        public Car()
        {
            fuelTank = new FuelTank();
            fuelTankDisplay = new FuelTankDisplay(fuelTank);
            engine = new Engine(fuelTank);
            drivingProcessor = new DrivingProcessor(engine, 10);
            drivingInformationDisplay = new DrivingInformationDisplay(drivingProcessor);
            onBoardComputer = new OnBoardComputer(drivingProcessor);
            onBoardComputerDisplay = new OnBoardComputerDisplay(onBoardComputer);
        }

        public Car(double fuelLevel)
        {
            fuelTank = new FuelTank(fuelLevel);
            fuelTankDisplay = new FuelTankDisplay(fuelTank);
            engine = new Engine(fuelTank);
            drivingProcessor = new DrivingProcessor(engine, 10);
            drivingInformationDisplay = new DrivingInformationDisplay(drivingProcessor);
            onBoardComputer = new OnBoardComputer(drivingProcessor);
            onBoardComputerDisplay = new OnBoardComputerDisplay(onBoardComputer);
        }

        public Car(double fuelLevel, int maxAcceleration)
        {
            fuelTank = new FuelTank(fuelLevel);
            fuelTankDisplay = new FuelTankDisplay(fuelTank);
            engine = new Engine(fuelTank);
            drivingProcessor = new DrivingProcessor(engine, maxAcceleration);
            drivingInformationDisplay = new DrivingInformationDisplay(drivingProcessor);
            onBoardComputer = new OnBoardComputer(drivingProcessor);
            onBoardComputerDisplay = new OnBoardComputerDisplay(onBoardComputer);
        }

        public bool EngineIsRunning
        {
            get
            {
                return engine.IsRunning;
            }
        }

        public void EngineStart()
        {
            if ((!engine.IsRunning) && (fuelTank.FillLevel > 0))
            {
                engine.Start();
            }
        }

        public void EngineStop()
        {
            if (engine.IsRunning)
            {
                engine.Stop();
            }
        }

        public void Refuel(double liters)
        {
            fuelTank.Refuel(liters);
        }

        public void RunningIdle()
        {
            drivingProcessor.ReduceSpeed(0);
        }

        public void BrakeBy(int speed)
        {
            drivingProcessor.ReduceSpeed(speed);
        }

        public void Accelerate(int speed)
        {
            drivingProcessor.IncreaseSpeedTo(speed);
        }

        public void FreeWheel()
        {
            drivingProcessor.ReduceSpeed(1);
        }
    }
}
