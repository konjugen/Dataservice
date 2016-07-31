using dataservicesService.DataObjects;
using dataservicesService.Models;
using Microsoft.WindowsAzure.Mobile.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;

namespace dataservicesService.Controllers
{
    public class WriterController : TableController<Writer>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            dataservicesContext context = new dataservicesContext();
            DomainManager = new EntityDomainManager<Writer>(context, Request, Services);
        }

        // GET tables/TodoItem
        public IQueryable<Writer> GetAllWriterItems()
        {
            return Query();
        }

        // GET tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Writer> GetWriterItem(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Writer> PatchWriterItem(string id, Delta<Writer> patch)
        {
            return UpdateAsync(id, patch);
        }

        // POST tables/TodoItem
        public async Task<IHttpActionResult> PostWriterItem(Writer item)
        {
            Writer current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.PkWriterId }, current);
        }

        // DELETE tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteWriterItem(string id)
        {
            return DeleteAsync(id);
        }
    }
}