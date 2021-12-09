using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practih8
{
    class GeometricProgression : ISeries, ICloneable, IComparable
    {
        private int _startValue;
        private double _currentValue;

        public GeometricProgression()
        {
            StartValue = 1;
            CurrentValue = StartValue;
        }

        public GeometricProgression(int startValue)
        {
            StartValue = startValue;
            CurrentValue = StartValue;
        }

        public int StartValue
        {
            get { return _startValue; }
            set { _startValue = value; }
        }
        public double CurrentValue
        {
            get { return _currentValue; }
            set { _currentValue = value; }
        }

        public double Next
        {
            get { return GetNext(); }
        }

        public object Clone()
        {
            GeometricProgression clonedProgression = new();
            clonedProgression.StartValue = this.StartValue;
            clonedProgression.CurrentValue = this.CurrentValue;
            return clonedProgression;
        }

        public int CompareTo(object obj)
        {
            GeometricProgression secondaryProgression = new();
            if (secondaryProgression.Next / secondaryProgression.StartValue == 2)
                return 0;
            else return -1;
        }

        public double GetNext()
        {
            CurrentValue *= 2;
            return CurrentValue;
        }

        public void Reset()
        {
            CurrentValue = StartValue;
        }

        public void SetStart(int startValue)
        {
            StartValue = startValue;
            CurrentValue = StartValue;
        }
    }
}
