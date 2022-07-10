namespace RESTate.Api.Contracts.RestfulResponses
{
    public class InmueblesGetAllResponse
    {
        public string Link { get; set; } = "";
        public int IdInmueble { get; set; }
        public string Resumen { get; set; } = "";
        public int MetrosCuadrados { get; set; }
        public int MetrosCuadradosCubiertos { get; set; }
        public int CantidadAmbientes { get; set; }
        public int CantidadDormitorios { get; set; }
        public int CantidadBaños { get; set; }
    }
}
