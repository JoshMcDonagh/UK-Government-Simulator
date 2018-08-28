using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Government_Simulator
{
    class Crisis
    {
        // Declaration of variable attributes:
        public int ID;
        public string name;
        public double statistic;
        public double boundary;
        public bool testIfBelow;
        public bool isInEffect;

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
        public Crisis(int ID, string name, double boundary)
        {
            // Setting of Default Values:
            this.ID = ID;
            this.name = name;
            this.statistic = 0;
            this.boundary = boundary;
            this.testIfBelow = false;
            this.isInEffect = false;
        }

        // Sets whether the crisis is in effect or not:
        public bool setCrisis(object statistic, bool testIfBelow)
        {
            this.statistic = Convert.ToDouble(statistic);
            this.testIfBelow = testIfBelow;

            // Tests if a crisis has been caused by the statistical value being smaller than that of the boundary value:
            if (testIfBelow && (this.statistic < this.boundary))
            { this.isInEffect = true; }

            // Tests if a crisis has been caused by the statistical value being greater than that of the boundary value:
            else if (!testIfBelow && (this.statistic > this.boundary))
            { this.isInEffect = true; }

            // If non of the above tests are true:
            else
            { this.isInEffect = false; }

            // Returns the isInEffect value:
            return this.isInEffect;
        }

        // Sets the crisis popularity amoungst voter groups:
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

        // Sets the crisis effects on national statistics:
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
