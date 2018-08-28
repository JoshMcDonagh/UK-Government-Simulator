using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Government_Simulator
{
    class Policy
    {
        // Declaration of variable attributes:
        public int ID;
        public string name;
        public int req_power;
        public bool active;
        public string description;
        public double costs;
        public double income;
        public double gdp;

        // Declaration of variables that effect voter group popularity:
        public int conservatives;
        public int liberals;
        public int capitalists;
        public int socialists;
        public int nationalists;
        public int globalists;
        public int environmentalists;

        // Declaration of variables that effect national statistics:
        public int employment;
        public int poverty;
        public int crime;
        public int health;
        public int education;
        public int equality;
        public int pollution;
        public int GDPgrowth;

        // Constructor:
        public Policy(int ID, string name, int req_power, bool active)
        {
            // Setting of default values:
            this.ID = ID;
            this.name = name;
            this.req_power = req_power;
            this.active = active;
            this.description = "";
            this.costs = 0;
            this.income = 0;

            // Setting of default voter group variables:
            this.conservatives = 0;
            this.liberals = 0;
            this.capitalists = 0;
            this.socialists = 0;
            this.nationalists = 0;
            this.globalists = 0;
            this.environmentalists = 0;

            // Setting of default national statistic variables:
            this.employment = 0;
            this.poverty = 0;
            this.crime = 0;
            this.health = 0;
            this.education = 0;
            this.equality = 0;
            this.pollution = 0;
            this.GDPgrowth = 0;
        }

        // Set description method:
        public void setDescription(string description)
        {this.description = description;}

        // Sets annual costs/income:
        public void setFinance(double costs, double income, double gdp = 0)
        {
            this.costs = costs;
            this.income = income;
            this.gdp = gdp;
        }

        // Changes policy activity:
        public bool changeActivity()
        {
            if (active){this.active = false;}

            else{this.active = true;}

            return this.active;
        }

        // Sets the policy popularity amoungst voter groups:
        public void setPopularity(int conservatives = 0, int liberals = 0, int capitalists = 0, int socialists = 0, int nationalists = 0, int globalists = 0, int environmentalists = 0)
        {
            this.conservatives = conservatives;
            this.liberals = liberals;
            this.capitalists = capitalists;
            this.socialists = socialists;
            this.nationalists = nationalists;
            this.globalists = globalists;
            this.environmentalists = environmentalists;
        }

        // Sets the policy effects on national statistics:
        public void setStatistics(int employment = 0, int poverty = 0, int crime = 0, int health = 0, int education = 0, int equality = 0, int pollution = 0, int GDPgrowth = 0)
        {
            this.employment = employment;
            this.poverty = poverty;
            this.crime = crime;
            this.health = health;
            this.education = education;
            this.equality = equality;
            this.pollution = pollution;
            this.GDPgrowth = GDPgrowth;
        }
    }
}
