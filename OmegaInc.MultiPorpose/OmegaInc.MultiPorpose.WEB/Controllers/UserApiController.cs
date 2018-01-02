using OmegaInc.Common.Repository;
using OmegaInc.MultiPorpose.CoreData.Context;
using OmegaInc.MultiPorpose.Data.Example;
using OmegaInc.MultiPorpose.Repository.Entity.Example;
using OmegaInc.MultiPorpose.WEB.AutoMapper;
using OmegaInc.MultiPorpose.WEB.DTO.Example;
using OmegaInc.MultiPorpose.WEB.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OmegaInc.MultiPorpose.WEB.Controllers
{
    public class UserApiController : ApiController
    {
        private IGenericRepository<User, int> repo = new UserRepository(new DataContext());

        #region Public Methods

        public IHttpActionResult Get()
        {
            List<User> obj = repo.Select().ToList();
            List<UserDTO> dtos = AutoMapperManager.Instance.Mapper.Map<List<User>, List<UserDTO>>(obj);
            return Ok(dtos);
        }

        public IHttpActionResult Get(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }

            User obj = repo.SelectById(id.Value);

            if (obj == null)
            {
                return NotFound();
            }
            UserDTO dto = AutoMapperManager.Instance.Mapper.Map<User, UserDTO>(obj);
            return Content(HttpStatusCode.Found, dto);
        }

        [ApplyModelValidation]
        public IHttpActionResult Post([FromBody]UserDTO dto)
        {
            try
            {
                User obj = AutoMapperManager.Instance.Mapper.Map<UserDTO, User>(dto);
                repo.Insert(obj);
                return Created($"{Request.RequestUri}/{obj.Id}", obj);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [ApplyModelValidation]
        public IHttpActionResult Put(int? id, [FromBody]UserDTO dto)
        {
            try
            {
                if (!id.HasValue)
                {
                    return BadRequest();
                }

                User obj = AutoMapperManager.Instance.Mapper.Map<UserDTO, User>(dto);

                obj.Id = id.Value;

                repo.Edit(obj);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        public IHttpActionResult Delete(int? id)
        {
            try
            {
                if (!id.HasValue)
                {
                    return BadRequest();
                }

                User obj = repo.SelectById(id.Value);

                if (obj == null)
                {
                    return NotFound();
                }

                repo.DeleteById(id.Value);
                return Ok();

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        #endregion
    }
}
