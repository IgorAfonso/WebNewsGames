using WebGames.Application.Request;

namespace WebGames.Application.AppService;

public static class PaginationAppService
{
    public static (bool Success, string ErrorMessage, int Page, int PageSize) Validate(PaginationRequest? request)
    {
        if (request is null)
            return (false, "Pagination parameters are required.", 0, 0);

        if (request.Page <= 0 || request.PageSize <= 0)
            return (false, "Page and pageSize must be greater than zero.", request.Page, request.PageSize);

        return (true, string.Empty, request.Page, request.PageSize);
    }
}
