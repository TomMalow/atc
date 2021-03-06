﻿using System;
using System.Collections.Generic;

namespace Atc.Rest.Results
{
    public class Pagination<T>
    {
        public Pagination()
        {
            // Dummy for serialization.
        }

        public Pagination(List<T> items, int pageSize, string? queryString, int pageIndex, int totalCount)
        {
            if (items is null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            Items = new List<T>(items);
            PageSize = pageSize;
            QueryString = queryString;
            PageIndex = pageIndex;
            TotalCount = totalCount;
            TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
        }

        public Pagination(List<T> items, int pageSize, string? queryString, string? continuationToken)
        {
            if (items is null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            Items = new List<T>(items);
            PageSize = pageSize;
            QueryString = queryString;
            ContinuationToken = continuationToken;
        }

        public int PageSize { get; set; }

        public int? PageIndex { get; set; }

        public string? QueryString { get; set; }

        public string? ContinuationToken { get; set; }

        public int Count => Items?.Count ?? 0;

        public int? TotalCount { get; set; }

        public int? TotalPages { get; set; }

        public List<T> Items { get; set; } = new List<T>();

        public override string ToString()
        {
            return $"{nameof(Items)}.Count: {Items.Count}, {nameof(PageSize)}: {PageSize}, {nameof(PageIndex)}: {PageIndex}, {nameof(QueryString)}: {QueryString}, , {nameof(ContinuationToken)}: {ContinuationToken}, {nameof(TotalCount)}: {TotalCount}, {nameof(TotalPages)}: {TotalPages}";
        }
    }
}