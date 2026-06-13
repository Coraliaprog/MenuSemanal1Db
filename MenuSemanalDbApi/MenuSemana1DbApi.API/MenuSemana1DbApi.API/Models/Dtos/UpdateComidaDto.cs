namespace MenuSemana1DbApi.API.Models.Dtos
{
    public class UpdateComidaDto
    {
        public string Nombre { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public string DiaSemana { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}