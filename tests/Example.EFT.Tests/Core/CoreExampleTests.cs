using Example.Core.EFT.Events;
using Example.Core.EFT.Exceptions;
using Example.Core.EFT.Factories;
using Example.Core.EFT.Policies;
using Example.Core.EFT.Value_Object;
using Shouldly;
using System;
using System.Linq;
using Xunit;

namespace Example.EFT.Tests.Core
{
    public class CoreExampleTests
    {

        private readonly IItemFactory _itemFactor;

        public CoreExampleTests()
        {
            _itemFactor = new ItemFactory(Enumerable.Empty<IItemPolicy>());
        }

        [Fact]
        public void AddItem_Faliure_With_EmptyDescriptionException_When_Description_Is_Empty()
        {
            var exception = Record.Exception(() => _itemFactor.CreateItem(Guid.NewGuid(), new ItemName("test"), new Price(122, Currency.PLN), ItemType.Materials, new Description("")));
            
            exception.ShouldNotBeNull();

            exception.ShouldBeOfType<EmptyDescriptionException>();
        }


        [Fact]
        public void Check_If_UpdateDescription_Creates_Valid_Domain_Event()
        {
            var item = _itemFactor.CreateItem(Guid.NewGuid(), new ItemName("test"), new Price(122, Currency.PLN), ItemType.Materials, new Description("123123"));
            item.UpdateDescription(new Description("updated_123123"));

            item.Events.Count().ShouldBe(1);

            var @event = item.Events.FirstOrDefault() as ItemDescriptionUpdated;

            @event.ShouldNotBeNull();

            @event.description.ToString().ShouldBeSameAs("updated_123123");
        }
    }
}