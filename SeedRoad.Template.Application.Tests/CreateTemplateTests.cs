using System.Threading;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using SeedRoad.Template.Application.UsesCases;
using SeedRoad.Template.Domain.Templates;
using SeedRoad.Template.Domain.Templates.DTOs;

namespace SeedRoad.Template.Application.Tests;

public class CreateTemplateTests
{
    private Mock<ITemplates> _templates;

    [SetUp]
    public void Setup()
    {
        _templates = new Mock<ITemplates>();
    }

    [Test]
    public async Task create_template_should_call_aggregate_repository_set()
    {
        var createTemplate = new CreateTemplate(_templates.Object);
        var request = new TemplateCreation("test");
        await createTemplate.Handle(request, CancellationToken.None);
        _templates.Verify(templates => templates.SetAsync(It.IsAny<TemplateWriteDto>()), Times.Once);
    }
}