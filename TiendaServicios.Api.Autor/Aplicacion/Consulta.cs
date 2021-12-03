using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios.Api.Autor.Modelo;
using TiendaServicios.Api.Autor.Persistencia;

namespace TiendaServicios.Api.Autor.Aplicacion
{
    public class Consulta
    {
        public class ListaAutor : IRequest<List<AutorDto>>
        {

        }

        public class Manejador : IRequestHandler<ListaAutor, List<AutorDto>>
        {
            private readonly ContextoAutor _contextoAutor;
            private readonly IMapper _mapper;

            public  Manejador(ContextoAutor contexto, IMapper mapper)
            {
                _contextoAutor = contexto;
                _mapper = mapper;
            }
            public async Task<List<AutorDto>> Handle(ListaAutor request, CancellationToken cancellationToken)
            {
                var autres = _contextoAutor.AutorLibro.ToList();
                var autoresDto = _mapper.Map<List<AutorLibro>, List<AutorDto>>(autres);

                return autoresDto;
            }
        }
    }
}
