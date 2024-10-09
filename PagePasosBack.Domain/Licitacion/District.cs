namespace PagePasosBack.Domain.Licitacion
{
    public class District : BaseDomainModel
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public Province Province { get; set; }
    }
}