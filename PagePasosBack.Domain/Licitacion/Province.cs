namespace PagePasosBack.Domain.Licitacion
{
    public class Province : BaseDomainModel
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public ICollection<District> Districts { get; set; }
    }
}
