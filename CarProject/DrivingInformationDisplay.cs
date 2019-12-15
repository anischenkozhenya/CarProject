using System;
using System.Collections.Generic;
using System.Text;

namespace CarProject
{
    public class DrivingInformationDisplay : IDrivingInformationDisplay // car #2
    {
        private IDrivingProcessor _DrivingProcessor;
        public DrivingInformationDisplay(IDrivingProcessor drivingProcessor)
        {
            _DrivingProcessor = drivingProcessor;
        }
        public int ActualSpeed { get { return _DrivingProcessor.ActualSpeed; } }
    }
}
