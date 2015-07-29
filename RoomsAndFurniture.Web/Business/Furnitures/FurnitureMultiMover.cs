﻿using System;
using System.Collections.Generic;
using System.Linq;
using RoomsAndFurniture.Web.Business.RoomEvents;
using RoomsAndFurniture.Web.Business.Rooms;
using RoomsAndFurniture.Web.Domain;

namespace RoomsAndFurniture.Web.Business.Furnitures
{
    internal class FurnitureMultiMover : IFurnitureMultiMover
    {
        private readonly IRoomReader roomReader;
        private readonly IFurnitureReader reader;
        private readonly IFurnitureCreator creator;
        private readonly IFurnitureUpdater updater;
        private readonly IRoomEventLogger roomEventLogger;

        public FurnitureMultiMover(
            IRoomReader roomReader,
            IFurnitureReader reader,
            IFurnitureCreator creator,
            IFurnitureUpdater updater,
            IRoomEventLogger roomEventLogger)
        {            
            this.roomReader = roomReader;
            this.reader = reader;
            this.creator = creator;
            this.updater = updater;
            this.roomEventLogger = roomEventLogger;
        }

        public void MoveAll(Room roomFrom, Room roomTo, DateTime date, bool isRemoveFromFirstRoom = false)
        {
            var furnitureItemsFrom = reader.GetFurnitureItems(roomFrom, date);
            if (!furnitureItemsFrom.Any())
            {
                return;
            }
            var furnitureItemsTo = reader.GetFurnitureItems(furnitureItemsFrom.Select(f => f.Type).ToList(), roomTo, date);
            SetFurnitureToSecondRoom(furnitureItemsFrom, furnitureItemsTo, roomTo, date);
            if (isRemoveFromFirstRoom)
            {
                RemoveFurnitureItemsFromFirstRoom(furnitureItemsFrom, date);
            }
        }

        private void SetFurnitureToSecondRoom(
            IEnumerable<Furniture> furnitureItemsFrom, IList<Furniture> furnitureItemsTo, Room roomTo, DateTime date)
        {
            var fournitureItemsForCreate = new List<Furniture>();
            var fournitureItemsForUpdate = new List<Furniture>();
            foreach (var fournitureItemFrom in furnitureItemsFrom)
            {
                var fournitureItemTo = furnitureItemsTo.FirstOrDefault(f => f.Type == fournitureItemFrom.Type);
                if (fournitureItemTo == null)
                {
                    var furnitureItemToCreate = new Furniture(fournitureItemFrom) { Date = date, RoomId = roomTo.Id };
                    fournitureItemsForCreate.Add(furnitureItemToCreate);
                    continue;
                }
                var count = fournitureItemFrom.Count + fournitureItemTo.Count;
                if (fournitureItemTo.Date < date.Date)
                {
                    var furnitureItemToCreate = new Furniture(fournitureItemTo) { Date = date, Count = count };
                    fournitureItemsForCreate.Add(furnitureItemToCreate);
                    continue;
                }
                fournitureItemTo.Count = count;
                fournitureItemsForUpdate.Add(fournitureItemTo);
            }
            creator.Create(fournitureItemsForCreate);
            updater.Update(fournitureItemsForUpdate);
        }
        
        private void RemoveFurnitureItemsFromFirstRoom(IEnumerable<Furniture> furnitureItems, DateTime date)
        {
            var fournitureItemsForCreate = new List<Furniture>();
            var fournitureItemsForUpdate = new List<Furniture>();
            foreach (var furnitureItem in furnitureItems)
            {
                if (furnitureItem.Date.Date < date.Date)
                {
                    var furnitureItemToCreate = new Furniture(furnitureItem) { Date = date, Count = 0 };
                    fournitureItemsForCreate.Add(furnitureItemToCreate);
                }
                furnitureItem.Count = 0;
                fournitureItemsForUpdate.Add(furnitureItem);
            }
            creator.Create(fournitureItemsForCreate);
            updater.Update(fournitureItemsForUpdate);
        }
    }
}