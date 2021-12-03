using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios.Api.Libro.Modelo;
using TiendaServicios.Api.Libro.Persistencia;

namespace TiendaServicios.Api.Libro.Aplicacion
{
    public class ConsultaFiltro
    {
        public class LibroUnico : MediatR.IRequest<LibroMaterialDto>
        {
            public Guid? LibroId { get; set; }
        }

        public class Manejador : IRequestHandler<LibroUnico, LibroMaterialDto>
        {
            private readonly ContextoLibreria _contexto;
            private readonly IMapper _maper;

            public Manejador(ContextoLibreria contexto, IMapper mapper)
            {
                _contexto = contexto;
                _maper = mapper;
            }

            public async Task<LibroMaterialDto> Handle(LibroUnico request, CancellationToken cancellationToken)
            {
                var libro =  await _contexto.libreriaMaterial.Where(x => x.LibreriaMaterialId == request.LibroId).FirstOrDefaultAsync();
                if(libro == null)
                {
                    throw new Exception("No se encontro el libro");
                }

                var libroDto = _maper.Map<LibreriaMaterial, LibroMaterialDto>(libro);
                return libroDto;
            }
        }
    }
}
