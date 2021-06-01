﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartGarage.Data.Models;
using SmartGarage.Service.Contracts;
using SmartGarage.Service.DTOs.CreateDTOs;
using SmartGarage.Service.DTOs.GetDTOs;
using SmartGarage.Service.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartGarage.Controllers
{
	public class OrderController : Controller
	{
		private readonly IOrderService service;
		private readonly UserManager<User> userManager;

		public OrderController(IOrderService service, UserManager<User> userManager)
		{
			this.service = service;
			this.userManager = userManager;
		}

		public async Task<IActionResult> Index(string name, int pageNumber = 1)
		{
			var pageSize = 10;
			var user = await userManager.FindByNameAsync(User.Identity.Name);

			var orders = await service.GetAll(user, name);

			return View(PaginatedList<GetOrderDTO>.CreateAsync(orders, pageNumber, pageSize));
		}

		[HttpGet()]
		public async Task<IActionResult> Details(int id, [FromQuery]string currency="EUR")
		{
			var order = await service.GetAsync(id, currency);

			if (order == null)
			{
				return NotFound();
			}

			return View(order);
		}

		public IActionResult Create()
		{
			return View();
		}

		//[HttpGet()]
		//public async Task<IActionResult> Create(CreateOrderDTO createOrder)
		//{
			//var order = await service.GetAsync(id, currency);

			//if (order == null)
			//{
			//	return NotFound();
			//}

			//return View(order);
		//}
	}
}
