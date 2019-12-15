using System;
using System.Collections.Generic;
using System.Text;

namespace CarProject
{
    public class DrivingProcessor : IDrivingProcessor
    {
        public int TimeInWork = 0;
        public int TimeInDriving = 0;
        public double[] ConsumesList = new double[0];
        public int[] SpeedsList = new int[0];
        private void AddConsumes(double consume)
        {
            double[] NewConsumesList = new double[ConsumesList.Length+1];
            NewConsumesList[ConsumesList.Length] = consume;
            ConsumesList = NewConsumesList;
        }
        private void AddSpeeds(int consume)
        {
            int[] NewList = new int[SpeedsList.Length + 1];
            NewList[SpeedsList.Length] = consume;
            SpeedsList = NewList;
        }
        private const int brakingSpeed = 10;
        private const int maxSpeed = 250;
        private IEngine _engine;
        private readonly int _maxAcceleration;
        private int _actualSpeed = 0;
        private double _actualConsumption = 0;
        public DrivingProcessor(IEngine engine, int maxAcceleration)
        {
            if (maxAcceleration < 5)
            {
                maxAcceleration = 5;
            }
            if (maxAcceleration > 20)
            {
                maxAcceleration = 20;
            }
            _engine = engine;
            _maxAcceleration = maxAcceleration;
            Engine EngineEvents = engine as Engine;
            EngineEvents.EngineStart += () => EngineStart();
            EngineEvents.EngineStop += () => EngineStop();
        }
        public int ActualSpeed
        {
            get
            {
                return _actualSpeed;
            }
        }
        public double ActualConsumption 
        { 
            get 
            {
                if (_engine.IsRunning)
                {
                    return _actualConsumption;
                }
                else
                {
                    return 0;
                }
            } 
        }
        public void EngineStart()
        {
            
        }
        public void EngineStop()
        {
            TimeInWork = 0;
            TimeInDriving = 0;
        }
        public void IncreaseSpeedTo(int speed)
        {
            if (!_engine.IsRunning)
            {
                return;
            }

            if (speed < _actualSpeed)
            {
                _actualSpeed--;
            }

            if (_actualSpeed < speed)
            {
                _actualSpeed = Math.Min(speed, _actualSpeed + _maxAcceleration);
            }

            if (_actualSpeed > maxSpeed)
            {
                _actualSpeed = maxSpeed;
            }
            Consume();
            AddSpeeds(_actualSpeed);
        }
        public void ReduceSpeed(int speed)
        {
            if (!_engine.IsRunning)
            {
                return;
            }

            _actualSpeed -= Math.Min(speed, brakingSpeed);

            if (_actualSpeed < 0)
            {
                _actualSpeed = 0;
            }

            if (_actualSpeed == 0)
            {
                _engine.Consume(0.0003);
                AddConsumes(0.0003); 
                TimeInWork++;
            }
            AddSpeeds(_actualSpeed);
        }
        private void Consume()
        {
            if (!_engine.IsRunning)
            {
                return;
            }
            TimeInWork++;
            TimeInDriving++;
            double consumption = 0.0020;
            if ((_actualSpeed > 61) && (_actualSpeed <= 100))
            {
                consumption = 0.0014;
            }
            if ((_actualSpeed > 141) && (_actualSpeed <= 200))
            {
                consumption = 0.0025;
            }
            if ((_actualSpeed > 201) && (_actualSpeed <= 250))
            {
                consumption = 0.0030;
            }
            _engine.Consume(consumption);
            _actualConsumption = consumption;
            AddConsumes(_actualConsumption);            
        }
    }
}
