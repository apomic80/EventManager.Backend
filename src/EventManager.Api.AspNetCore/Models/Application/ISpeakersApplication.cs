namespace EventManager.Api.AspNetCore.Models.Application
{
    using Dtos;
    using System.Collections.Generic;

    public interface ISpeakersApplication
    {
        IEnumerable<SpeakerDto> GetList();
        SpeakerDto GetById(int id);
        void Create(SpeakerDto dto);
        void Update(SpeakerDto dto);
        void Delete(SpeakerDto dto);
    }
}
