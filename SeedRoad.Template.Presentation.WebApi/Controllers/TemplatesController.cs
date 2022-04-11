using MediatR;
using Microsoft.AspNetCore.Mvc;
using SeedRoad.Common.Core.Application.Pagination;
using SeedRoad.Common.Presentation.WebApi;
using SeedRoad.Common.Presentation.WebApi.Contracts;
using SeedRoad.Common.Presentation.WebApi.DTOs;
using SeedRoad.Common.Presentation.WebApi.Extensions;
using SeedRoad.Common.Presentation.WebApi.Services;
using SeedRoad.Template.Core.Application.UsesCases;
using SeedRoad.Template.Core.Application.UsesCases.Templates;
using SeedRoad.Template.Core.Application.UsesCases.Templates.Commands;
using SeedRoad.Template.Core.Application.UsesCases.Templates.Queries;

namespace SeedRoad.Template.Presentation.WebApi.Controllers;

public class TemplatesController : ApiControllerBase
{
    private readonly ISender _sender;
    private readonly IHateoasResponseBuilder _builder;

    public TemplatesController(ISender sender, IHateoasResponseBuilder builder)
    {
        _sender = sender;
        _builder = builder;
    }

    public record CreateTemplateDto(string ExampleProperty);

    [HttpPost]
    public async Task<IActionResult> CreateTemplate(CreateTemplateDto dto)
    {
        Guid templateId = await _sender.Send(new TemplateCreation(dto.ExampleProperty));
        return CreatedAtAction(nameof(GetTemplate), new { templateId }, null);
    }

    [HttpGet("{templateId:guid}", Name = nameof(GetTemplate))]
    public async Task<IActionResult> GetTemplate(Guid templateId)
    {
        TemplateView templateView = await _sender.Send(new GetTemplateByIdQuery(templateId));
        return Ok(_builder.ToEntityResponse(templateView, GetLinksForTemplate(templateId)));
    }

    public record GetTemplatesDto() : PaginationQueryDtoBase;

    [HttpGet(Name = nameof(GetTemplates))]
    public async Task<IActionResult> GetTemplates([FromQuery] GetTemplatesDto dto)
    {
        var templateViews = await _sender.Send(new GetTemplatesQuery() { Page = dto.Page, Size = dto.Size });
        var templateViewsWithLinks =
            templateViews.Select(view => _builder.ToEntityResponse(view, GetLinksForTemplate(view.Id)));
        return Ok(_builder.FromPagedList(Url, templateViews.ToPagedListResume(), templateViewsWithLinks,
            nameof(GetTemplates)));
    }

    private IEnumerable<LinkDto> GetLinksForTemplate(Guid templateId)
    {
        return new[]
        {
            LinkDto.SelfLink(Url.Link(nameof(GetTemplate), new { templateId })),
            LinkDto.AllLink(Url.Link(nameof(GetTemplates), null)),
        };
    }
}