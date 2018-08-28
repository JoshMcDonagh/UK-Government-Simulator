using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Xml;
using System.IO;
using System.Media;
using System.Windows.Media;

namespace Government_Simulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Declaration of gameplay variables:
        string GP_party;
        int GP_turn;
        int GP_power;
        int GP_ppt; // (Power per turn)
        bool GP_victory;

        // Declaration of economic variables:
        double EC_income;
        double EC_spending;
        double EC_surplus;
        double EC_reserves;
        double EC_gdp;

        // Declaration of voter group variables:
        int VG_conservatives;
        int VG_liberals;
        int VG_capitalists;
        int VG_socialists;
        int VG_nationalists;
        int VG_globalists;
        int VG_environmentalists;

        // Declaration of national statistic variables:
        int ST_employment;
        int ST_poverty;
        int ST_crime;
        int ST_health;
        int ST_education;
        int ST_equality;
        int ST_pollution;
        int ST_GDPgrowth;

        // Declaration of list storing all policies available:
        List<Policy> policies = new List<Policy>();

        // Declaration of the in-term polling list:
        List<double> polling = new List<double>();

        // Declaration of list storing all crises possible:
        List<Crisis> crises = new List<Crisis>();

        // Declaration of policy object which stores the policy that has been selected by the user of the program.
        Policy selectedPolicy;



        // Procedure which implements the government policies for the gameplay process.
        private void generatePolicies()
        {
            // --- Resets Policy List ---
            policies = new List<Policy>();

            // --- Policy Implementation: ---
            // State Healthcare:
            policies.Add(new Government_Simulator.Policy(0, "State Health Service", 40, true));
            policies[0].setDescription("State ran healthcare free at the point of use for all UK citizens.");
            policies[0].setFinance(143.7 * 10E9, 0);
            policies[0].setPopularity(-5, 10, -10, 15);
            policies[0].setStatistics(0, -20, 0, 20, 0, 10);

            // State Education:
            policies.Add(new Government_Simulator.Policy(1, "State Education", 18, true));
            policies[1].setDescription("State ran schools and colleges free for young people.");
            policies[1].setFinance(86 * 10E9, 0);
            policies[1].setPopularity(-3, 10, -10, 15);
            policies[1].setStatistics(0, -20, 0, 0, 20, 10);

            // State Housing:
            policies.Add(new Government_Simulator.Policy(2, "State Housing", 10, true));
            policies[2].setDescription("State owned housing for people to live in.");
            policies[2].setFinance(4 * 10E9, 0);
            policies[2].setPopularity(-10, 10, -15, 20);
            policies[2].setStatistics(0, -30, -5, 5, 0, 5);

            // Captial Punishment:
            policies.Add(new Government_Simulator.Policy(3, "Capital Punishment", 40, false));
            policies[3].setDescription("The state puts those who commit especially harsh crimes to death.");
            policies[3].setFinance(20 * 10E9, 0);
            policies[3].setPopularity(20, -20, 0, -10, 5);
            policies[3].setStatistics(0, 0, -10, 0, 0, 0);

            // Income Tax:
            policies.Add(new Government_Simulator.Policy(4, "Income Tax", 25, true));
            policies[4].setDescription("Taxation based on income.");
            policies[4].setFinance(0, 272 * 10E9);
            policies[4].setPopularity(-5, 5, -50, 50);
            policies[4].setStatistics(0, 5, 5, 0, 0, 30, 0, -5);

            // Corporation Tax:
            policies.Add(new Government_Simulator.Policy(5, "Corporation Tax", 18, true));
            policies[5].setDescription("Taxation for corporations based on the company income.");
            policies[5].setFinance(0, 56 * 10E9);
            policies[5].setPopularity(-10, 10, -60, 60);
            policies[5].setStatistics(-10, 0, 0, 0, 0, 10, 0, -20);

            // State Pensions:
            policies.Add(new Government_Simulator.Policy(6, "State Pensions", 27, true));
            policies[6].setDescription("Pension schemes provided by the state as oppose to privately.");
            policies[6].setFinance(111 * 10E9, 0);
            policies[6].setPopularity(-5, 10, -20, 20);
            policies[6].setStatistics(0, -15, 0, 5, 0, 13);

            // Carbon Tax:
            policies.Add(new Government_Simulator.Policy(7, "Carbon Tax", 35, false));
            policies[7].setDescription("Taxation of goods and services that increase the level of pollution.");
            policies[7].setFinance(0, 50 * 10E9);
            policies[7].setPopularity(-10, 0, -40, 10, -5, -5, 60);
            policies[7].setStatistics(-15, 5, 0, 5, 0, 0, -40, -30);

            // Defence Policy:
            policies.Add(new Government_Simulator.Policy(8, "Defence Policy", 50, true));
            policies[8].setDescription("Spending on defence capabilites in and around the UK.");
            policies[8].setFinance(44.7 * 10E9, 0);
            policies[8].setPopularity(20, -20, 0, 0, 50, 0, -10);
            policies[8].setStatistics(10);

            // State Operated Railways:
            policies.Add(new Government_Simulator.Policy(9, "State Operated Railways", 15, false));
            policies[9].setDescription("Nationalisation and state control of all UK railways.");
            policies[9].setFinance(20 * 10E9, 0);
            policies[9].setPopularity(-10, 10, -20, 20);
            policies[9].setStatistics(10, 0, 0, 0, 0, 5, 1, 20);

            // Television Licence Fees:
            policies.Add(new Government_Simulator.Policy(10, "Television Licence Fees", 10, true));
            policies[10].setDescription("Effectively taxes those with a television.");
            policies[10].setFinance(0, 3.7 * 10E9);
            policies[10].setPopularity(-2, 2, -10, 10);
            policies[10].setStatistics(0, 1);

            // State Broadcasting Company:
            policies.Add(new Government_Simulator.Policy(11, "State Broadcasting Company", 31, true));
            policies[11].setDescription("A broadcaster funded by the public as oppose to advertisers.");
            policies[11].setFinance(3.7 * 10E9, 0);
            policies[11].setPopularity(0, 0, -5, 5);
            policies[11].setStatistics(2, 0, -1, 2, 8, 4, 1, 1);

            // Centralised State House Building Program:
            policies.Add(new Government_Simulator.Policy(12, "Centralised House Building Program", 13, false));
            policies[12].setDescription("A robust and strengthened program of state funded house building.");
            policies[12].setFinance(25 * 10E9, 0);
            policies[12].setPopularity(-5, 10, -10, 20);
            policies[12].setStatistics(30, -15, -5, 6, 3, 25, 15, 4);

            // Small Business Subsidy:
            policies.Add(new Government_Simulator.Policy(13, "Small Business Subsidy", 5, false));
            policies[13].setDescription("State provisions of funding for smaller businesses to improve competitivity.");
            policies[13].setFinance(1 * 10E9, 0);
            policies[13].setPopularity(5, 5, 15, -3, 5, 1);
            policies[13].setStatistics(5, -2, -1, 0, 0, -1, 0, 1);

            // Immigration Ban:
            policies.Add(new Government_Simulator.Policy(14, "Immigration Ban", 50, false));
            policies[14].setDescription("Effectively shuts down borders allowing nobody in.");
            policies[14].setFinance(0.5 * 10E9, 0);
            policies[14].setPopularity(15, -20, -10, -15, 50, -50);
            policies[14].setStatistics(0, 0, 5, 0, 0, -15, -2, -7);

            // Relaxed Immigration Policy:
            policies.Add(new Government_Simulator.Policy(15, "Relaxed Immigration Ban", 45, false));
            policies[15].setDescription("Effectively opens the borders allowing anybody in.");
            policies[15].setFinance(0.5 * 10E9, 0);
            policies[15].setPopularity(-15, 5, 0, -5, -50, 50);
            policies[15].setStatistics(0, 0, 5, 0, 0, 15, 2, 7);

            // Inheritance Tax:
            policies.Add(new Government_Simulator.Policy(16, "Inheritance Tax", 19, true));
            policies[16].setDescription("Taxation of estate's with more than £325,000 previously owned to deceased individuals.");
            policies[16].setFinance(0, 5 * 10E9);
            policies[16].setPopularity(-10, 5, -5, 10);
            policies[16].setStatistics(0, 1, 0, 0, 0, 6, 0, -1);

            // National Recycling Initiative:
            policies.Add(new Government_Simulator.Policy(17, "National Recycling Initiative", 12, false));
            policies[17].setDescription("Initiative to spread awareness of recycling around the country.");
            policies[17].setFinance(0.2 * 10E9, 0);
            policies[17].setPopularity(0, 0, 0, 0, 0, 0, 5);
            policies[17].setStatistics(1, 0, 0, 1, 3, 0, -10);

            // Student Maintenance Grants:
            policies.Add(new Government_Simulator.Policy(18, "Student Maintenance Grants", 20, false));
            policies[18].setDescription("Fund students to allow them to live and surivive at university without a great level of financial stress.");
            policies[18].setFinance(1.57 * 10E9, 0);
            policies[18].setPopularity(-1, 10, 0, 6);
            policies[18].setStatistics(2, -1, 0, 1, 4, 7);

            // Graduate Tax:
            policies.Add(new Government_Simulator.Policy(19, "Graduate Tax", 25, false));
            policies[19].setDescription("A tax for recently graduated people to pay.");
            policies[19].setFinance(0, 3 * 10E9);
            policies[19].setPopularity(1, -1, 1, -1);
            policies[19].setStatistics(0, 0, 0, 0, -1);

            // Student Fees:
            policies.Add(new Government_Simulator.Policy(20, "Student Fees", 19, true));
            policies[20].setDescription("Students are required to pay fees when studying at university.");
            policies[20].setFinance(0, 3 * 10E9);
            policies[20].setPopularity(4, -4, 1, -5);
            policies[20].setStatistics(-1, 1, 0, 0, -1, -5);

            // Sugar Tax:
            policies.Add(new Government_Simulator.Policy(21, "Sugar Tax", 15, false));
            policies[21].setDescription("Tax on products which contain sugar.");
            policies[21].setFinance(0, 10 * 10E9);
            policies[21].setPopularity(0, -1, -2, 0, 0, 0, 1);
            policies[21].setStatistics(-1, -1, 1, 5, 0, 0, 0, -1);
        }



        // Procedure which implements the crises objects for the gameplay process.
        private void generateCrises()
        {
            // --- Resets Crises List ---
            crises = new List<Crisis>();
            
            // --- Crisis Implementation: ---
            // Debt Crisis:
            crises.Add(new Government_Simulator.Crisis(0, "Debt Crisis", 200));
            crises[0].setPopularity(-2, -1, -3, -1, -2, -2, 0);
            crises[0].setStatistics(-2, 1, 1, 0, 0, 0, 0, -1);

            // Health Crisis:
            crises.Add(new Government_Simulator.Crisis(1, "Health Crisis", 60));
            crises[1].setPopularity(-1, -2, 0, -1, 0, 0, -1);
            crises[1].setStatistics();

            // Corporate Exodus:
            crises.Add(new Government_Simulator.Crisis(2, "Corporate Exodus", 1));
            crises[2].setPopularity(-2, 0, 0, 2, -1, -1, 0); 
            crises[2].setStatistics(-1, 0, 0, 0, 0, 1, 0, -3);
        }



        // Procedure which updates the crisis situation for each turn:
        private void updateCrises()
        {
            // --- Crisis Value Implementation: ---
            crises[0].setCrisis((-EC_reserves / EC_gdp) * 100, false);  // Debt Crisis
            crises[1].setCrisis(ST_health, true);                       // Health Crisis
            crises[2].setCrisis(VG_capitalists, true);                  // Corporate Exodus

            // --- Update Crisis Effects ---
            string crisisText = "";
            foreach (Crisis crisis in crises)
            {
                if (crisis.isInEffect)  // If the crisis is in effect.
                {
                    // Update Voter Group Values
                    VG_conservatives += crisis.conservatives;
                    VG_liberals += crisis.liberals;
                    VG_capitalists += crisis.capitalists;
                    VG_socialists += crisis.socialists;
                    VG_nationalists += crisis.nationalists;
                    VG_globalists += crisis.globalists;
                    VG_environmentalists += crisis.environmentalists;

                    // Update National Statistical Values
                    ST_employment += crisis.employment;
                    ST_poverty += crisis.poverty;
                    ST_crime += crisis.crime;
                    ST_health += crisis.health;
                    ST_education += crisis.education;
                    ST_equality += crisis.equality;
                    ST_pollution += crisis.pollution;
                    ST_GDPgrowth += crisis.GDPgrowth;

                    // Add the name of crisis to the crisisText string to be output:
                    crisisText += crisis.name + "\n";
                }
            }

            // Outputs the crisisText string to the CurrentCrisis text block:
            CurrentCrises.Text = crisisText;
        }



        // Procedure which updates the GDP values:
        private void updateGDP()
        {
            EC_gdp += EC_gdp * (Convert.ToDouble(ST_GDPgrowth) / 100);
        }



        // Procedure which saves the information of the current game:
        private void saveGame(string saveName)
        {
            string saveAddress = @"Saves\save" + saveName + ".xml";     // Sets xml save file address

            if (File.Exists(saveAddress))   // If an xml file of the same name already exists
            { File.Delete(saveAddress); }   // Delete that xml file

            XmlWriter xmlSave = XmlWriter.Create(saveAddress);  // Creates the new xml save file

            // Begins the save file writing process.
            xmlSave.WriteStartDocument();
            xmlSave.WriteStartElement("GameSave");

            // Stores the saved game name:
            xmlSave.WriteStartElement("name");
            xmlSave.WriteString(saveName);
            xmlSave.WriteEndElement();

            // Stores the gameplay variables:
            xmlSave.WriteStartElement("gameplay");
            xmlSave.WriteAttributeString("party", GP_party);                      // Player's party
            xmlSave.WriteAttributeString("turn", Convert.ToString(GP_turn));      // Turn value
            xmlSave.WriteAttributeString("power", Convert.ToString(GP_power));    // Power value
            xmlSave.WriteAttributeString("ppt", Convert.ToString(GP_ppt));        // PPT value
            xmlSave.WriteEndElement();

            // Stores the economic variables:
            xmlSave.WriteStartElement("economic");
            xmlSave.WriteAttributeString("reserves", Convert.ToString(EC_reserves));  // Reserves value
            xmlSave.WriteAttributeString("gdp", Convert.ToString(EC_gdp));            // GDP value
            xmlSave.WriteEndElement();

            // Stores the voter group variables:
            xmlSave.WriteStartElement("voters");
            xmlSave.WriteAttributeString("conservatives", Convert.ToString(VG_conservatives));          // Conservative value
            xmlSave.WriteAttributeString("liberals", Convert.ToString(VG_liberals));                    // Liberal value
            xmlSave.WriteAttributeString("capitalists", Convert.ToString(VG_capitalists));              // Capitalist value
            xmlSave.WriteAttributeString("socialists", Convert.ToString(VG_socialists));                // Socialist value
            xmlSave.WriteAttributeString("nationalists", Convert.ToString(VG_nationalists));            // Nationalist value
            xmlSave.WriteAttributeString("globalists", Convert.ToString(VG_globalists));                // Globalist value
            xmlSave.WriteAttributeString("environmentalists", Convert.ToString(VG_environmentalists));  // Environmentalist value
            xmlSave.WriteEndElement();

            // Stores the national statistic variables:
            xmlSave.WriteStartElement("statistics");
            xmlSave.WriteAttributeString("employment", Convert.ToString(ST_employment));  // Employment value
            xmlSave.WriteAttributeString("poverty", Convert.ToString(ST_poverty));        // Poverty value
            xmlSave.WriteAttributeString("crime", Convert.ToString(ST_crime));            // Crime value
            xmlSave.WriteAttributeString("health", Convert.ToString(ST_health));          // Health value
            xmlSave.WriteAttributeString("education", Convert.ToString(ST_education));    // Education value
            xmlSave.WriteAttributeString("equality", Convert.ToString(ST_equality));      // Equality value
            xmlSave.WriteAttributeString("pollution", Convert.ToString(ST_pollution));    // Pollution value
            xmlSave.WriteAttributeString("gdpgrowth", Convert.ToString(ST_GDPgrowth));    // GDP growth value
            xmlSave.WriteEndElement();

            // Stores the activity of all the different policies:
            xmlSave.WriteStartElement("policies");

            foreach (Policy policy in policies)     // Iterates through all policies in the policies list
            {
                string isActivePolicy;  // String holding policy activity save data

                if (policy.active)  // If the policy is active
                { isActivePolicy = "true"; }
                else                // If the policy is inactive
                { isActivePolicy = "false"; }

                // Stores the policy data:
                xmlSave.WriteAttributeString("ID" + Convert.ToString(policy.ID), isActivePolicy);
            }

            xmlSave.WriteEndElement();

            // Ends the save file writing process:
            xmlSave.WriteEndElement();
            xmlSave.WriteEndDocument();   

            xmlSave.Close();              // Closes the save file
        }



        // Application Constructor.
        public MainWindow()
        {
            InitializeComponent();
        }



        // Returns the value if the value is above a lower bound and is below an upper bound.
        private int boundInt(int value, int lower = 0, int upper = 100)
        {
            if (value > upper)  // If the value is greater than the upper value.
            { return upper; }   // Returns upper value.

            else if (value < lower) // If the value is less than the lower value.
            { return lower; }   // Returns lower value.

            return value;   // Returns the original value.
        }



        // Game generation procedure used to generate core gameplay values.
        private void generate
            ( 
            // Boolean loaded game parameter
            bool G_loaded,

            // Political party parameter
            string G_party = null,

            // Loaded game identification parameter
            string saveAddress = null
            )
        {
            // Gameplay generation declarations:
            int G_turn = 0;
            int G_power = 10;
            int G_ppt = 3;

            // Voter group generation declarations:
            int G_cons = 50;
            int G_libs = 50;
            int G_caps = 50;
            int G_socs = 50;
            int G_nats = 50;
            int G_glos = 50;
            int G_envs = 50;

            // Declaration of starting statistic values:
            int G_employment = 75;
            int G_poverty = 7;
            int G_crime = 10;
            int G_health = 50;
            int G_education = 50;
            int G_equality = 50;
            int G_pollution = 50;
            int G_GDPgrowth = 50;

            // Economic generation declarations:
            double G_reserves = -1.56 * 10E12;
            double G_gdp = 2.619 * 10E12;

            // Generates all possible game policies:
            generatePolicies();

            // Generates all possible game crises:
            generateCrises();

            // If this is a new game.
            if (!G_loaded)
            {
                // Party voter opinion setup for non-loaded games:
                // Labour
                if (G_party == "LABOUR")
                {
                    G_cons = 25;
                    G_libs = 60;
                    G_caps = 5;
                    G_socs = 70;
                    G_nats = 30;
                    G_glos = 40;
                    G_envs = 50;
                }

                // Conservative
                else if (G_party == "CONSERVATIVE")
                {
                    G_cons = 60;
                    G_libs = 25;
                    G_caps = 75;
                    G_socs = 5;
                    G_nats = 40;
                    G_glos = 30;
                    G_envs = 30;
                }

                // Error warning
                else
                {
                    MessageBox.Show("An error occured when the application tried to process your choice of party.");
                    this.Close();
                }

            }

            // If this is a loaded game.
            else
            {
                // Loading of the saved xml file:
                XmlDocument loadedSave = new XmlDocument();
                loadedSave.Load(saveAddress);

                // Retrieval of the gameplay data:
                XmlNode GP_node = loadedSave.GetElementsByTagName("gameplay").Item(0);
                G_party = GP_node.Attributes["party"].InnerText;                    // Player party value
                G_turn = Convert.ToInt16(GP_node.Attributes["turn"].InnerText);     // Turn value
                G_power = Convert.ToInt16(GP_node.Attributes["power"].InnerText);   // Power value
                G_ppt = Convert.ToInt16(GP_node.Attributes["ppt"].InnerText);       // PPT value

                // Retrieval of the economic data:
                XmlNode EC_node = loadedSave.GetElementsByTagName("economic").Item(0);
                G_reserves = Convert.ToDouble(EC_node.Attributes["reserves"].InnerText);    // Reserves value
                G_gdp = Convert.ToDouble(EC_node.Attributes["gdp"].InnerText);              // GDP value

                // Retrieval of the voter group data:
                XmlNode VG_node = loadedSave.GetElementsByTagName("voters").Item(0);
                G_cons = Convert.ToInt16(VG_node.Attributes["conservatives"].InnerText);    // Conservative value
                G_libs = Convert.ToInt16(VG_node.Attributes["liberals"].InnerText);         // Liberal value
                G_caps = Convert.ToInt16(VG_node.Attributes["capitalists"].InnerText);      // Capitalist value
                G_socs = Convert.ToInt16(VG_node.Attributes["socialists"].InnerText);       // Socialist value
                G_nats = Convert.ToInt16(VG_node.Attributes["nationalists"].InnerText);     // Nationalist value
                G_glos = Convert.ToInt16(VG_node.Attributes["globalists"].InnerText);       // Globalist value
                G_envs = Convert.ToInt16(VG_node.Attributes["environmentalists"].InnerText);// Environmentalist value

                // Retrieval of the national statistic data:
                XmlNode ST_node = loadedSave.GetElementsByTagName("statistics").Item(0);
                G_employment = Convert.ToInt16(ST_node.Attributes["employment"].InnerText); // Employment value
                G_poverty = Convert.ToInt16(ST_node.Attributes["poverty"].InnerText);       // Poverty value
                G_crime = Convert.ToInt16(ST_node.Attributes["crime"].InnerText);           // Crime value
                G_health = Convert.ToInt16(ST_node.Attributes["health"].InnerText);         // Health value
                G_education = Convert.ToInt16(ST_node.Attributes["education"].InnerText);   // Education value
                G_equality = Convert.ToInt16(ST_node.Attributes["equality"].InnerText);     // Equality value
                G_pollution = Convert.ToInt16(ST_node.Attributes["pollution"].InnerText);   // Pollution value
                G_GDPgrowth = Convert.ToInt16(ST_node.Attributes["gdpgrowth"].InnerText);   // GDP growth value

                // Retrieval of policy data:
                XmlNode policy_node = loadedSave.GetElementsByTagName("policies").Item(0);

                foreach (Policy policy in policies)   // Iterates through every policy in the policies list
                {
                    // Sets the policy activity depending on the saved data value:
                    policy.active = Convert.ToBoolean(policy_node.Attributes["ID" + Convert.ToString(policy.ID)].InnerText);
                }
            }



            // Final game play value generation:
            // Gameplay values:
            GP_party = G_party;
            GP_turn = G_turn;
            GP_power = G_power;
            GP_ppt = G_ppt;

            // Voter group values:
            VG_conservatives = G_cons;
            VG_liberals = G_libs;
            VG_capitalists = G_caps;
            VG_socialists = G_socs;
            VG_nationalists = G_nats;
            VG_globalists = G_glos;
            VG_environmentalists = G_envs;

            // National Statistic Values:
            ST_employment = G_employment;
            ST_poverty = G_poverty;
            ST_crime = G_crime;
            ST_health = G_health;
            ST_education = G_education;
            ST_equality = G_equality;
            ST_pollution = G_pollution;
            ST_GDPgrowth = G_GDPgrowth;

            // Economic values:
            EC_reserves = G_reserves;
            EC_gdp = G_gdp;
        }



        // Function which calculates the vote share for each of the parties.
        private List<double> calculateShare()
        {
            // Declaration of Party Vote Share Variables
            double conShare;
            double labShare;
            double libShare;
            double ukipShare;
            double greenShare;
            double snpShare;
            double othShare;


            // Declaration of the returned vote share by party list.
            List<double> partyShares = new List<double>();


            // Declaration of the political group vote share variables.
            int EL_conservatives = VG_conservatives;
            int EL_liberals = VG_liberals;
            int EL_capitalists = VG_capitalists;
            int EL_socialists = VG_socialists;
            int EL_nationalists = VG_nationalists;
            int EL_globalists = VG_globalists;
            int EL_environmentalists = VG_environmentalists;


            // Implementation of randomised vote share variation.
            int minVary = -2;
            int maxVary = 2;
            Random rnd = new Random();  // Declares Random object as rnd.


            // Setting of the vote share for each voter group with the vote share variation.
            EL_conservatives = boundInt(EL_conservatives + rnd.Next(minVary, maxVary));
            EL_liberals = boundInt(EL_liberals + rnd.Next(minVary, maxVary));
            EL_capitalists = boundInt(EL_capitalists + rnd.Next(minVary, maxVary));
            EL_socialists = boundInt(EL_socialists + rnd.Next(minVary, maxVary));
            EL_nationalists = boundInt(EL_nationalists + rnd.Next(minVary, maxVary));
            EL_globalists = boundInt(EL_globalists + rnd.Next(minVary, maxVary));
            EL_environmentalists = boundInt(EL_environmentalists + rnd.Next(minVary, maxVary));


            // Calculation of Larger (Playable) Party Values:
            // If the player is playing as the Conservative Party:
            if (GP_party == "CONSERVATIVE")
            {
                // Calculation of Conservative Vote Share:
                conShare = (Convert.ToDouble(EL_conservatives + EL_liberals + EL_capitalists + 
                    EL_socialists + EL_nationalists + EL_globalists + EL_environmentalists) / 7) * 0.8;

                // Calculation of Labour Vote Share:
                labShare = Convert.ToDouble((100 - EL_conservatives) * 0.01);
                labShare += Convert.ToDouble((100 - EL_liberals) * 0.8);
                labShare += Convert.ToDouble((100 - EL_capitalists) * 0);
                labShare += Convert.ToDouble((100 - EL_socialists) * 0.85);
                labShare += Convert.ToDouble((100 - EL_nationalists) * 0.6);
                labShare += Convert.ToDouble((100 - EL_globalists) * 0.75);
                labShare += Convert.ToDouble((100 - EL_environmentalists) * 0.7);
                labShare = labShare / 7;
            }

            // If the player is playing as the Labour Party:
            else
            {
                // Calculation of Labour Vote Share:
                labShare = (Convert.ToDouble(EL_conservatives + EL_liberals + EL_capitalists + 
                    EL_socialists + EL_nationalists + EL_globalists + EL_environmentalists) / 7) * 0.8;

                // Calculation of Conservative Vote Share:
                conShare = Convert.ToDouble((100 - EL_conservatives) * 0.8);
                conShare += Convert.ToDouble((100 - EL_liberals) * 0.4);
                conShare += Convert.ToDouble((100 - EL_capitalists) * 0.7);
                conShare += Convert.ToDouble((100 - EL_socialists) * 0);
                conShare += Convert.ToDouble((100 - EL_nationalists) * 0.75);
                conShare += Convert.ToDouble((100 - EL_globalists) * 0.5);
                conShare += Convert.ToDouble((100 - EL_environmentalists) * 0.2);
                conShare = conShare / 7;
            }


            // Calculation of Smaller (Unplayable) Party Values:
            // Liberal Democrats
            if (GP_party == "LABOUR")   // If the player is playing as the Labour Party.
            {
                libShare = Convert.ToDouble((100 - EL_conservatives) * 0.05);
                libShare += Convert.ToDouble((100 - EL_liberals) * 0.5);
                libShare += Convert.ToDouble((100 - EL_capitalists) * 0.2);
                libShare += Convert.ToDouble((100 - EL_socialists) * 0.2);
                libShare += Convert.ToDouble((100 - EL_nationalists) * 0.0);
                libShare += Convert.ToDouble((100 - EL_globalists) * 0.1);
                libShare += Convert.ToDouble((100 - EL_environmentalists) * 0.2);
                libShare = libShare / 7;
            }

            else    // If the player is not playing as the Labour Party.
            {
                libShare = Convert.ToDouble((100 - EL_conservatives) * 0.3);
                libShare += Convert.ToDouble((100 - EL_liberals) * 0.2);
                libShare += Convert.ToDouble((100 - EL_capitalists) * 0.4);
                libShare += Convert.ToDouble((100 - EL_socialists) * 0);
                libShare += Convert.ToDouble((100 - EL_nationalists) * 0);
                libShare += Convert.ToDouble((100 - EL_globalists) * 0.1);
                libShare += Convert.ToDouble((100 - EL_environmentalists) * 0.1);
                libShare = libShare / 7;
            }

            // UKIP
            if (GP_party == "LABOUR")   // If the player is playing as the Labour Party.
            {
                ukipShare = Convert.ToDouble((100 - EL_conservatives) * 0.19);
                ukipShare += Convert.ToDouble((100 - EL_liberals) * 0);
                ukipShare += Convert.ToDouble((100 - EL_capitalists) * 0.08);
                ukipShare += Convert.ToDouble((100 - EL_socialists) * 0.1);
                ukipShare += Convert.ToDouble((100 - EL_nationalists) * 0.3);
                ukipShare += Convert.ToDouble((100 - EL_globalists) * 0);
                ukipShare += Convert.ToDouble((100 - EL_environmentalists) * 0);
                ukipShare = ukipShare / 7;
            }

            else    // If the player is not playing as the Labour Party.
            {
                ukipShare = Convert.ToDouble((100 - EL_conservatives) * 0.5);
                ukipShare += Convert.ToDouble((100 - EL_liberals) * 0);
                ukipShare += Convert.ToDouble((100 - EL_capitalists) * 0.4);
                ukipShare += Convert.ToDouble((100 - EL_socialists) * 0);
                ukipShare += Convert.ToDouble((100 - EL_nationalists) * 0.3);
                ukipShare += Convert.ToDouble((100 - EL_globalists) * 0);
                ukipShare += Convert.ToDouble((100 - EL_environmentalists) * 0);
                ukipShare = ukipShare / 7;
            }

            // Green Party
            if (GP_party == "LABOUR")   // If the player is playing as the Labour Party.
            {
                greenShare = Convert.ToDouble((100 - EL_conservatives) * 0);
                greenShare += Convert.ToDouble((100 - EL_liberals) * 0.03);
                greenShare += Convert.ToDouble((100 - EL_capitalists) * 0);
                greenShare += Convert.ToDouble((100 - EL_socialists) * 0.3);
                greenShare += Convert.ToDouble((100 - EL_nationalists) * 0);
                greenShare += Convert.ToDouble((100 - EL_globalists) * 0);
                greenShare += Convert.ToDouble((100 - EL_environmentalists) * 0.4);
                greenShare = greenShare / 7;
            }

            else    // If the player is not playing as the Labour Party.
            {
                greenShare = Convert.ToDouble((100 - EL_conservatives) * 0);
                greenShare += Convert.ToDouble((100 - EL_liberals) * 0.05);
                greenShare += Convert.ToDouble((100 - EL_capitalists) * 0.0);
                greenShare += Convert.ToDouble((100 - EL_socialists) * 0.3);
                greenShare += Convert.ToDouble((100 - EL_nationalists) * 0);
                greenShare += Convert.ToDouble((100 - EL_globalists) * 0);
                greenShare += Convert.ToDouble((100 - EL_environmentalists) * 0.2);
                greenShare = greenShare / 7;
            }
            // SNP
            if (GP_party == "LABOUR")   // If the player is playing as the Labour Party.
            {
                snpShare = Convert.ToDouble((100 - EL_conservatives) * 0);
                snpShare += Convert.ToDouble((100 - EL_liberals) * 0.02);
                snpShare += Convert.ToDouble((100 - EL_capitalists) * 0);
                snpShare += Convert.ToDouble((100 - EL_socialists) * 0.2);
                snpShare += Convert.ToDouble((100 - EL_nationalists) * 0.1);
                snpShare += Convert.ToDouble((100 - EL_globalists) * 0);
                snpShare += Convert.ToDouble((100 - EL_environmentalists) * 0);
                snpShare = snpShare / 7;
            }

            else    // If the player is not playing as the Labour Party.
            {
                snpShare = Convert.ToDouble((100 - EL_conservatives) * 0);
                snpShare += Convert.ToDouble((100 - EL_liberals) * 0.05);
                snpShare += Convert.ToDouble((100 - EL_capitalists) * 0.0);
                snpShare += Convert.ToDouble((100 - EL_socialists) * 0.05);
                snpShare += Convert.ToDouble((100 - EL_nationalists) * 0.1);
                snpShare += Convert.ToDouble((100 - EL_globalists) * 0);
                snpShare += Convert.ToDouble((100 - EL_environmentalists) * 0);
                snpShare = snpShare / 7;
            }

            // Other
            othShare = 100 - (conShare + labShare + libShare + ukipShare + greenShare + snpShare);

            if (othShare < 0)   // If the othShare is negative, it is made to be positive.
            { othShare = othShare * -1; }


            // Formatting and implementation of the vote share values into the returned list:
            double totalShare = conShare + labShare + libShare + ukipShare + greenShare + snpShare + othShare;

            partyShares.Add((conShare / totalShare) * 100);
            partyShares.Add((labShare / totalShare) * 100);
            partyShares.Add((libShare / totalShare) * 100);
            partyShares.Add((ukipShare / totalShare) * 100);
            partyShares.Add((greenShare / totalShare) * 100);
            partyShares.Add((snpShare / totalShare) * 100);
            partyShares.Add((othShare / totalShare) * 100);

            return partyShares; // Returns the vote share for each party within the declared list data type.
        }



        // Function which tests whether there are any active policies.
        private bool anyActive()
        {
            // Iterates through each policy in the policies list.
            foreach (Policy policy in policies)
            {
                // If the policy is active, return true boolean value.
                if (policy.active)
                { return true; }
            }

            // If no policies are active, return false boolean value.
            return false;
        }



        // Sub-routine that selects policy based on what the user has chosen through the two drop down lists of policies.
        private void selectPolicy(ComboBox policyList)
        {
            // Converts the name of the selected item in the drop down list into a string.
            string policyName = Convert.ToString(policyList.SelectedItem);

            // Iterates through each policy in the policies list.
            foreach (Policy policy in policies)
            {
                // Tests if the name of policy (in the policies list) has the same name as the selected policy (via the drop down list).
                if (policy.name == policyName)
                { selectedPolicy = policy; }

            }

            // Updates the interface based on the selected policy.
            PolicyName.Content = selectedPolicy.name;                                                   // Policy name.
            PolicyDesc.Text = selectedPolicy.description;                                               // Policy descirpition.
            PolicyDesc.Text += "\n\nCosts: £" + Convert.ToString(selectedPolicy.costs / 10E9) + " Bn";  // Policy costs.
            PolicyDesc.Text += "\nIncome: £" + Convert.ToString(selectedPolicy.income / 10E9) + " Bn";  // Policy income.
            PolicyDesc.Text += "\n\nRequired Power: " + Convert.ToString(selectedPolicy.req_power);     // Policy power required.

            // Updates the enact/repeal button (ToggleActivityButton) to include appropriate text.
            // If policy is already active.
            if (selectedPolicy.active)
            { ToggleActivityButton.Content = "Repeal Policy"; }

            // If policy is not active.
            else
            { ToggleActivityButton.Content = "Enact Policy"; }
        }



        // Procedure which updates the statistics tab at the top of the main game interface.
        private void updateStatTab()
        {
            // Calculates whether a budget surplus or defecit is present:
            bool isSurplus;
            if (EC_surplus > -1)
            { isSurplus = true; }
            else
            { isSurplus = false; }


            // Calculates whether reserves are present or whether debt is owed:
            bool isDebt;
            if (EC_reserves < 0)
            { isDebt = true; }
            else
            { isDebt = false; }

            string StatData;
            StatData = "Turn: " + Convert.ToString(GP_turn) + "    ";                               // Adds turn statistic.
            StatData += "Power: " + Convert.ToString(GP_power) + "    ";                            // Adds power statistic.

            if (isSurplus)                                                                          // If there is a budget surplus.
            { StatData += "Surplus: £" + Convert.ToString(EC_surplus / 10E9) + " Bn    "; }         // Adds surplus statistic.

            else                                                                                    // If there is a budget deficit.
            { StatData += "Deficit: £" + Convert.ToString((EC_surplus * -1) / 10E9) + " Bn    "; }  // Adds defecit statistic.

            if (isDebt)                                                                             // If there is debt.
            { StatData += "Debt: £" + Convert.ToString((EC_reserves * -1) / 10E9) + " Bn"; }        // Adds debt statistic.

            else                                                                                    // If there is no debt.
            { StatData += "Reserves: £" + Convert.ToString(EC_reserves / 10E9) + " Bn"; }           // Adds reserves statistic.

            StatTab.Content = StatData;     // Implements all these statistics into the statistical tab at teh top of the main game interface.
        }



        // Function which calculates the seats won for each party.
        private List<int> calculateSeats(List<double> voteShare)
        {
            List<int> seatsWon = new List<int>(); // Declaration of the returned list variable which holds data of the seats won.


            // Declaration of vote share variables by party:
            double conShare = voteShare[0];
            double labShare = voteShare[1];
            double libShare = voteShare[2];
            double ukipShare = voteShare[3];
            double greenShare = voteShare[4];
            double snpShare = voteShare[5];
            double othShare = voteShare[6];


            // Declaration of seats won variables by party:
            int conSeats = 0;
            int labSeats = 0;
            int libSeats = 0;
            int ukipSeats = 0;
            int greenSeats = 0;
            int snpSeats = 0;
            int othSeats = 0;


            // Declaration of seat statistics:
            int seatsEng = 533;
            int seatsScot = 59;
            int seatsWales = 40;
            int seatsNI = 18;


            // Implementation of seats won for parties in England:
            // Declaration of English vote share variables:
            List<double> voteShareEng = new List<double>();

            voteShareEng.Add(voteShare[0] * 1.094511906);   // Conservatives
            voteShareEng.Add(voteShare[1] * 1.0186464);     // Labour
            voteShareEng.Add(voteShare[2] * 1.04806755);    // Liberal Democrats
            voteShareEng.Add(voteShare[3] * 1.12957406);    // UKIP
            voteShareEng.Add(voteShare[4] * 1.097587719);   // Green
            voteShareEng.Add(voteShare[5] * 0);             // SNP
            voteShareEng.Add(voteShare[6] * 0.346360114);   // Other

            // Calculation of seats won without further data formatting:
            List<double> seatsUnformattedEng = new List<double>();

            foreach (double partyShareEng in voteShareEng)
            { seatsUnformattedEng.Add(0.1657 * (partyShareEng * partyShareEng) + 0.0465 * (partyShareEng) - 5.2447); }

            // Calculation of seats won with further data formatting:
            for (int i = 0; i < 7; i++)
            {
                if (seatsUnformattedEng[i] < 0)
                { seatsUnformattedEng[i] = 0; }
            }

            double totalUnformSeatsEng = 0;
            foreach (double partySeatsWon in seatsUnformattedEng)
            { totalUnformSeatsEng += partySeatsWon; }

            conSeats += Convert.ToInt16((seatsUnformattedEng[0] / totalUnformSeatsEng) * seatsEng);
            labSeats += Convert.ToInt16((seatsUnformattedEng[1] / totalUnformSeatsEng) * seatsEng);
            libSeats += Convert.ToInt16((seatsUnformattedEng[2] / totalUnformSeatsEng) * seatsEng);
            ukipSeats += Convert.ToInt16((seatsUnformattedEng[3] / totalUnformSeatsEng) * seatsEng);
            greenSeats += Convert.ToInt16((seatsUnformattedEng[4] / totalUnformSeatsEng) * seatsEng);
            snpSeats += Convert.ToInt16((seatsUnformattedEng[5] / totalUnformSeatsEng) * seatsEng);
            othSeats += Convert.ToInt16((seatsUnformattedEng[6] / totalUnformSeatsEng) * seatsEng);


            // Implementation of seats won for parties in Scotland:
            // Declaration of Scottish vote share variables:
            List<double> voteShareScot = new List<double>();

            voteShareScot.Add(voteShare[0] * 0.513642073);  // Conservatives
            voteShareScot.Add(voteShare[1] * 0.975039322);  // Labour
            voteShareScot.Add(voteShare[2] * 0.896675046);  // Liberal Democrats
            voteShareScot.Add(voteShare[3] * 0.153649523);  // UKIP
            voteShareScot.Add(voteShare[4] * 0.389035088);  // Green
            voteShareScot.Add(voteShare[5] * 11.54806008);  // SNP
            voteShareScot.Add(voteShare[6] * 0.116868836);  // Other

            // Calculation of seats won without further data formatting:
            List<double> seatsUnformattedScot = new List<double>();

            foreach (double partyShareScot in voteShareScot)
            { seatsUnformattedScot.Add(0.0342 * (partyShareScot * partyShareScot) - 0.04573 * (partyShareScot) + 1.2695); }

            // Calculation of seats won with further data formatting:
            for (int i = 0; i < 7; i++)
            {
                if (seatsUnformattedScot[i] < 0)
                { seatsUnformattedScot[i] = 0; }
            }

            double totalUnformSeatsScot = 0;
            foreach (double partySeatsWon in seatsUnformattedScot)
            { totalUnformSeatsScot += partySeatsWon; }

            conSeats += Convert.ToInt16((seatsUnformattedScot[0] / totalUnformSeatsScot) * seatsScot);
            labSeats += Convert.ToInt16((seatsUnformattedScot[1] / totalUnformSeatsScot) * seatsScot);
            libSeats += Convert.ToInt16((seatsUnformattedScot[2] / totalUnformSeatsScot) * seatsScot);
            ukipSeats += Convert.ToInt16((seatsUnformattedScot[3] / totalUnformSeatsScot) * seatsScot);
            greenSeats += Convert.ToInt16((seatsUnformattedScot[4] / totalUnformSeatsScot) * seatsScot);
            snpSeats += Convert.ToInt16((seatsUnformattedScot[5] / totalUnformSeatsScot) * seatsScot);
            othSeats += Convert.ToInt16((seatsUnformattedScot[6] / totalUnformSeatsScot) * seatsScot);


            // Implementation of seats won for parties in Wales:
            // Declaration of Welsh vote share variables:
            List<double> voteShareWales = new List<double>();

            voteShareWales.Add(voteShare[0] * 0.7508573);   // Conservatives
            voteShareWales.Add(voteShare[1] * 1.22819722);  // Labour
            voteShareWales.Add(voteShare[2] * 0.76826865);  // Liberal Democrats
            voteShareWales.Add(voteShare[3] * 0.97985608);  // UKIP
            voteShareWales.Add(voteShare[4] * 0.42390351);  // Green
            voteShareWales.Add(voteShare[5] * 0);           // SNP
            voteShareWales.Add(voteShare[6] * 3.04145731);  // Other

            // Calculation of seats won without further data formatting:
            List<double> seatsUnformattedWales = new List<double>();

            foreach (double partyShareWales in voteShareWales)
            { seatsUnformattedWales.Add(0.0162 * (partyShareWales * partyShareWales) - 0.01313 * (partyShareWales) + 0.7402); }

            // Calculation of seats won with further data formatting:
            for (int i = 0; i < 7; i++)
            {
                if (seatsUnformattedWales[i] < 0)
                { seatsUnformattedWales[i] = 0; }
            }

            double totalUnformSeatsWales = 0;
            foreach (double partySeatsWon in seatsUnformattedWales)
            { totalUnformSeatsWales += partySeatsWon; }

            conSeats += Convert.ToInt16((seatsUnformattedWales[0] / totalUnformSeatsWales) * seatsWales);
            labSeats += Convert.ToInt16((seatsUnformattedWales[1] / totalUnformSeatsWales) * seatsWales);
            libSeats += Convert.ToInt16((seatsUnformattedWales[2] / totalUnformSeatsWales) * seatsWales);
            ukipSeats += Convert.ToInt16((seatsUnformattedWales[3] / totalUnformSeatsWales) * seatsWales);
            greenSeats += Convert.ToInt16((seatsUnformattedWales[4] / totalUnformSeatsWales) * seatsWales);
            snpSeats += Convert.ToInt16((seatsUnformattedWales[5] / totalUnformSeatsWales) * seatsWales);
            othSeats += Convert.ToInt16((seatsUnformattedWales[6] / totalUnformSeatsWales) * seatsWales);


            // Implementation of seats won for parties in Northern Ireland:
            othSeats += seatsNI;


            // Implementation of the seats won data into the returned list:
            seatsWon.Add(conSeats);
            seatsWon.Add(labSeats);
            seatsWon.Add(libSeats);
            seatsWon.Add(ukipSeats);
            seatsWon.Add(greenSeats);
            seatsWon.Add(snpSeats);
            seatsWon.Add(othSeats);

            return seatsWon;    // Returns the seatsWon list with the seats won by different parties held inside it.
        }



        // Procedure which triggers an in-game election.
        private void triggerElection()
        {
            GP_turn = 0;    // Resets the turn value.

            MainInterface.Visibility = Visibility.Hidden;       // Hides the main game interface.
            ElectionInterface.Visibility = Visibility.Visible;  // Shows the election interface.


            List<double> partyShares = calculateShare();    // Calculates the election vote share.

            List<int> partySeats = calculateSeats(partyShares); // Calculates the election seats won.

            // If the Conservative party has more seats:
            if (partySeats[0] > partySeats[1])
            {
                // Sets the interface label (VictoryLabel) so that it tells the user to Tory party has won:
                VictoryLabel.Content = "CONSERVATIVE VICTORY";

                if (GP_party == "CONSERVATIVE") // If the player is playing as the Tory party.
                {
                    GP_victory = true;  // Victory variable set to true.

                    if (partySeats[0] > 325)    // If the player has a number of seats above 225.
                    {
                        // Sets the new power per turn for the game.
                        GP_ppt = boundInt(Convert.ToInt16((partySeats[0] - 325) * 0.2), 2, 15);  
                    }
                    else
                    {
                        GP_ppt = 1;     // Sets the new power per turn for the game. 
                    }
                }

                else                            // If the player is playing as the Labour party.
                { GP_victory = false; }         // Victory variable set to false.
            }

            // If the Labour party has more seats:
            else
            {
                // Sets the interface label (VictoryLabel) so that it tells the user to Labour party has won:
                VictoryLabel.Content = "LABOUR VICTORY";

                if (GP_party == "LABOUR")       // If the player is playing as the labour party.
                {
                    GP_victory = true;  // Victory variable set to true.

                    if (partySeats[1] > 325)    // If the player has a number of seats above 225.
                    {
                        // Sets the new power per turn for the game.
                        GP_ppt = boundInt(Convert.ToInt16((partySeats[1] - 325) * 0.2), 2, 15);  
                    }
                    else
                    {
                        GP_ppt = 1;     // Sets the new power per turn for the game. 
                    }
                }

                else                            // If the player is playing as the Tory party.
                { GP_victory = false; }         // Victory variable set to false.
            }


            // Sets the VoteShareBlock to output the vote shares for each party:
            VoteShareBlock.Text =
                "CON: " + String.Format("{0:0.00}", partyShares[0]) +       // Conservative Vote Share
                "%\nLAB: " + String.Format("{0:0.00}", partyShares[1]) +    // Labour Vote Share
                "%\nLD: " + String.Format("{0:0.00}", partyShares[2]) +     // Lib Dem Vote Share
                "%\nUKIP: " + String.Format("{0:0.00}", partyShares[3]) +   // UKIP Vote Share
                "%\nGREEN: " + String.Format("{0:0.00}", partyShares[4]) +  // Green Vote Share
                "%\nSNP: " + String.Format("{0:0.00}", partyShares[5]) +    // SNP Vote Share
                "%\nOTHER: " + String.Format("{0:0.00}", partyShares[6]) +  // Other Vote Share
                "%";


            // Sets the SeatsWonBlock to output the seats won for each party:
            SeatsWonBlock.Text =
                "CON: " + Convert.ToString(partySeats[0]) +      // Conservative Seats Won
                "\nLAB: " + Convert.ToString(partySeats[1]) +    // Labour Seats Won
                "\nLD: " + Convert.ToString(partySeats[2]) +     // Lib Dem Seats Won
                "\nUKIP: " + Convert.ToString(partySeats[3]) +   // UKIP Seats Won
                "\nGREEN: " + Convert.ToString(partySeats[4]) +  // Green Seats Won
                "\nSNP: " + Convert.ToString(partySeats[5]) +    // SNP Seats Won
                "\nOTH: " + Convert.ToString(partySeats[6]);     // Other Seats Won


            if (GP_victory) // If the player won the election.
            { ElectionButton.Content = "Continue"; }    // Set the ElectionButton content to "Continue".

            else    // If the player loses the election.
            { ElectionButton.Content = "Admit Defeat"; }    // Set the ElectionButton content to "Admit Defeat".
        }



        // Procedure which makes statistics affect voter groups:
        private void voterStatInitialisation
            (int voterGroup, double employment, double poverty, double crime, double health, 
            double education, double equality, double pollution, double GDPgrowth)
        {
            voterGroup += Convert.ToInt16((50 - ST_employment) * employment);   // Employment effects
            voterGroup += Convert.ToInt16((50 - ST_poverty) * poverty);         // Poverty effects
            voterGroup += Convert.ToInt16((ST_crime) * crime);                  // Crime effects
            voterGroup += Convert.ToInt16((20 - ST_health) * health);           // Health effects
            voterGroup += Convert.ToInt16((50 - ST_education) * education);     // Education effects
            voterGroup += Convert.ToInt16((50 - ST_equality) * equality);       // Equality effects
            voterGroup += Convert.ToInt16((30 - ST_pollution) * pollution);     // Pollution effects
            voterGroup += Convert.ToInt16((50 - ST_GDPgrowth) * GDPgrowth);     // GDP growth effects
        }

        

        // Turn setup procedure.
        private void turnSetup()
        {
            // If the last turn was turn 20, initiate an election.
            if (GP_turn == 20)
            {
                triggerElection();  // Election takes place.
            }
            // If the last turn was not 20, do not initiate an election and continue another turn.
            else
            {
                GP_turn += 1;   // Increases the turn value by 1.
                GP_power = boundInt(GP_power + GP_ppt, 0, 60);  // Increases the power value by power per turn and the left over power last turn.
                EC_income = 0;
                EC_spending = 0;

                // Clears all items in ComboBoxs: ActivePolicies and InactivePolicies,
                ActivePolicies.Items.Clear();
                InactivePolicies.Items.Clear();

                // Iterates through every policy in the policy list.
                foreach (Policy policy in policies)
                {
                    // If this policy is active.
                    if (policy.active)
                    {
                        // Adds policy to activ epolicy drop down list.
                        ActivePolicies.Items.Add(policy.name);

                        // Implementation of policy economic values.
                        EC_income += policy.income;
                        EC_spending += policy.costs;
                        EC_gdp += policy.gdp;
                        
                        // Implementation of policy national statistical values.
                        ST_employment += policy.employment;
                        ST_poverty += policy.poverty;
                        ST_crime += policy.crime;
                        ST_health += policy.health;
                        ST_education += policy.education;
                        ST_equality += policy.equality;
                        ST_pollution += policy.pollution;
                        ST_GDPgrowth += policy.GDPgrowth;
                    }
                    // If this policy is inactive.
                    else
                    { InactivePolicies.Items.Add(policy.name); }
                }
                
                
                // National statistical values.
                ST_employment = boundInt(ST_employment);
                ST_poverty = boundInt(ST_poverty);
                ST_crime = boundInt(ST_crime);
                ST_health = boundInt(ST_health);
                ST_education = boundInt(ST_education);
                ST_equality = boundInt(ST_equality);
                ST_pollution = boundInt(ST_pollution);
                ST_GDPgrowth = boundInt(ST_GDPgrowth);


                // Voter group values.
                // Conservatives:
                voterStatInitialisation(VG_conservatives, 0.3, -0.1, -0.5, 0.1, 0.2, -0.2, 0, 0.5);
                VG_conservatives = boundInt(VG_conservatives);

                // Liberals:
                voterStatInitialisation(VG_liberals, 0.5, -0.3, -0.3, 0.3, 0.5, 0.5, 0, 0);
                VG_liberals = boundInt(VG_liberals);

                // Capitalists:
                voterStatInitialisation(VG_capitalists, 0.1, 0, -0.5, 0, 0, -0.4, 0, 0.7);
                if (EC_income > EC_spending)    // If income is greater than spending.
                { VG_capitalists += 3; }
                else                            // If income is not greater than spending.
                { VG_capitalists -= 1; }
                VG_capitalists = boundInt(VG_capitalists);

                // Socialists:
                voterStatInitialisation(VG_socialists, 0.1, -0.4, -0.1, 0.6, 0.4, 0.8, 0, 0);
                VG_socialists = boundInt(VG_socialists);

                // Nationalists:
                voterStatInitialisation(VG_nationalists, 0.4, -0.2, -0.6, 0.3, 0.3, 0, 0, 0.1);
                VG_nationalists = boundInt(VG_nationalists);

                // Globalists:
                voterStatInitialisation(VG_globalists, 0.4, -0.2, -0.2, 0.4, 0.4, 0.2, 0, 0.3);
                VG_globalists = boundInt(VG_globalists);

                // Environmentalists:
                voterStatInitialisation(VG_environmentalists, 0.4, -0.2, 0, 0.5, 0.5, 0.2, -0.8, 0.1);
                VG_environmentalists = boundInt(VG_environmentalists);


                // Calculation of other economic values:
                EC_surplus = EC_income - EC_spending;
                EC_reserves += EC_surplus;


                // Updates the Statistical Tab (StatTab) in the user interface.
                updateStatTab();

                // Updates the GDP value.
                updateGDP();

                // Updates the Crises system.
                updateCrises();
                
                

                // Resets the selected index of the active and inactive policy ComboBoxes to the first options (0)
                ActivePolicies.SelectedIndex = 0;
                InactivePolicies.SelectedIndex = 0;

                // Selects a policy to show to the user when a new turn begins.
                // Policy shown is the first in the ActivePolicies ComboBox.
                // If no active policies, policy shown is teh first in InactivePolicies ComboBox.
                if (anyActive())
                { selectPolicy(ActivePolicies); }
                else
                { selectPolicy(InactivePolicies); }


                // Sets the polling values for each party this turn:
                polling = calculateShare();
            }
        }



        // Opens StartMenu when NewButton is clicked.
        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            GameMenu.Visibility = Visibility.Hidden;    // Hides the GameMenu interface.
            StartMenu.Visibility = Visibility.Visible;  // Shows the StartMenu interface.
        }



        // Closes StartMenu when NewBackButton is clicked.
        private void NewBackButton_Click(object sender, RoutedEventArgs e)
        {
            StartMenu.Visibility = Visibility.Hidden;   // Hides the StartMenu interface.
            GameMenu.Visibility = Visibility.Visible;   // Shows the GameMenu interface.
        }



        // Event procedure which generates the svaed game XML file address when a button is pressed in SavedGameList.
        private void loadSaveAddress(object sender, RoutedEventArgs e)
        {
            Button SaveButton = (Button)sender; // Sets the sender object as a button.

            generate(true, null, (string)SaveButton.Tag);   // Generates game values.
            turnSetup();    // Sets up a new turn.

            LoadMenu.Visibility = Visibility.Hidden;        // Hides the LoadMenu.
            MainInterface.Visibility = Visibility.Visible;  // Shows the MainInterface.
        }



        // Opens LoadMenu when LoadButton is clicked.
        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            GameMenu.Visibility = Visibility.Hidden;    // Hides the GameMenu interface.
            LoadMenu.Visibility = Visibility.Visible;   // Shows the LoadMenu interface.

            SavedGamesList.Items.Clear();   // Resets and clears the SavedGamesList ListBox of buttons.

            // --- Finding XML Save Files ---
            string[] allFiles = Directory.GetFiles(@"Saves");   // Gets all files in Saves folder.

            foreach (string fileAddress in allFiles)   // Iterates through all file names of files in Saves folder.
            {
                string fileName = fileAddress.Substring(6, fileAddress.Length-6);

                if (fileName.Contains("save"))  // If the file name contains the string "save".
                {   // Formatting:
                    Button SaveNameButton = new Button();  // Declares button object for this save for interface use.
                    SaveNameButton.Height = 61; // Sets button height.
                    SaveNameButton.Width = 750; // Sets button width.
                    // Sets black border colour:
                    SaveNameButton.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Black"));
                    // Sets white background colour:
                    SaveNameButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("White"));
                    SaveNameButton.BorderThickness = new Thickness(2,2,2,2);    // Sets the border thickness.
                    SaveNameButton.FontFamily = new FontFamily("Book Antiqua"); // Sets button text font.
                    SaveNameButton.FontSize = 48;   // Sets the button font size.

                    // Saves the file address in the button as a tag:
                    SaveNameButton.Tag = fileAddress;

                    // Sets the event procedure that is called when the button is clicked:
                    SaveNameButton.Click += loadSaveAddress;

                    // Loading of the saved xml file:
                    XmlDocument loadedSave = new XmlDocument();
                    loadedSave.Load(fileAddress);

                    // Sets the Content of the button to the name of the save:
                    XmlNode nameNode = loadedSave.GetElementsByTagName("name").Item(0);
                    SaveNameButton.Content = nameNode.InnerText;

                    // Adds button to the SaveGamesList ListBox:
                    SavedGamesList.Items.Add(SaveNameButton);
                }
            }
        }



        // Closes loadMenu when NewBackButton is clicked.
        private void LoadBackButton_Click(object sender, RoutedEventArgs e)
        {
            LoadMenu.Visibility = Visibility.Hidden;    // Hides the LoadMenu interface.
            GameMenu.Visibility = Visibility.Visible;   // Shows the GameMenu interface.
        }



        // Starts game as the Labour Party when LabourButton is clicked.
        private void LabourButton_Click(object sender, RoutedEventArgs e)
        {
            StartMenu.Visibility = Visibility.Hidden;   // Hides the StartMenu interface.
            generate(false, "LABOUR");  // Generates all of the values and data required to begin a game.
            turnSetup();                // Sets up a new turn.
            MainInterface.Visibility = Visibility.Visible;  // Shows the MainInterface.
        }



        // Starts game as the Conservative Party when ToryButton is clicked.
        private void ToryButton_Click(object sender, RoutedEventArgs e)
        {
            StartMenu.Visibility = Visibility.Hidden;   // Hides the StartMenu interface.
            generate(false, "CONSERVATIVE");    // Generates all of the values and data required to begin a game.
            turnSetup();                        // Sets up a new turn.
            MainInterface.Visibility = Visibility.Visible;  // Shows the MainInterface.
        }



        // Starts a new turn when NextTurnButton is clicked.
        private void NextTurnButton_Click(object sender, RoutedEventArgs e)
        {
            turnSetup();
        }



        // Selects the policy that has been chosen by the user via the list of active policies (ActivePolicies).
        private void ActivePolicies_DropDownClosed(object sender, EventArgs e)
        {
            selectPolicy(ActivePolicies);
        }



        // Selects the policy that has been chosen by the user via the list of inactive policies (InactivePolicies).
        private void InactivePolicies_DropDownClosed(object sender, EventArgs e)
        {
            selectPolicy(InactivePolicies);
        }



        // Enacts/repeals selected policy when ToggleActivityButton is clicked.
        private void ToggleActivityButton_Click(object sender, RoutedEventArgs e)
        {
            // Tests whether the player's power is equal to or greater than the required power to change policy.
            // If the player has enough power to change policy:
            if (GP_power >= selectedPolicy.req_power)
            {
                selectedPolicy.changeActivity();                                // Sets whether selected policy is active or inactive based on current state.
                GP_power -= selectedPolicy.req_power;                           // Subtracts the power required from the power the player has.
                PolicyDesc.Text += "\nPolicy will be changed next turn!";       // Tells the user via the interface that they have successfully changed the policy.
                updateStatTab();

                if (selectedPolicy.active)  // If the policy is active.
                {
                    // Implementation of policy voter group popularity values.
                    VG_conservatives += selectedPolicy.conservatives;
                    VG_liberals += selectedPolicy.liberals;
                    VG_capitalists += selectedPolicy.capitalists;
                    VG_socialists += selectedPolicy.socialists;
                    VG_nationalists += selectedPolicy.nationalists;
                    VG_globalists += selectedPolicy.globalists;
                    VG_environmentalists += selectedPolicy.environmentalists;
                }
                else    // If the policy is inactive.
                {
                    // Implementation of policy voter group popularity values.
                    VG_conservatives -= selectedPolicy.conservatives;
                    VG_liberals -= selectedPolicy.liberals;
                    VG_capitalists -= selectedPolicy.capitalists;
                    VG_socialists -= selectedPolicy.socialists;
                    VG_nationalists -= selectedPolicy.nationalists;
                    VG_globalists -= selectedPolicy.globalists;
                    VG_environmentalists -= selectedPolicy.environmentalists;
                }
                
            }

            // If the player does nto have enough power to change policy:
            else
            {
                PolicyDesc.Text += "\nNot enough power!"; // Tells the user via the interface that they do not have enough power to enact/repeal policy.
            }
        }



        // Continues or ends the game when ElectionButton is clicked after an election.
        private void ElectionButton_Click(object sender, RoutedEventArgs e)
        {
            // Hides the election interface:
            ElectionInterface.Visibility = Visibility.Hidden;

            if (GP_victory) // If the player won the election.
            {
                GP_power = 0;   // Resets the player's power level.
                turnSetup();    // Sets up a new turn.

                // Shows the main game interface:
                MainInterface.Visibility = Visibility.Visible;
            }
            else    // If the player lost the election.
            {
                // Shows the starting main game menu.
                GameMenu.Visibility = Visibility.Visible;
            }
        }



        // Closes PollingInterface when PollingBackButton is clicked.
        private void PollingBackButton_Click(object sender, RoutedEventArgs e)
        {
            PollingInterface.Visibility = Visibility.Hidden;
        }



        // Opens PollingInterface when PollingButton is clicked.
        private void PollingButton_Click(object sender, RoutedEventArgs e)
        {
            // Declares the output string polling variable.
            string pollOutput = "If there were an election tomorrow, polling would be similar to this:\n";

            // Implementation of the polling values into the output string data:
            pollOutput += "\nCON:  " + String.Format("{0:0.00}", polling[0]) + "%";
            pollOutput += "\nLAB:  " + String.Format("{0:0.00}", polling[1]) + "%";
            pollOutput += "\nLD:   " + String.Format("{0:0.00}", polling[2]) + "%";
            pollOutput += "\nUKIP: " + String.Format("{0:0.00}", polling[3]) + "%";
            pollOutput += "\nGRN:  " + String.Format("{0:0.00}", polling[4]) + "%";
            pollOutput += "\nSNP:  " + String.Format("{0:0.00}", polling[5]) + "%";
            pollOutput += "\nOTH:  " + String.Format("{0:0.00}", polling[6]) + "%";

            PollingBlock.Text = pollOutput; // Assignment of the output string to the interface text block.

            PollingInterface.Visibility = Visibility.Visible;
        }



        // Closes GameSaveInterface when SaveBackButton is clicked.
        private void SaveBackButton_Click(object sender, RoutedEventArgs e)
        {
            GameSaveInterface.Visibility = Visibility.Hidden;
        }



        // Saves the current game and closes GameSaveInterface when SaveBackButton is clicked.
        private void SaveToXMLButton_Click(object sender, RoutedEventArgs e)
        {
            if (SaveTextBox.Text == "")     // If SaveTextBox has no text:
            {
                // Show a message box telling the user to enter a value:
                MessageBox.Show("Please enter a name for your game save."); 
            } 
            else
            {
                saveGame(SaveTextBox.Text); // Saves the game with the input save name via SaveTextBox.
                GameSaveInterface.Visibility = Visibility.Hidden;
            }
        }



        // Opens GameSaveInterface when SaveGameButton is clicked.
        private void SaveGameButton_Click(object sender, RoutedEventArgs e)
        {
            GameSaveInterface.Visibility = Visibility.Visible;
        }
    }
}
