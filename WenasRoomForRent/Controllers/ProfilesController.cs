﻿using Microsoft.AspNetCore.Mvc;
using WenasRoomForRent.Api.Filters;
using WenasRoomForRent.Domain;
using WenasRoomForRent.Services;

namespace WenasRoomForRent.Api.Controllers;

[RequestLogger]
[Route("api/[controller]")]
[ApiController]
public class ProfilesController : ControllerBase
{
    private readonly IProfileService profileService;

    public ProfilesController(IProfileService profileService)
    {
        this.profileService = profileService ?? throw new ArgumentNullException(nameof(profileService));
    }

    [HttpGet]
    public IActionResult GetAll() => Ok(profileService.GetAll());

    [HttpGet("find/{name}")]
    public IActionResult Find(string name) => Ok(profileService.Find(name));

    [HttpGet("findByRoomId/{id}")]
    public IActionResult FindByRoomId(int id) => Ok(profileService.FindByRoomId(id));

    [HttpGet("{id}")]
    public IActionResult GetById(int id) => Ok(profileService.GetById(id));

    [HttpPost]
    public IActionResult Create(Profile profile) => Ok(profileService.Create(profile));

    [HttpPut]
    public IActionResult Update(Profile profile)
    {
        profileService.Update(profile);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        profileService.Delete(id);
        return Ok();
    }
}
