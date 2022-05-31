﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Kessewa.Application.Shared.Models
{
	public class PaginatedCommand
	{
		private int _pageSize = 10;
		private int _pageNumber = 1;

		public int PageSize
		{
			get => _pageSize <= 0 ? 10 : _pageSize;
			set => _pageSize = value;
		}

		[JsonProperty("currentPage")]
		public int PageNumber
		{
			get => _pageNumber <= 0 ? 1 : _pageNumber;
			set => _pageNumber = value;
		}

		[JsonProperty("start")]
		public int Take { get; set; } = 0;
		public string OrderBy { get; set; }
		public int Skip { get; set; }

		public string Filter { get; set; }

		public string Search { get; set; }
		public string OtherJson { get; set; }

	}
	public class PaginatedQuery
	{
		public IQueryCollection FormQuery { get; }

		public PaginatedQuery(IQueryCollection formQuery)
		{
			FormQuery = formQuery;
		}

		private readonly int _pageSize = 10;
		private readonly int _pageNumber = 1;
		private readonly int _start = 0;

		public int PageSize => string.IsNullOrEmpty(FormQuery["pageSize"].ToString()) ? _pageSize : Convert.ToInt32(FormQuery["pageSize"].ToString() ?? $"{_pageSize}");

		public int PageNumber => string.IsNullOrEmpty(FormQuery["pageNumber"].ToString())
			? _pageNumber
			: Convert.ToInt32(FormQuery["pageNumber"].ToString() ?? $"{_pageNumber}");


		public int Take => string.IsNullOrEmpty(FormQuery["start"].ToString())
			? _start
			: Convert.ToInt32(FormQuery["start"].ToString() ?? $"{_start}");

		public string OrderBy => FormQuery["orderBy"].ToString();
		public string Filter => FormQuery["filter"].ToString();
		public string Search => FormQuery["search"].ToString().ToLower();

	}
}
