﻿namespace PagePasosBack.Domain.Licitacion
{
    public class Province : BaseDomainModel
    {
        public string Name { get; set; }
        public string? Code { get; set; }
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }
        public DateTime DateCreation { get; set; }
        public bool State { get; set; }
        public ICollection<District> Districts { get; set; }
    }
}
