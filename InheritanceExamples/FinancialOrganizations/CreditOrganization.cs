namespace FinancialOrganizations
{
    public class CreditOrganization : FinancialInstitution
    {
        public CreditOrganization(string name, string adress, long statutoryCapital)
        {
            this.name = name;
            this.adress = adress;
            this.statutoryCapital = statutoryCapital;
        }
        public long CreditPortfolio { get; set; }
    }
}
