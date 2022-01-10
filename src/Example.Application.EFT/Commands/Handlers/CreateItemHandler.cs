﻿using Example.Application.EFT.Consts;
using Example.Application.EFT.Exceptions;
using Example.Application.EFT.Services;
using Example.Core.EFT.Entities;
using Example.Core.EFT.Factories;
using Example.Core.EFT.Repositories;
using Example.Core.EFT.Value_Object;
using Example.Shared.EFT.Commands;

namespace Example.Application.EFT.Commands.Handlers
{
    internal class CreateItemHandler : ICommandHandler<CreateItem>
    {
        private readonly IItemRepository _itemRepository;
        private readonly IItemFactory _itemFactory;
        private readonly IItemReadService _itemService;

        public CreateItemHandler(IItemRepository itemRepository, IItemFactory itemFactory, IItemReadService itemService)
        {
            _itemRepository = itemRepository;
            _itemFactory = itemFactory;
            _itemService = itemService;
        }

        public async Task HandleAsync(CreateItem command, CancellationToken token)
        {
            var (Id, name, description, price, itemType, promoCode) = command;
            var exists = await _itemService.CheckIfItemExistsAsync(name);

            if (exists)
            {
                throw new ItemAlreadyExistsException(ErrorMessages.ItemAlreadyExists);
            }

            var itemPrice = new Price(price.itemPrice, (Currency)price.currency);
            var itemDescription = new Description(description);
            Item newItem;

            if (promoCode == "promo_code_here")
            {
                newItem = _itemFactory.CreateItemWithPricePolicy(Id, itemPrice, (ItemType)itemType, itemDescription);
            }
            else
            {
                newItem = _itemFactory.CreateItem(Id, itemPrice, (ItemType)itemType, itemDescription);
            }


            await _itemRepository.AddAsync(newItem);
        }
    }
}
