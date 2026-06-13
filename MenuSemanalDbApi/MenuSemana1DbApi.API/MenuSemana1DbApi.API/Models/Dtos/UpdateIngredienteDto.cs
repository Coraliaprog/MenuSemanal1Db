namespace MenuSemana1DbApi.API.Models.Dtos
{
    public class UpdateIngredienteDto
    {
        public string Nombre { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public decimal Cantidad { get; set; }
        public int ComidaId { get; set; }
        public bool IsActive { get; set; }
    }
}