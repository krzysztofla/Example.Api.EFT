using Example.Application.EFT.Commands;
using Example.Application.EFT.Commands.Handlers;
using Example.Application.EFT.Exceptions;
using Example.Application.EFT.Services;
using Example.Core.EFT.Factories;
using Example.Core.EFT.Repositories;
using Example.Shared.EFT.Commands;
using NSubstitute;
using Shouldly;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Example.EFT.Tests.Application
{
    public class ApplicationHandlerExampleTests
    {
        private readonly ICommandHandler<CreateItem> _commandHandler;
        private readonly IItemRepository _itemRepository;
        private readonly IItemReadService _itemReadService;
        private readonly IItemFactory _itemFactory;

        public ApplicationHandlerExampleTests()
        {

            _itemRepository = Substitute.For<IItemRepository>();
            _itemReadService = Substitute.For<IItemReadService>();
            _itemFactory = Substitute.For<IItemFactory>();
            _commandHandler = new CreateItemHandler(_itemRepository, _itemFactory, _itemReadService);
        }

        Task Act(CreateItem command)
             => _commandHandler.HandleAsync(command, new CancellationToken());

        [Fact]
        public async Task HandleAsync_Throws_ItemAlreadyExistsException_When_The_Same_Item_Exists()
        {
            var command = new CreateItem(Guid.NewGuid(), "testname", "description", new PriceDataModel(122,0), 0, "XD XD XD LOL");
            _itemReadService.CheckIfItemExistsAsync(command.name).Returns(true);

            var exception = await Record.ExceptionAsync(() => Act(command));

            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<ItemAlreadyExistsException>();
        }




    }

}

