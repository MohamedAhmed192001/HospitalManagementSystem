using Ardalis.GuardClauses;
using System;
using System.Diagnostics.CodeAnalysis;

namespace HospitalManagementSystem.ApiService.Infrastructure
{
    /// <summary>
    /// Extends <see cref="IEndpointRouteBuilder"/> with convenience overloads used inside
    /// <see cref="IEndpointRouteBuilderExtensions.Map"/>. Each method wraps the standard ASP.NET Core
    /// <c>Map{Verb}</c> call and automatically derives the endpoint name from the handler's
    /// method name, which becomes the OpenAPI <c>operationId</c> and is used for typed
    /// client generation (e.g. <c>nswag</c>).
    /// <para>
    /// <c>pattern</c> is optional for GET and POST (collection-level operations that typically
    /// have no route parameter) but required for PUT, PATCH, and DELETE (resource-level
    /// operations that almost always target a specific item by ID, e.g. <c>"{id}"</c>).
    /// </para>
    /// </summary>
    public static class EndpointRouteBuilderExtensions
    {
        public static IEndpointRouteBuilder MapGet(this IEndpointRouteBuilder builder, Delegate handler, [StringSyntax("Route")] string pattern = "")
        {
            Guard.Against.AnonymousMethod(handler);

            builder.MapGet(pattern, handler)
                .WithName(handler.Method.Name);

            return builder;
        }

        public static IEndpointRouteBuilder MapPost(this IEndpointRouteBuilder builder, Delegate handler, [StringSyntax("Route")] string pattern = "")
        {
            Guard.Against.AnonymousMethod(handler);

            builder.MapPost(pattern, handler)
                .WithName(handler.Method.Name);

            return builder;
        }

        public static IEndpointRouteBuilder MapPostDisableAntiForgery(this IEndpointRouteBuilder builder, Delegate handler, [StringSyntax("Route")] string pattern = "")
        {
            Guard.Against.AnonymousMethod(handler);

            builder.MapPost(pattern, handler)
                .DisableAntiforgery()
                .WithName(handler.Method.Name);

            return builder;
        }

        public static IEndpointRouteBuilder MapPut(this IEndpointRouteBuilder builder, Delegate handler, [StringSyntax("Route")] string pattern)
        {
            Guard.Against.AnonymousMethod(handler);

            builder.MapPut(pattern, handler)
                .WithName(handler.Method.Name);

            return builder;
        }

        public static IEndpointRouteBuilder MapDelete(this IEndpointRouteBuilder builder, Delegate handler, [StringSyntax("Route")] string pattern)
        {
            Guard.Against.AnonymousMethod(handler);

            builder.MapDelete(pattern, handler)
                .WithName(handler.Method.Name);

            return builder;
        }

        public static IEndpointRouteBuilder MapPatch(this IEndpointRouteBuilder builder, Delegate handler, [StringSyntax("Route")] string pattern = "")
        {
            Guard.Against.AnonymousMethod(handler);

            builder.MapPatch(pattern, handler)
                .WithName(handler.Method.Name);

            return builder;
        }
    }
}
