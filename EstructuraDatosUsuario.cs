using System;

namespace Fase3JavierGarcia
{
    public class EstructuraDatosUsuario
    {
        public string TipoIdentificacion { get; set; }
        public string NumeroIdentificacion { get; set; }
        public string NombreCompleto { get; set; }
        public int Edad { get; set; }
        public int Estrato { get; set; }
        public string TipoAtencion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public decimal ValorCopago { get; set; }
    }
}