using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TiendaServicios.Api.Libro.Modelo;

namespace TiendaServicios.Api.Libro.Aplicacion
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LibreriaMaterial, LibroMaterialDto>();
        }
    }
}
