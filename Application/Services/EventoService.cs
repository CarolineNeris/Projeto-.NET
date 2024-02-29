using Application.InputModels;
using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;
using Domain.Entities;
using Infrastructure;

namespace Application.Services;

public class EventoService : BaseService<EventoViewModel, Evento, EventoInputModel>, IEventoService
{
    public EventoService(ResTICDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}
