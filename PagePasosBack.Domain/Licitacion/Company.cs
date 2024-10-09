﻿namespace PagePasosBack.Domain.Licitacion
{
    public class Company : BaseDomainModel
    {
        public string? Name { get; set; }
        public string RUC { get; set; }
        public int ProvinceId { get; set; }
        public Province Province { get; set; }
        public DateTime DateCreation { get; set; }
        public bool State { get; set; }
    }
}
