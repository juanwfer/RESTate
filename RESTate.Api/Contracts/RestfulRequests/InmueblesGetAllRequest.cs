namespace RESTate.Api.Contracts.RestfulRequests
{
    public class InmueblesGetAllRequest
    {
        public int? CantidadDeAmbientesMinimo { get; set; }
        public int? CantidadDeAmbientesMaximo { get; set; }
        public int? MetrosCuadradosMinimo { get; set; }
        public int? MetrosCuadradosMaximo { get; set; }
        public int? MetrosCuadradosCubiertosMinimo { get; set; }
        public int? MetrosCuadradosCubiertosMaximo { get; set; }
        public string? PalabrasClave { get; set; }
    }
}
