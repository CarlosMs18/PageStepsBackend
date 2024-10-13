namespace PagePasosBack.Domain.Licitacion
{
    public class Company : BaseDomainModel
    {
        public string? Name { get; set; }
        public string RUC { get; set; }
        public int DistrictId { get; set; }
        public District District { get; set; }
        public DateTime DateCreation { get; set; }
        public bool State { get; set; }
        public ICollection<Project> Projects { get; set; }
    }
}
