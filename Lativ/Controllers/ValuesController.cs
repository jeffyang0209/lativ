using Lativ.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Lativ.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/<controller>
        public async Task<List<Table>> Get()
        {
            using (var x = new DataEntities1())
            {
                var result = await x.Table.ToListAsync();
                return result;
            }
        }

        // GET api/<controller>/5
        public async Task<Table> Get(int id)
        {
            using (var x = new DataEntities1())
            {
                var result = await x.Table.FirstOrDefaultAsync(_ => _.Id == id);
                return result;
            }
        }

        // POST api/<controller>
        public async Task<int> Post([FromBody] Table model)
        {
            using (var x = new DataEntities1())
            {
                var table = new Table
                {
                    Title = model.Title,
                    Content = model.Content
                };
                x.Table.Add(table);
                await x.SaveChangesAsync();
                var result = table.Id;
                return result;
            }
        }

        // PUT api/<controller>/5
        public async Task Put([FromBody] Table model)
        {
            using (var x = new DataEntities1())
            {
                var table = await x.Table.FirstOrDefaultAsync(_ => _.Id == model.Id);
                if (table == null)
                {
                    return;
                }

                table.Content = model.Content;
                table.Title = model.Title;

                await x.SaveChangesAsync();
            }
        }

        // DELETE api/<controller>/5
        public async Task Delete([FromBody] int id)
        {
            using (var x = new DataEntities1())
            {
                var table = await x.Table.FirstOrDefaultAsync(_ => _.Id == id);
                if (table != null)
                {
                    x.Table.Remove(table);
                    await x.SaveChangesAsync();

                }
            }
        }
    }
}