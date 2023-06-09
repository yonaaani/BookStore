﻿using System.Text.Json;
using MyBookListEntityFrameforkDAL.Pagination;

namespace TeamworkSystem.WebAPI.Extensions
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
