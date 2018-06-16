using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using PAIWebService.Models;

namespace PAIWebService.Controllers
{
    public class Products_in_orderController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Products_in_order
        public IQueryable<Products_in_order> GetProducts_in_order()
        {
            return db.Products_in_order;
        }

        // GET: api/Products_in_order/5
        [ResponseType(typeof(Products_in_order))]
        public IHttpActionResult GetProducts_in_order(int id)
        {
            Products_in_order products_in_order = db.Products_in_order.Find(id);
            if (products_in_order == null)
            {
                return NotFound();
            }

            return Ok(products_in_order);
        }

        // PUT: api/Products_in_order/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProducts_in_order(int id, Products_in_order products_in_order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != products_in_order.ID)
            {
                return BadRequest();
            }

            db.Entry(products_in_order).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Products_in_orderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Products_in_order
        [ResponseType(typeof(Products_in_order))]
        public IHttpActionResult PostProducts_in_order(Products_in_order products_in_order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Products_in_order.Add(products_in_order);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = products_in_order.ID }, products_in_order);
        }

        // DELETE: api/Products_in_order/5
        [ResponseType(typeof(Products_in_order))]
        public IHttpActionResult DeleteProducts_in_order(int id)
        {
            Products_in_order products_in_order = db.Products_in_order.Find(id);
            if (products_in_order == null)
            {
                return NotFound();
            }

            db.Products_in_order.Remove(products_in_order);
            db.SaveChanges();

            return Ok(products_in_order);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Products_in_orderExists(int id)
        {
            return db.Products_in_order.Count(e => e.ID == id) > 0;
        }
    }
}