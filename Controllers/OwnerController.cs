using System.Collections.Generic;
using System;
using api.DB.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using api.Models.DAO;
using api.Models;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public OwnerController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllOwners()
        {
            try
            {
                var owners = _repository.Owner.GetAllOwners();
                var ownerResult = _mapper.Map<IEnumerable<OwnerDAO>>(owners);
                return Ok(ownerResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}", Name = "OwnerById")]
        public IActionResult GetOwnerById(long id)
        {
            try
            {
                var owner = _repository.Owner.GetOwnerById(id);

                if (owner == null)
                {
                    return NotFound();
                }
                else
                {
                    var ownerResult = _mapper.Map<OwnerDAO>(owner);
                    return Ok(ownerResult);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}/account")]
        public IActionResult GetOwnerWithDetails(long id)
        {
            try
            {
                var owner = _repository.Owner.GetOwnerWithDetails(id);

                if (owner == null)
                {
                    return NotFound();
                }
                else
                {
                    var ownerResult = _mapper.Map<OwnerDAO>(owner);
                    return Ok(ownerResult);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateOwner([FromBody]OwnerForCreationDAO owner)
        {
            try
            {
                if (owner == null)
                {
                    return BadRequest("Owner object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                var ownerEntity = _mapper.Map<Owner>(owner);

                _repository.Owner.Create(ownerEntity);
                _repository.Save();

                var createdOwner = _mapper.Map<OwnerDAO>(ownerEntity);

                return CreatedAtRoute("OwnerById", new { id = createdOwner.Id }, createdOwner);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOwner(long id, [FromBody]OwnerForUpdateDAO owner)
        {
            try
            {
                if (owner == null)
                {
                    return BadRequest("Owner object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                var ownerEntity = _repository.Owner.GetOwnerById(id);

                if (ownerEntity == null)
                {
                    return NotFound();
                }

                _mapper.Map(owner, ownerEntity);

                _repository.Owner.UpdateOwner(ownerEntity);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOwner(long id)
        {
            try
            {
                var owner = _repository.Owner.GetOwnerById(id);
                if (owner == null)
                {
                    return NotFound();
                }

                _repository.Owner.DeleteOwner(owner);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}