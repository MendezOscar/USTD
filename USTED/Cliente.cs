using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USTED
{
    public class Cliente
    {
        public Cliente(string pdireccion, string ppais, string pdepartamento, string pmunicipio, string ptelefono1,
            string ptelefono2, string pfax, string pemail1, string pemail2, string pcompañia, string pdircompañia, string ptelcompañia,
            string pemailcompañia, string ppuesto, string pdeptocompañia, string pnivelacademico, string pfechaingreso,
            string pcomentararios, string pcolonia)
        {
            this.Direccion = pdireccion;
            this.Pais = ppais;
            this.Departamento = pdepartamento;
            this.Municipio = pmunicipio;
            this.Telefono1 = ptelefono1;
            this.Telefono2 = ptelefono2;
            this.Fax = pfax;
            this.Email1 = pemail1;
            this.Email2 = pemail2;
            this.Compañia = pcompañia;
            this.Direccioncompañia = pdircompañia;
            this.Telefonocompañia = ptelcompañia;
            this.Emailcompañia = pemailcompañia;
            this.Puesto = ppuesto;
            this.Departamentocompañia = pdeptocompañia;
            this.Nivelacademico = pnivelacademico;
            this.Fechaingreso = pfechaingreso;
            this.Comentarios = pcomentararios;
            this.Colonia = pcolonia;
        }

        public string Departamento { get; set; }
        public string Pais { get; set; }
        public string Municipio { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public string Fax { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string Compañia { get; set; }
        public string Direccioncompañia { get; set; }
        public string Telefonocompañia { get; set; }
        public string Emailcompañia { get; set; }
        public string Puesto { get; set; }
        public string Departamentocompañia { get; set; }
        public string Nivelacademico { get; set; }
        public string Fechaingreso { get; set; }
        public string Comentarios { get; set; }
        public string Direccion { get; set; }
        public string Colonia { get; set; }
    }
}
