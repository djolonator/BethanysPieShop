﻿using CategoryApi.Entities;
using CategoryApi.Models;
using CategoryApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CategoryApi.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            var categoryFromRepo = _categoryRepository.GetAllCategories();

            if (categoryFromRepo == null)
            {
                return NotFound();
            }

            return Ok(categoryFromRepo);
        }

        [HttpGet("{categoryId}")]
        public IActionResult GetCategory(int categoryId)
        {
            var categoryFromRepo = _categoryRepository.GetCategory(categoryId);

            return Ok(categoryFromRepo);
        }

        [HttpPost]
        public IActionResult CreateCategory([FromBody] Category category)
        {

            var createdCategory = _categoryRepository.AddCategory(category);

            return Ok(createdCategory);

        }

        [HttpDelete]

       // [Route("{categoryId}")]
        public ActionResult DeleteCategory(int id)
        {

            _categoryRepository.DeleteCategory(id);

            return NoContent();

        }

        [HttpPost]
        //[Route("")]
        [Route("{categoryId}")]
        public IActionResult UpdateCategory([FromBody] Category category)
        {

            var updatedCategory = _categoryRepository.UpdateCategory(category);

            return Ok(updatedCategory);
           
        }
    }
}
