namespace MenuSemana1DbApi.API.Models.Entities
{
    public class Ingrediente
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public decimal Cantidad { get; set; }
        public bool IsActive { get; set; } = true;

        public int ComidaId { get; set; }
        public Comida? Comida { get; set; }
    }
}