using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.dto;

public readonly record struct ApiResultPagination<TData>
{
    public int Page { get; }
    public long Count { get; }
    public bool IsSuccess => !_errors.Any();
    public List<TData> Data { get; } = default;
    private readonly List<ApiError> _errors = [];
    public List<ApiError> Errors => _errors;

    private ApiResultPagination(ApiError error)
    {
        _errors = [error];
    }

    private ApiResultPagination(List<TData> items, int count, int pageNumber, int pageSize)
    {
        Page = pageSize == -1 ? 1 : (int)Math.Ceiling(count / (double)pageSize);
        Count = count;
        Data = items;
    }

    public static implicit operator ApiResultPagination<TData>(ApiError error)
    {
        return new ApiResultPagination<TData>(error);
    }

    public static async Task<ApiResultPagination<TData>> CreateAsync(IQueryable<TData> source, int pageNumber, int pageSize)
    {
        int count = source.Count();
        if (pageSize != -1)
        {
            source = source.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }

        List<TData> items = await source.ToListAsync();

        return new ApiResultPagination<TData>(items, count, pageNumber, pageSize);
    }

    public static async Task<ApiResultPagination<TData>> CreateAsync(IQueryable<TData> source, int pageNumber, int pageSize, CancellationToken ct)
    {
        int count = await source.CountAsync(ct);
        if (pageSize != -1)
        {
            source = source.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }
        List<TData> items = await source.ToListAsync(ct);

        return new ApiResultPagination<TData>(items, count, pageNumber, pageSize);
    }

    public static ApiResultPagination<TData> Create(IQueryable<TData> source, int pageNumber, int pageSize)
    {
        int count = source.Count();
        List<TData> items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

        return new ApiResultPagination<TData>(items, count, pageNumber, pageSize);
    }
}

public static class MappingExtensions
{
    public static Task<ApiResultPagination<TDestination>> PaginatedListAsync<TDestination>(this IQueryable<TDestination> queryable, int pageNumber, int pageSize) where TDestination : class
    {
        return ApiResultPagination<TDestination>.CreateAsync(queryable.AsNoTracking(), pageNumber, pageSize);
    }

    public static Task<ApiResultPagination<TDestination>> PaginatedListAsync<TDestination>(this IQueryable<TDestination> queryable, int pageNumber, int pageSize, CancellationToken ct) where TDestination : class
    {
        return ApiResultPagination<TDestination>.CreateAsync(queryable.AsNoTracking(), pageNumber, pageSize, ct);
    }
}
