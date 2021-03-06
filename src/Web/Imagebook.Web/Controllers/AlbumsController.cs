﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Imagebook.Data;
using Imagebook.Data.Models;
using Imagebook.Data.UnitOfWork.Contracts;
using Imagebook.Data.ViewModels.Albums;
using Imagebook.Data.ViewModels.Pictures;
using Imagebook.Services.Contracts;
using Imagebook.Web.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SixLabors.ImageSharp;


namespace Imagebook.Web.Controllers
{
    public class AlbumsController : Controller
    {
        private readonly IAlbumsService _albumsService;

        public AlbumsController(IAlbumsService albumsService)
        {
            this._albumsService = albumsService;
        }

        [Authorize(Roles = UserRoleConstants.AdminUser)]
        [HttpGet]
        public async Task<IActionResult> All(string search, string sortOrder, int? currentPage = 1)
        {
            var albums = await this._albumsService.GetPageAsync(search, sortOrder, currentPage);

            return this.View(albums);
        }

        [Authorize(Roles = UserRoleConstants.AdminUser)]
        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var album = await this._albumsService.GetWithPicturesByIdAsync(id);

            return this.View(album);
        }
    }
}
