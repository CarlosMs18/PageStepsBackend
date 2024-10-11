namespace PagePasosBack.Domain.Licitacion
{
    public class Department: BaseDomainModel
    {
        public string Name { get; set; }
        public string? Code { get; set; }
        public DateTime DateCreation { get; set; }
        public bool State { get; set; }
        public ICollection<Province> Provinces { get; set; }
        public ICollection<Company> Companies { get; set; }      
    }
}
