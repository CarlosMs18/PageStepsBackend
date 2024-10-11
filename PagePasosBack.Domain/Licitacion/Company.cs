namespace PagePasosBack.Domain.Licitacion
{
    public class Company : BaseDomainModel
    {
        public string? Name { get; set; }
        public string RUC { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public DateTime DateCreation { get; set; }
        public bool State { get; set; }
    }
}
