namespace RESTate.Objetos
{
    public class Inmueble
    {
        public string Resumen { get; set; }
        public int CantidadDeAmbientes { get; set; }
        public int CantidadDeDormitorios { get; set; }
        public int CantidadDeBaños { get; set; }
        public int MetrosCuadrados { get; set; }
        public int MetrosCuadradosCubiertos { get; set; }
        public Contacto? Propietario { get; set; }
        public Contacto? Inquilino { get; set; }

        public Inmueble(string resumen, int cantidadDeAmbientes, int cantidadDeDormitorios, int cantidadDeBaños, int metrosCuadrados, int metrosCuadradosCubiertos, Contacto? propietario = null, Contacto? inquilino = null)
        {
            Resumen = resumen;
            CantidadDeAmbientes = cantidadDeAmbientes;
            CantidadDeDormitorios = cantidadDeDormitorios;
            CantidadDeBaños = cantidadDeBaños;
            MetrosCuadrados = metrosCuadrados;
            MetrosCuadradosCubiertos = metrosCuadradosCubiertos;
            Propietario = propietario;
            Inquilino = inquilino;
        }
    }
}