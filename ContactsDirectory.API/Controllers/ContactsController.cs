using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactsDirectory.Core;
using ContactsDirectory.Entity;
using Microsoft.AspNetCore.Mvc;

namespace ContactsDirectory.API.Controllers
{
    [Route("api/contacts")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        public IDataSource DataSource { get; set; }
        public ContactsController(IDataSource dataSource)
        {
            DataSource = dataSource;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await DataSource.GetContacts());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            return Ok(await DataSource.GetContact(id));
        }

        [HttpPost]
        public async Task<ActionResult> Create(Contact contact)
        {
            return Ok(await DataSource.CreateContact(contact));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, Contact contact)
        {
            return Ok(await DataSource.UpdateContact(id, contact));
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Contact contact)
        {
            return Ok(await DataSource.DeleteContact(contact));
        }
    }
}
