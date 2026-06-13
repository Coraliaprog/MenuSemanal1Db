namespace MenuSemana1DbApi.API.Models.Dtos
{
    public class CreateIngredienteDto
    {
        public string Nombre { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public decimal Cantidad { get; set; }
        public int ComidaId { get; set; }
    }
}