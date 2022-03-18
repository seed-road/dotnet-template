using SeedRoad.Common.Core.Domain.Definitions;
using SeedRoad.Template.Domain.Templates.DTOs;

namespace SeedRoad.Template.Domain.Templates;

public interface ITemplates: IAggregateRepository<Guid, TemplateWriteDto, TemplateReadDto>
{
    
}