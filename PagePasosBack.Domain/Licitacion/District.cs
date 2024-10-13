namespace PagePasosBack.Domain.Licitacion
{
    public class District : BaseDomainModel
    {
        public string Name { get; set; }
        public string? Code { get; set; }
        public int? ProvinceId { get; set; }
        public Province Province { get; set; }
        public DateTime DateCreation { get; set; }
        public bool State { get; set; }
        public ICollection<EnvironmentalComponent> EnvironmentalComponents { get; set; }
        public ICollection<EnvironmentImpact> EnvironmentImpacts { get; set; }
    }
}