using Microsoft.AspNetCore.Mvc;
using Notes.Application.ApiVersions.Queries.GetApiVersionList;
using Notes.Application.Notes.Queries.GetNoteDetails;
using System;
using System.Threading.Tasks;

namespace Notes.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ApiVersionController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<NoteDetailsVm>> GetInfo(Guid id)
        {
            var query = new GetApiVersionListQuery();
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }
    }
}
