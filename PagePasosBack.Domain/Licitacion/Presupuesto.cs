namespace PagePasosBack.Domain.Licitacion
{
    public class Presupuesto : BaseDomainModel
    {
        public double dMinimo { get; set; }
        public double dMaximo { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
