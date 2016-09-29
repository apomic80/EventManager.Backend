namespace EventManager.Api.AspNetCore.Models.Application
{
    using Dtos;
    using System.Collections.Generic;

    public interface IEventsApplication
    {
        IEnumerable<EventDto> GetList();
        EventDto GetById(int id);
        void Create(EventDto dto);
        void Update(EventDto dto);
        void Delete(EventDto dto);
    }
}
