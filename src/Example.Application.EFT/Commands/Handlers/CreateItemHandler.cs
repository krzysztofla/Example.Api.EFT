using Example.Application.EFT.Consts;
using Example.Application.EFT.Exceptions;
using Example.Application.EFT.Services;
using Example.Core.EFT.Entities;
using Example.Core.EFT.Factories;
using Example.Core.EFT.Repositories;
using Example.Core.EFT.Value_Object;
using Example.Shared.EFT.Abstractions.Exceptions;
using Example.Shared.EFT.Commands;

namespace Example.Application.EFT.Commands.Handlers
{
    public class CreateItemHandler : ICommandHandler<CreateItem>
    {
        private readonly IItemRepository _itemRepository;
        private readonly IItemFactory _itemFactory;
        private readonly IItemReadService _itemReadService;

        public CreateItemHandler(IItemRepository itemRepository, IItemFactory itemFactory, IItemReadService itemReadService)
        {
            _itemRepository = itemRepository;
            _itemFactory = itemFactory;
            _itemReadService = itemReadService;
        }

        public async Task HandleAsync(CreateItem command, CancellationToken token)
        {
            var (Id, name, description, price, itemType, promoCode) = command;
            var exists = await _itemReadService.CheckIfItemExistsAsync(name);

            if (exists)
            {
                throw new ItemAlreadyExistsException(ErrorMessages.ItemAlreadyExists, ErrorCodes.ExampleCode);
            }

            var itemPrice = new Price(price.itemPrice, (Currency)price.currency);
            var itemDescription = new Description(description);
            Item newItem;

            if (promoCode == "code_here")
            {
                newItem = _itemFactory.CreateItemWithPricePolicy(Id, name, itemPrice, (ItemType)itemType, itemDescription);
            }
            else
            {
                newItem = _itemFactory.CreateItem(Id, name, itemPrice, (ItemType)itemType, itemDescription);
            }


            await _itemRepository.AddAsync(newItem, token);
        }
    }
}
