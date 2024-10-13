namespace PagePasosBack.Domain.Licitacion
{
    public class EnvironmentImpact : BaseDomainModel
    {
        public string EnvironmentImpactType { get; set; }
        public string Code { get; set; }
        public int DistrictId { get; set; }
        public District District { get; set; }
    }
}
