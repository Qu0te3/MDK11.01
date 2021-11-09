using System;
using System.Collections.Generic;
using System.Text;

namespace isp34_morar
{
    class Triangle
    {
        private int sideA;
        private int sideB;
        private int sideC;

        public int SideA
        {
            get
            {
                return sideA;
            }
            set
            {
                if (value < 0 || value == 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else sideA = value;
            }
        }

        public int SideB
        {
            get
            {
                return sideB;
            }
            set
            {
                if (value < 0 || value == 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else sideB = value;
            }
        }

        public int SideC
        {
            get
            {
                return sideC;
            }
            set
            {
                if (value < 0 || value == 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else sideC = value;
            }
        }

        public void SetParams(int newSide)
        {
            SideA = newSide;
            SideB = newSide;
            SideC = newSide;
        }

        public void SetParams(int newSideA, int newSideB, int newSideC)
        {
            SideA = newSideA;
            SideB = newSideB;
            SideC = newSideC;
        }

        public int GetPerimeter()
        {
            return SideA + SideB + SideC;
        }

        public void IncreaseByTwo()
        {
            if (SideA != 0 && SideB != 0 && SideC != 0)
            {
                SideA *= 2;
                SideB *= 2;
                SideC *= 2;
            }
            else throw new ArgumentNullException();
        }
    }
}
