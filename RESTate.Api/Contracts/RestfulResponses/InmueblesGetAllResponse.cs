namespace RESTate.Api.Contracts.RestfulResponses
{
    public class InmueblesGetAllResponse
    {
        public string Link { get => ""; }
        public string Resumen { get; set; } = "";
        public int MetrosCuadrados { get; set; }
        public int MetrosCuadradosCubiertos { get; set; }
        public int CantidadAmbientes { get; set; }
        public int CantidadDormitorios { get; set; }
        public int CantidadBaños { get; set; }
    }
}
