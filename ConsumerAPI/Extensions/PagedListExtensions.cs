﻿using DAL.Pagination;
using System.Text.Json;

namespace ConsumerAPI.Extensions
{
    public static class PagedListExtensions
    {
        public static string SerializeMetadata<T>(this PagedList<T> list)
        {
            return JsonSerializer.Serialize(
                list.Metadata,
                new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
        }
    }
}
