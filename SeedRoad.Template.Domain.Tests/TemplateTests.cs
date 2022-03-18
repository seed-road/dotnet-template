using System;
using System.Security.Cryptography.X509Certificates;
using FluentAssertions;
using NUnit.Framework;
using SeedRoad.Template.Domain.Templates;

namespace SeedRoad.Template.Domain.Tests;

public class TemplateTests
{
    [SetUp]
    public void Setup()
    {
    }

    private static Guid?[] _templateIds = { Guid.NewGuid(), Guid.Empty };

    [TestCaseSource(nameof(_templateIds))]
    public void should_create_aggregate_with_id(Guid id)
    {
        var template = TemplateAggregate.CreateNew(id, "");
        template.Id.Value.Should().Be(id);
    }

    [TestCase("ExampleProperty")]
    [TestCase("")]
    [TestCase(null)]
    public void should_create_aggregate_with_example_property(string exampleProperty)
    {
        var template = TemplateAggregate.CreateNew(Guid.NewGuid(), exampleProperty);
        template.ExampleProperty.Should().Be(exampleProperty);
    }

    [Test]
    public void should_add_created_event_on_aggregate_create()
    {
        var template = TemplateAggregate.CreateNew(Guid.NewGuid(), "");
        template.Events.Should().ContainItemsAssignableTo<TemplateCreatedEvent>();
    }
}