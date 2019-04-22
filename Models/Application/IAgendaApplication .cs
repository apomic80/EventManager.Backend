namespace EventManager.Models.Application
{
    using Dtos;
    using System.Collections.Generic;

    public interface IAgendaApplication
    {
        IEnumerable<AgendaItemDto> GetList();
        AgendaItemDto GetById(int id);
        void Create(AgendaItemDto dto);
        void Update(AgendaItemDto dto);
        void Delete(AgendaItemDto dto);
    }
}
