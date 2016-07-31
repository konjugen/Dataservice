using dataservicesService.DataObjects;
using dataservicesService.Models;
using Microsoft.WindowsAzure.Mobile.Service;
using Microsoft.WindowsAzure.Mobile.Service.Tables;
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
    public class CategoryController : TableController<Category>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            dataservicesContext context = new dataservicesContext();
            DomainManager = new EntityDomainManager<Category>(context, Request, Services);
        }

        // GET tables/TodoItem
        public IQueryable<Category> GetAllCategoryItems()
        {
            return Query();
        }

        // GET tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Category> GetCategoryItem(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Category> PatchCategoryItem(string id, Delta<Category> patch)
        {
            return UpdateAsync(id, patch);
        }

        // POST tables/TodoItem
        public async Task<IHttpActionResult> PostCategoryItem(Category item)
        {
            Category current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.PkCategoryId }, current);
        }

        // DELETE tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteCategoryItem(string id)
        {
            return DeleteAsync(id);
        }
    }
}