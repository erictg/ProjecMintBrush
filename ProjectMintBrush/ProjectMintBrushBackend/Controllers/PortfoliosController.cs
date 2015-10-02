using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ProjectMintBrushBackend.Models;

namespace ProjectMintBrushBackend
{
    public class PortfoliosController : ApiController
    {
        private ProjectMintBrushBackendContext db = new ProjectMintBrushBackendContext();

        // GET: api/Portfolios
        public IQueryable<Portfolio> GetPortfolios()
        {
            return db.Portfolios;
        }

        // GET: api/Portfolios/5
        [ResponseType(typeof(Portfolio))]
        public async Task<IHttpActionResult> GetPortfolio(int id)
        {
            Portfolio portfolio = await db.Portfolios.FindAsync(id);
            if (portfolio == null)
            {
                return NotFound();
            }

            return Ok(portfolio);
        }

        // PUT: api/Portfolios/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPortfolio(int id, Portfolio portfolio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != portfolio.ID)
            {
                return BadRequest();
            }

            db.Entry(portfolio).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PortfolioExists(id))
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

        // POST: api/Portfolios
        [ResponseType(typeof(Portfolio))]
        public async Task<IHttpActionResult> PostPortfolio(Portfolio portfolio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Portfolios.Add(portfolio);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = portfolio.ID }, portfolio);
        }

        // DELETE: api/Portfolios/5
        [ResponseType(typeof(Portfolio))]
        public async Task<IHttpActionResult> DeletePortfolio(int id)
        {
            Portfolio portfolio = await db.Portfolios.FindAsync(id);
            if (portfolio == null)
            {
                return NotFound();
            }

            db.Portfolios.Remove(portfolio);
            await db.SaveChangesAsync();

            return Ok(portfolio);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PortfolioExists(int id)
        {
            return db.Portfolios.Count(e => e.ID == id) > 0;
        }
    }
}