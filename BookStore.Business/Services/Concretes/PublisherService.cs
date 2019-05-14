﻿using BookStore.Business.Generic;
using BookStore.Dto;
using BookStore.Entity.Context;
using BookStore.Entity.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace BookStore.Business.Services
{
    public class PublisherService : EFRepository<Publisher>, IPublisherService
    {
        #region Field

        private BookDbContext _context;

        #endregion

        #region Ctor

        public PublisherService(BookDbContext context) : base(context)
        {
            _context = context;
        }

        public bool DeletePublisher(Guid id)
        {
            try
            {
                Publisher publisher = this.GetById(id);
                this.Delete(publisher);
                this.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion

        #region Method

        /// <summary>
        /// Get Specific Publisher
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DtoPublisher GetPublisher(Guid id)
        {
            var publisherItem = this.GetById(id);

            if (publisherItem == null)
            {
                return new DtoPublisher();
            }

            DtoPublisher author = new DtoPublisher();
            author.PUBLISHER_ID = publisherItem.PUBLISHER_ID;
            author.NAME = publisherItem.NAME;
            author.LOCATION = publisherItem.LOCATION;

            return author;
        }

        /// <summary>
        /// Get All Publishers
        /// </summary>
        /// <returns></returns>
        public List<DtoPublisher> GetPublishers()
        {
            var publishers = this.GetAll();

            var totalPublishers = publishers.Select(c => new DtoPublisher
            {
                PUBLISHER_ID = c.PUBLISHER_ID,
                NAME = c.NAME,
                LOCATION = c.LOCATION
            }).ToList();

            return totalPublishers;
        }

        /// <summary>
        /// Publisher Add
        /// </summary>
        /// <param name="model"></param>
        public object PublisherAdd(DtoPublisher model)
        {
            var isPublisherExists = _context.Publisher.Where(c => c.NAME == model.NAME).Any();

            if (isPublisherExists)
            {
                return false;
            }

            Publisher publisher = new Publisher();
            publisher.PUBLISHER_ID = model.PUBLISHER_ID;
            publisher.NAME = model.NAME;
            publisher.LOCATION = model.LOCATION;
            publisher.SUPPLIER_ID_FK = model.SUPPLIER_ID_FK;

            this.Add(publisher);
            this.Save();

            model.PUBLISHER_ID = publisher.PUBLISHER_ID;

            return model;
        }

        public object UpdatePublisher(DtoPublisher model)
        {
            var isPublisherExists = _context.Publisher.Where(c => c.NAME == model.NAME).Any();

            if (isPublisherExists)
            {
                return false;
            }

            Publisher publisher = this.GetById(model.PUBLISHER_ID);
            publisher.PUBLISHER_ID = model.PUBLISHER_ID;
            publisher.NAME = model.NAME;
            publisher.LOCATION = model.LOCATION;
            publisher.SUPPLIER_ID_FK = model.SUPPLIER_ID_FK;

            this.Update(publisher);
            this.Save();

            return model;
        }

        #endregion
    }
}