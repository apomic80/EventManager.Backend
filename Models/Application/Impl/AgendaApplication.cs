namespace EventManager.Models.Application.Impl
{
    using AutoMapper;
    using System.Linq;
    using System.Collections.Generic;
    using Dtos;
    using Business.Domain;
    using Infrastructure.Data;

    public class AgendaApplication
        : IAgendaApplication
    {
        private readonly IModelReader<AgendaItem> readModel;
        private IRepository<AgendaItem, int> repository;

        public AgendaApplication(
            IModelReader<AgendaItem> readModel,
            IRepository<AgendaItem, int> repository)
        {
            this.readModel = readModel;
            this.repository = repository;
        }

        public IEnumerable<AgendaItemDto> GetList()
        {
            return Mapper.Map<IEnumerable<AgendaItemDto>>(
                this.readModel);
        }

        public AgendaItemDto GetById(int id)
        {
            return Mapper.Map<AgendaItemDto>(
                this.readModel.Where(x => x.Id == id).SingleOrDefault());
        }

        public void Create(AgendaItemDto dto)
        {
            var entity = Mapper.Map<AgendaItem>(dto);
            this.repository.Create(entity);
            dto.Id = entity.Id;
        }
       
        public void Update(AgendaItemDto dto)
        {
            var entity = Mapper.Map<AgendaItem>(dto);
            this.repository.Update(entity);
        }

        public void Delete(AgendaItemDto dto)
        {
            var entity = Mapper.Map<AgendaItem>(dto);
            this.repository.Delete(entity);
        }
    }
}
