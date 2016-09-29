namespace EventManager.Api.AspNetCore.Models.Application.Impl
{
    using AutoMapper;
    using System.Linq;
    using System.Collections.Generic;
    using Dtos;
    using Business.Domain;
    using Infrastructure.Data;

    public class SpeakersApplication
        : ISpeakersApplication
    {
        private readonly IModelReader<Speaker> readModel;
        private IRepository<Speaker, int> repository;

        public SpeakersApplication(
            IModelReader<Speaker> readModel,
            IRepository<Speaker, int> repository)
        {
            this.readModel = readModel;
            this.repository = repository;
        }

        public IEnumerable<SpeakerDto> GetList()
        {
            return Mapper.Map<IEnumerable<SpeakerDto>>(
                this.readModel);
        }

        public SpeakerDto GetById(int id)
        {
            return Mapper.Map<SpeakerDto>(
                this.readModel.Where(x => x.Id == id).SingleOrDefault());
        }

        public void Create(SpeakerDto dto)
        {
            var entity = Mapper.Map<Speaker>(dto);
            this.repository.Create(entity);
            dto.Id = entity.Id;
        }
       
        public void Update(SpeakerDto dto)
        {
            var entity = Mapper.Map<Speaker>(dto);
            this.repository.Update(entity);
        }

        public void Delete(SpeakerDto dto)
        {
            var entity = Mapper.Map<Speaker>(dto);
            this.repository.Delete(entity);
        }
    }
}
