namespace Employees.Model.type
{
    public class ListEmployees
    {
        public IEnumerable<OfficeEmployee> OfficeEmployees { get; set; }
        public IEnumerable<Workman> Workmen { get; set; }
        public IEnumerable<Trader> Traders { get; set; }
    }
}
