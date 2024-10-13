namespace PagePasosBack.Domain.Licitacion
{
    public class Project : BaseDomainModel
    {
        public string Description { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public ICollection<Presupuesto> Presupuestos { get; set; }
        public ICollection<EnvironmentalComponent> EnvironmentalComponents { get; set; }
        public ICollection<EnvironmentImpact> EnvironmentImpacts { get; set; }
    }
}
