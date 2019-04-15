namespace Todo.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;

    /// <summary>
    ///  General
    /// </summary>
    /// <response code="500">Returns OK</response>
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    [Route("api/Todo")]
    [ApiController]
    [Produces("text/json")]

    public class TodoController : ControllerBase
    {
        private IDisplay _display;
        private ILogger _log;

        public TodoController(IDisplay display, ILogger log)
        {
            _display = display;
            _log = log;
        }

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(TodoController));

        // GET api/values
        [HttpGet]
        public ActionResult<string> Get()
        {


            string result = _display.Show("Hola Mundo");
            _log.Log($"{result} Get" );
            return result;

        }


        // GET api/values/5
        /// <summary>
        /// api/values/5
        /// </summary>
        /// <param name="id">ID (INT)</param>
        /// <returns>value</returns>
        /// <response code="500">Returns value</response>
        /// <response code="400">Returns value</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(string), 400)]
        public ActionResult<string> Get(int id)
        {
            try
            {
                if (id < 0)
                {
                    throw new Exception($"Error {id}");
                }
                log.Info($"Result {id}");
                return $"Result {id}";
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return BadRequest();
            }
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
