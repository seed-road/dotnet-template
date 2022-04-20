using SeedRoad.Common.System;
using SeedRoad.Template.Domain.Templates;
using SeedRoad.Template.Domain.Templates.DTOs;

namespace SeedRoad.Template.Infrastructure.Database.Repositories;

public class TemplatesRepository : ITemplates
{
    public Task<Guid> SetAsync(TemplateWriteDto aggregate)
    {
        return new Guid().ToTask();
    }

    public Task<TemplateReadDto?> FindByIdAsync(Guid id)
    {
        return new TemplateReadDto(id, "test").ToTask() as Task<TemplateReadDto?>;
    }

    public Task RemoveAsync(TemplateWriteDto aggregate)
    {
        return Task.CompletedTask;
    }

    public Task<Guid> NextIdAsync()
    {
        return new Guid().ToTask();
    }
}