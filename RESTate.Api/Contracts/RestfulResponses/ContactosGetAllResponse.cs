namespace RESTate.Api.Contracts.RestfulResponses
{
    public class ContactosGetAllResponse
    {
        public string Link { get; set; } = "";
        public int IdContacto { get; set; }
        public string NombreCompleto { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string TipoDocumento { get; set; } = string.Empty;
        public int NumeroDocumento { get; set; }
    }
}
