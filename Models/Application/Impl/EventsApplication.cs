namespace EventManager.Models.Application.Impl
{
    using AutoMapper;
    using System.Linq;
    using System.Collections.Generic;
    using Dtos;
    using Business.Domain;
    using Infrastructure.Data;

    public class EventsApplication
        : IEventsApplication
    {
        private readonly IModelReader<Event> readModel;
        private IRepository<Event, int> repository;

        public EventsApplication(
            IModelReader<Event> readModel,
            IRepository<Event, int> repository)
        {
            this.readModel = readModel;
            this.repository = repository;
        }

        public IEnumerable<EventDto> GetList()
        {
            return Mapper.Map<IEnumerable<EventDto>>(
                this.readModel);
        }

        public EventDto GetById(int id)
        {
            return Mapper.Map<EventDto>(
                this.readModel.Where(x => x.Id == id).SingleOrDefault());
        }

        public void Create(EventDto dto)
        {
            var entity = Mapper.Map<Event>(dto);
            this.repository.Create(entity);
            dto.Id = entity.Id;
        }
       
        public void Update(EventDto dto)
        {
            var entity = Mapper.Map<Event>(dto);
            this.repository.Update(entity);
        }

        public void Delete(EventDto dto)
        {
            var entity = Mapper.Map<Event>(dto);
            this.repository.Delete(entity);
        }
    }
}
