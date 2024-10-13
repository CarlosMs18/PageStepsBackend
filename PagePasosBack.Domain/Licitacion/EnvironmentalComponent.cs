namespace PagePasosBack.Domain.Licitacion
{
    public class EnvironmentalComponent : BaseDomainModel
    {
        public string EnviromentComponentType { get; set; }
        public string Code { get; set; }
        public int DistrictId { get; set; }
        public District District { get; set; }
    }
}
