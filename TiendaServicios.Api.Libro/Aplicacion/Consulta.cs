using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios.Api.Libro.Persistencia;
using TiendaServicios.Api.Libro.Modelo;
using Microsoft.EntityFrameworkCore;

namespace TiendaServicios.Api.Libro.Aplicacion
{
    public class Consulta
    {
        public class Ejecuta : IRequest<List<LibroMaterialDto>> { }

        public class Manejador : IRequestHandler<Ejecuta, List<LibroMaterialDto>>
        {
            private readonly ContextoLibreria _contexto;
            private readonly IMapper _maper;

            public Manejador(ContextoLibreria contexto, IMapper mapper)
            {
                _contexto = contexto;
                _maper = mapper;
            }
            public async Task<List<LibroMaterialDto>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var libros = await _contexto.libreriaMaterial.ToListAsync();
               var librosDto =  _maper.Map<List<LibreriaMaterial>, List<LibroMaterialDto>>(libros);

                return librosDto;
            }
        }
    }
}
