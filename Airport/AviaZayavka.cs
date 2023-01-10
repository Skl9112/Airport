using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport
{
    public class AviaZayavka 
    {        
        
        private string famIO;
        private string passport;
        private int count; 
        private int[] flightNumber; 
        private int[] countOfTickets;
        private bool[] exemption; 

        public AviaZayavka(string famIO, string passport, int count, int[] nomReisa, int[] countTicket, bool[] exemption)
        {
            this.famIO = famIO;
            this.passport = passport;
            this.flightNumber = nomReisa;
            this.count = count;
            this.exemption = exemption;
            this.countOfTickets = countTicket;
        }
        public string FAMIO
        {
            get
            {
                return famIO;
            }
            set
            {
                famIO = value;
            }
        }
        public string PASSPORT
        {
            get
            {
                return passport;
            }
            set
            {
                passport = value;
            }
        }
        public int[] NOMREISA
        {
            get
            {
                return flightNumber;
            }
            set
            {
                flightNumber = value;
            }
        }
        public int[] COUNTTICKET
        {
            get
            {
                return countOfTickets;
            }
            set
            {
                countOfTickets = value;
            }
        }
        public bool[] EXEMPTION
        {
            get
            {
                return exemption;
            }
            set
            {
                exemption = value;
            }
        }
        public int COUNT
        {
            get
            {
                return count;
            }
            set
            {
                count = value;
            }
        }
        public double getCost(double tariff, int i)
        {
            return countOfTickets[i] * tariff;
        }
    }
}
