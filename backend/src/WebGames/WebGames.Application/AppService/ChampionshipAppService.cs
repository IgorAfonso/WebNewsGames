using WebGames.Application.AppService.Interface;
using WebGames.Application.Mappers;
using WebGames.Application.Request;
using WebGames.Application.Request.Championship;
using WebGames.Application.Response;
using WebGames.Application.Response.Championship;
using WebGames.Domain.Entities;
using WebGames.Domain.Interface.Repository;
using WebGames.Domain.Interface.Service;

namespace WebGames.Application.AppService;

public class ChampionshipAppService(
    IChampionshipRepository championshipRepository,
    IChampionshipDomainService championshipDomainService) : IChampionshipAppService
{
    public async Task<(bool, PagedResponse<GetByIdResponse>)> GetAll(PaginationRequest request)
    {
        var pagination = PaginationAppService.Validate(request);

        if (!pagination.Success)
            return (false, new PagedResponse<GetByIdResponse> { ErrorMessage = pagination.ErrorMessage });

        var championships = await championshipRepository.GetAllAsync();
        var totalItems = championships.Count;
        var items = championships
            .Skip((pagination.Page - 1) * pagination.PageSize)
            .Take(pagination.PageSize)
            .Select(ChampionshipMapper.ToGetByIdResponse)
            .ToList();

        return (true, new PagedResponse<GetByIdResponse>
        {
            Items = items,
            Page = pagination.Page,
            PageSize = pagination.PageSize,
            TotalItems = totalItems,
            TotalPages = (int)Math.Ceiling(totalItems / (double)pagination.PageSize)
        });
    }

    public async Task<(bool, DeleteChampionshipResponse)> DeleteChamp(Guid Id)
    {
        var existingChampionship = await championshipRepository.GetByIdAsync(Id);

        if (existingChampionship is null)
            return (false, new DeleteChampionshipResponse { ErrorMessage = "Championship not found." });

        var validation = await championshipDomainService.DeleteChampionshipAsync(Id);

        if (!validation.Item1)
            return (false, new DeleteChampionshipResponse { ErrorMessage = validation.Item2 });

        await championshipRepository.DeleteAsync(Id);
        return (true, ChampionshipMapper.ToDeleteResponse(existingChampionship));
    }

    public async Task<(bool, GetByIdResponse)> GetById(Guid Id)
    {
        var validation = await championshipDomainService.GetChampionshipByIdAsync(Id);

        if (!validation.Item1)
            return (false, new GetByIdResponse { ErrorMessage = validation.Item2 });

        var championship = await championshipRepository.GetByIdAsync(Id);

        if (championship is null)
            return (false, new GetByIdResponse { ErrorMessage = "Championship not found." });

        return (true, ChampionshipMapper.ToGetByIdResponse(championship));
    }

    public async Task<(bool, PatchChampionshipResponse)> PatchChamp(PatchChampionshipRequest request)
    {
        var existingChampionship = await championshipRepository.GetByIdAsync(request.ChampId);

        if (existingChampionship is null)
            return (false, new PatchChampionshipResponse { ErrorMessage = "Championship not found." });

        existingChampionship.Name = request.ChampionshipName ?? existingChampionship.Name;
        existingChampionship.Description = request.ChampionshipDescription ?? existingChampionship.Description;
        existingChampionship.System = request.ChampionshipSystem ?? existingChampionship.System;
        existingChampionship.Place = request.Place ?? existingChampionship.Place;
        existingChampionship.StartDate = request.StartDate ?? existingChampionship.StartDate;
        existingChampionship.EndDate = request.EndDate ?? existingChampionship.EndDate;
        existingChampionship.IsExhibitionOnly = true;

        var validation = await championshipDomainService.UpdateChampionshipAsync(existingChampionship);

        if (!validation.Item1)
            return (false, new PatchChampionshipResponse { ErrorMessage = validation.Item2 });

        await championshipRepository.UpdateAsync(existingChampionship);
        return (true, ChampionshipMapper.ToPatchResponse(existingChampionship));
    }

    public async Task<(bool, PostChampionshipResponse)> PostChamp(PostChampionshipRequest request)
    {
        var championship = new Championship
        {
            Name = request.ChampionshipName,
            Description = request.ChampionshipDescription,
            System = request.ChampionshipSystem,
            Place = request.Place,
            StartDate = request.StartDate ?? default,
            EndDate = request.EndDate ?? default,
            IsExhibitionOnly = true
        };

        var validation = await championshipDomainService.CreateChampionshipAsync(championship);

        if (!validation.Item1)
            return (false, new PostChampionshipResponse { ErrorMessage = validation.Item2 });

        await championshipRepository.AddAsync(championship);
        return (true, ChampionshipMapper.ToPostResponse(championship));
    }
}
