using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport
{
    public class Reis : IExemption
    {
        private int nomerReisa;
        private string mesto;
        private double tariff;

        public Reis(int nomerReisa, string mesto, double tariff)
        {
            this.nomerReisa = nomerReisa;
            this.mesto = mesto;
            this.tariff = tariff;
        }
        public int NOMERREISA
        {
            get
            {
                return nomerReisa;
            }
            set
            {
                nomerReisa = value;
            }
        }
        public string MESTO
        {
            get
            {
                return mesto;
            }
            set
            {
                mesto = value;
            }
        }
        public double TARIFF
        {
            get
            {
                return tariff;
            }
            set
            {
                tariff = value;
            }
        }

        public double getExemption(bool exemption)
        {
            if (exemption)
                return this.tariff * 0.9;
            else
                return this.tariff;
        }
    }
}
