namespace RESTate.Api.Contracts.RestfulRequests
{
    public class ContactosGetAllRequest
    {
        public long? NumeroDocumento { get; set; }
        public string? TipoDocumento { get; set; }
        public string? Nombre { get; set; }
        public string? PalabrasClave { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
    }
}
