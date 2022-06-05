using System;
using System.Collections.Generic;

namespace Kessewa.Application.Shared.Domain.Models
{
    public class PaginatedList<T>
    {
        public List<T> Data { get; }
        public int TotalPages => (int) Math.Ceiling(TotalCount / (double) PageSize);
        public int PageSize { get; }
        public int TotalCount { get; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;
        public int From => ((CurrentPage - 1) * PageSize) + 1;
        public int To => (From + PageSize) - 1;
        public int CurrentPage { get; }

        public PaginatedList(List<T> data,
            int totalCount,
            int currentPage,
            int pageSize)
        {
            Data = data;
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalCount = totalCount;
        }
    }
}
