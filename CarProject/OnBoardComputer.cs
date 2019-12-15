using System;
using System.Collections.Generic;
using System.Text;

namespace CarProject
{
    public class OnBoardComputer : IOnBoardComputer // car #3
    {
        private DrivingProcessor _drivingProcessor;
        public OnBoardComputer(IDrivingProcessor drivingProcessor)
        {
            _drivingProcessor = drivingProcessor as DrivingProcessor;
        }
        private int _actualSpeed = 0;
        private double _actualConsumptionByDistance = 0;
        private int _tripRealTime = 0;
        private int _tripDrivingTime = 0;
        private int _tripDrivenDistance = 0;
        private int _totalRealTime = 0;
        private int _totalDrivingTime = 0;
        private int _totalDrivenDistance = 0;
        private double _tripAverageSpeed = 0;
        private double _totalAverageSpeed = 0;
        private double _tripAverageConsumptionByTime = 0;
        private double _totalAverageConsumptionByTime = 0;
        private double _tripAverageConsumptionByDistance = 0;
        private double _totalAverageConsumptionByDistance = 0;
        private int _estimatedRange = 0;
        /// <summary>
        /// Время с запущеным двигателем за сессию
        /// </summary> 
        public int TripRealTime 
        { 
            get 
            {
                return _drivingProcessor.TimeInWork;
            } 
        }
        /// <summary>
        /// Время в движении за сесиию
        /// </summary>
        public int TripDrivingTime
        {
            get
            {
                return _drivingProcessor.TimeInDriving;
            }
        }
        /// <summary>
        /// Пройденое расстояние за сессию
        /// </summary>
        public int TripDrivenDistance => _tripDrivenDistance;
        /// <summary>
        /// Время с запущенным двигателем за все время
        /// </summary>
        public int TotalRealTime 
        {
            get 
            {
                _totalRealTime+=TripRealTime;
                return _totalRealTime;
            } 
        }
        /// <summary>
        /// Время в движении за все время
        /// </summary>
        public int TotalDrivingTime 
        {
            get
            {
                _totalDrivingTime += TripRealTime;
                return _totalDrivingTime;
            }
        }

        public int TotalDrivenDistance => _totalDrivenDistance;
        /// <summary>
        /// Средняя скорость за сессию
        /// </summary>
        public double TripAverageSpeed
        {
            get
            {
                if (_drivingProcessor.SpeedsList.Length>0)
                {
                    int SumSpeed = 0;
                    for (int i = 0; i < _drivingProcessor.SpeedsList.Length; i++)
                    {
                        SumSpeed += _drivingProcessor.SpeedsList[i];
                    }
                    return SumSpeed / _drivingProcessor.SpeedsList.Length;
                }
                return 0;
            }
        }

        public double TotalAverageSpeed => _totalAverageSpeed;

        /// <summary>
        /// Текщая скорость
        /// </summary>
        public int ActualSpeed => _drivingProcessor.ActualSpeed;
        /// <summary>
        /// Потребление в момент вызова
        /// </summary>
        public double ActualConsumptionByTime 
        { 
            get 
            {
                return _drivingProcessor.ActualConsumption;
            } 
        }
        /// <summary>
        /// 
        /// </summary>
        public double ActualConsumptionByDistance => _actualConsumptionByDistance;
        /// <summary>
        /// Среднee потребление топлива за сессию
        /// </summary>
        public double TripAverageConsumptionByTime
        {
            get
            {
                if (_drivingProcessor.ConsumesList.Length>0)
                {
                    double SumConsumes = 0;
                    for (int i = 0; i < _drivingProcessor.ConsumesList.Length; i++)
                    {
                        SumConsumes += _drivingProcessor.ConsumesList[i];
                    }
                    return SumConsumes / _drivingProcessor.ConsumesList.Length;
                }
                else { return 0; }
            }
        }
        /// <summary>
        /// Среднее потребление топлива за все время
        /// </summary>
        public double TotalAverageConsumptionByTime => _totalAverageConsumptionByTime;

        public double TripAverageConsumptionByDistance => _tripAverageConsumptionByDistance;

        public double TotalAverageConsumptionByDistance => _totalAverageConsumptionByDistance;

        public int EstimatedRange => _estimatedRange;

        public void ElapseSecond()
        {

        }

        public void TotalReset()
        {
            _actualSpeed = 0;
            _actualConsumptionByDistance = 0;
            _tripRealTime = 0;
            _tripDrivingTime = 0;
            _tripDrivenDistance = 0;
            _totalRealTime = 0;
            _totalDrivingTime = 0;
            _totalDrivenDistance = 0;
            _tripAverageSpeed = 0;
            _totalAverageSpeed = 0;
            _tripAverageConsumptionByTime = 0;
            _totalAverageConsumptionByTime = 0;
            _tripAverageConsumptionByDistance = 0;
            _totalAverageConsumptionByDistance = 0;
            _estimatedRange = 0;
        }

        public void TripReset()
        {
            _actualSpeed = 0;
            _actualConsumptionByDistance = 0;
            _tripRealTime = 0;
            _tripDrivingTime = 0;
            _tripDrivenDistance = 0;
            _tripAverageSpeed = 0;
            _tripAverageConsumptionByTime = 0;
            _tripAverageConsumptionByDistance = 0;
            _estimatedRange = 0;
        }
    }
}
