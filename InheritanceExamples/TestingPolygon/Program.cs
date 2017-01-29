using System;
using System.Collections.Generic;
using System.Linq;
using ThreeDimensionalForms;
using FinancialOrganizations;

namespace TestingPolygon
{
    class Program
    {
        static void Main(string[] args)
        {
            #region  all banks of Armenia
            var b1 = new Bank("Ameria", "Grigor Lusavoritch str. 9", 32087360000, 286143000000, 399744000000)
            {
                branchCount = 37,
                totalClients = 22000,
                totalEmployeeCount = 1356
            };
            var b2 = new Bank("ACBA", "Bayron str. 1", 30000000001, 272853238000, 219141110000)
            {
                branchCount = 44,
                totalClients = 188000,
                totalEmployeeCount = 2014
            };
            var b3 = new Bank("Biblos", "18/3 Amiryan St", 6576460000, 39738302000, 34329963000);
            b3.branchCount = 2;
            b3.totalClients = 1020;
            b3.totalEmployeeCount = 198;
            #endregion
            var cba = new List<Bank> { b1, b2, b3 };

            #region all credit organizations of Armenia
            var co1 = new CreditOrganization("Finca", "Agatangeghos str. 2a", 4905960000)
            {
                CreditPortfolio = 253941709000,
                branchCount = 22,
                totalClients = 14000,
                totalEmployeeCount = 187
            };
            var co2 = new CreditOrganization("Kamurj", "123 Sebastia", 2044760000)
            {
                CreditPortfolio = 10645552000,
                branchCount = 8,
                totalClients = 970,
                totalEmployeeCount = 35
            };
            var co3 = new CreditOrganization("Credo Finance Armenia", "", 1114092000);
            co3.CreditPortfolio = 50925000;
            co3.branchCount = 4;
            co3.totalClients = 2300;
            co3.totalEmployeeCount = 304;
            #endregion
            var uvk = new List<CreditOrganization> { co1, co2, co3 };

            #region insurance companies of Armenia
            var ic1 = new InsuranceCompany("RosGosStrakhArmenia", "Hanrapetutyan str. 22", 2983000000, 6006054000, "Vahagn Aghavelyan");
            ic1.branchCount = 23;
            ic1.totalClients = 288000;
            ic1.totalEmployeeCount = 3000;
            var ic2 = new InsuranceCompany("Ingo Armenia", "Hanrapetutyan str. 51, 53 area", 3103941000, 9611895000, "Levon Altunyan");
            ic2.branchCount = 14;
            ic2.totalClients = 99233;
            ic2.totalEmployeeCount = 856;
            var ic3 = new InsuranceCompany("Nairi Insurance", "Vazgen Sargsyan str. 10", 1290000000, 4049877000, "Hovhannes Gevorgyan");
            ic3.branchCount = 29;
            ic3.totalClients = 55340;
            ic3.totalEmployeeCount = 1983;
            #endregion
            var appa = new List<InsuranceCompany> { ic1, ic2, ic3 };

            #region Queries
            var whichBankDoesnotMatchNewLaw = from bank in cba
                                              where bank.statutoryCapital < (long)Bank.StatutoryCapitalMinimum.StatutoryCapitalMinimumForArmeniaFrom010117
                                              select bank;
            foreach (var bank in whichBankDoesnotMatchNewLaw)
                Console.WriteLine($"{bank.name} doesn't match new armenian law about banks and has to increase its statutory capital");

            var howMuchPeopleAreEmployedInInsuranceCompanies = appa.Select(x => x.totalEmployeeCount).Sum();
            Console.WriteLine($"\nInsurance sector provides {howMuchPeopleAreEmployedInInsuranceCompanies} working places in Armenia");

            var whichCOcouldBeBankByAncientLaw =
                uvk.Where(u => u.statutoryCapital >= (long)Bank.StatutoryCapitalMinimum.StatutroyCapitalMinimumOldVersion);
            if (whichCOcouldBeBankByAncientLaw.ToList().Count == 0)
                Console.WriteLine("\nThere is no such credit organization");
            else
            {
                foreach (var creditOrganization in whichCOcouldBeBankByAncientLaw)
                    Console.WriteLine($"\n{creditOrganization.name} could be bank if not this new shitty law");
            }
            #endregion

            var piped = new Parallelepiped(5.5,10,3.2,45,45);
            Console.WriteLine($"Parapippo volume: {piped.Volume}");
            Console.WriteLine($"Paraesiminch surface: {piped.Surface}");

            Console.WriteLine(new string('*',50));

            var ellispe = new Ellipsoid(1.5,10,3.6);
            Console.WriteLine($"Ellipsoid volume: {ellispe.Volume}");
            Console.WriteLine($"Ellipsoid surface: {ellispe.Surface}");

            //Delay
            Console.ReadKey();
        }
    }
}
