namespace PagePasosBack.Domain.Licitacion
{
    public class Project : BaseDomainModel
    {
        public string Description { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public Presupuesto Presupuesto { get; set; }
    }
}
