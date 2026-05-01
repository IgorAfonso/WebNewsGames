using Microsoft.AspNetCore.Mvc;
using WebGames.API.Controllers;
using WebGames.Application.AppService.Interface;
using WebGames.Application.Request;
using WebGames.Application.Request.Articles;
using WebGames.Application.Request.Championship;
using WebGames.Application.Request.News;
using WebGames.Application.Response;
using ArticleDeleteResponse = WebGames.Application.Response.Articles.DeleteArticleResponse;
using ArticleGetByIdResponse = WebGames.Application.Response.Articles.GetByIdResponse;
using ArticleGetByNameResponse = WebGames.Application.Response.Articles.GetByNameResponse;
using ArticlePatchResponse = WebGames.Application.Response.Articles.PatchArticleResponse;
using ArticlePostResponse = WebGames.Application.Response.Articles.PostArticleResponse;
using ChampionshipDeleteResponse = WebGames.Application.Response.Championship.DeleteChampionshipResponse;
using ChampionshipGetByIdResponse = WebGames.Application.Response.Championship.GetByIdResponse;
using ChampionshipGetByNameResponse = WebGames.Application.Response.Championship.GetByNameResponse;
using ChampionshipPatchResponse = WebGames.Application.Response.Championship.PatchChampionshipResponse;
using ChampionshipPostResponse = WebGames.Application.Response.Championship.PostChampionshipResponse;
using NewsDeleteResponse = WebGames.Application.Response.News.DeleteNewsResponse;
using NewsGetByIdResponse = WebGames.Application.Response.News.GetByIdResponse;
using NewsGetByNameResponse = WebGames.Application.Response.News.GetByNameResponse;
using NewsPatchResponse = WebGames.Application.Response.News.PatchNewsResponse;
using NewsPostResponse = WebGames.Application.Response.News.PostNewsResponse;

namespace WebGames.Test;

public class ControllerEndpointTests
{
    [Test]
    public async Task ArticleGetAll_ReturnsOkResponse()
    {
        var appService = new FakeArticlesAppService();
        var controller = new ArticlesController(appService);

        var request = new PaginationRequest { Page = 2, PageSize = 5 };

        var result = await controller.GetAll(request);

        AssertOk(result);
        Assert.That(appService.PaginationRequest, Is.SameAs(request));
    }

    [Test]
    public async Task ArticleGetById_ReturnsOkResponse()
    {
        var id = Guid.NewGuid();
        var appService = new FakeArticlesAppService();
        var controller = new ArticlesController(appService);

        var result = await controller.GetById(id);

        AssertOk(result);
        Assert.That(appService.GetByIdId, Is.EqualTo(id));
    }

    [Test]
    public async Task ArticlePost_ReturnsCreatedResponse()
    {
        var request = new PostArticleRequest { Title = "Article title", Content = "Article content" };
        var appService = new FakeArticlesAppService();
        var controller = new ArticlesController(appService);

        var result = await controller.PostNews(request);

        AssertCreated(result);
        Assert.That(appService.PostRequest, Is.SameAs(request));
    }

    [Test]
    public async Task ArticlePatch_ReturnsOkResponse()
    {
        var request = new PatchArticleRequest { Id = Guid.NewGuid(), Title = "Updated title", Content = "Updated content" };
        var appService = new FakeArticlesAppService();
        var controller = new ArticlesController(appService);

        var result = await controller.PatchNews(request);

        AssertOk(result);
        Assert.That(appService.PatchRequest, Is.SameAs(request));
    }

    [Test]
    public async Task ArticleDelete_ReturnsOkResponse()
    {
        var id = Guid.NewGuid();
        var appService = new FakeArticlesAppService();
        var controller = new ArticlesController(appService);

        var result = await controller.DeleteNews(id);

        AssertOk(result);
        Assert.That(appService.DeleteId, Is.EqualTo(id));
    }

    [Test]
    public async Task ChampionshipGetAll_ReturnsOkResponse()
    {
        var appService = new FakeChampionshipAppService();
        var controller = new ChampionshipsController(appService);

        var request = new PaginationRequest { Page = 2, PageSize = 5 };

        var result = await controller.GetAll(request);

        AssertOk(result);
        Assert.That(appService.PaginationRequest, Is.SameAs(request));
    }

    [Test]
    public async Task ChampionshipGetById_ReturnsOkResponse()
    {
        var id = Guid.NewGuid();
        var appService = new FakeChampionshipAppService();
        var controller = new ChampionshipsController(appService);

        var result = await controller.GetById(id);

        AssertOk(result);
        Assert.That(appService.GetByIdId, Is.EqualTo(id));
    }

    [Test]
    public async Task ChampionshipPost_ReturnsCreatedResponse()
    {
        var request = new PostChampionshipRequest
        {
            ChampionshipName = "Championship name",
            ChampionshipDescription = "Championship description",
            ChampionshipSystem = "bracket",
            Place = "Online",
            StartDate = DateTime.UtcNow.AddDays(5),
            EndDate = DateTime.UtcNow.AddDays(10)
        };
        var appService = new FakeChampionshipAppService();
        var controller = new ChampionshipsController(appService);

        var result = await controller.PostChamp(request);

        AssertCreated(result);
        Assert.That(appService.PostRequest, Is.SameAs(request));
    }

    [Test]
    public async Task ChampionshipPatch_ReturnsOkResponse()
    {
        var request = new PatchChampionshipRequest
        {
            ChampId = Guid.NewGuid(),
            ChampionshipName = "Updated championship",
            ChampionshipDescription = "Updated description",
            ChampionshipSystem = "group",
            Place = "Online",
            StartDate = DateTime.UtcNow.AddDays(5),
            EndDate = DateTime.UtcNow.AddDays(10)
        };
        var appService = new FakeChampionshipAppService();
        var controller = new ChampionshipsController(appService);

        var result = await controller.PatchChamp(request);

        AssertOk(result);
        Assert.That(appService.PatchRequest, Is.SameAs(request));
    }

    [Test]
    public async Task ChampionshipDelete_ReturnsOkResponse()
    {
        var id = Guid.NewGuid();
        var appService = new FakeChampionshipAppService();
        var controller = new ChampionshipsController(appService);

        var result = await controller.DeleteChamp(id);

        AssertOk(result);
        Assert.That(appService.DeleteId, Is.EqualTo(id));
    }

    [Test]
    public async Task NewsGetAll_ReturnsOkResponse()
    {
        var appService = new FakeNewsAppService();
        var controller = new NewsController(appService);

        var request = new PaginationRequest { Page = 2, PageSize = 5 };

        var result = await controller.GetAll(request);

        AssertOk(result);
        Assert.That(appService.PaginationRequest, Is.SameAs(request));
    }

    [Test]
    public async Task NewsGetById_ReturnsOkResponse()
    {
        var id = Guid.NewGuid();
        var appService = new FakeNewsAppService();
        var controller = new NewsController(appService);

        var result = await controller.GetById(id);

        AssertOk(result);
        Assert.That(appService.GetByIdId, Is.EqualTo(id));
    }

    [Test]
    public async Task NewsPost_ReturnsCreatedResponse()
    {
        var request = new PostNewsRequest { Title = "News title", Content = "News content" };
        var appService = new FakeNewsAppService();
        var controller = new NewsController(appService);

        var result = await controller.PostNews(request);

        AssertCreated(result);
        Assert.That(appService.PostRequest, Is.SameAs(request));
    }

    [Test]
    public async Task NewsPatch_ReturnsOkResponse()
    {
        var request = new PatchNewsRequest { Id = Guid.NewGuid(), Title = "Updated title", Content = "Updated content" };
        var appService = new FakeNewsAppService();
        var controller = new NewsController(appService);

        var result = await controller.PatchNews(request);

        AssertOk(result);
        Assert.That(appService.PatchRequest, Is.SameAs(request));
    }

    [Test]
    public async Task NewsDelete_ReturnsOkResponse()
    {
        var id = Guid.NewGuid();
        var appService = new FakeNewsAppService();
        var controller = new NewsController(appService);

        var result = await controller.DeleteNews(id);

        AssertOk(result);
        Assert.That(appService.DeleteId, Is.EqualTo(id));
    }

    private static void AssertOk(IActionResult result)
    {
        var okResult = result as OkObjectResult;

        Assert.That(okResult, Is.Not.Null);
        Assert.That(ReadProperty<bool>(okResult!.Value, "success"), Is.True);
        Assert.That(ReadProperty<string>(okResult.Value, "message"), Is.EqualTo("Success to process the request."));
    }

    private static void AssertCreated(IActionResult result)
    {
        var createdResult = result as CreatedResult;

        Assert.That(createdResult, Is.Not.Null);
        Assert.That(ReadProperty<bool>(createdResult!.Value, "success"), Is.True);
        Assert.That(ReadProperty<string>(createdResult.Value, "message"), Is.EqualTo("Success to process the request."));
    }

    private static T? ReadProperty<T>(object? source, string propertyName)
    {
        if (source is null)
            return default;

        return (T?)source.GetType().GetProperty(propertyName)?.GetValue(source);
    }

    private sealed class FakeArticlesAppService : IArticlesAppService
    {
        public Guid? DeleteId { get; private set; }
        public Guid? GetByIdId { get; private set; }
        public PaginationRequest? PaginationRequest { get; private set; }
        public PatchArticleRequest? PatchRequest { get; private set; }
        public PostArticleRequest? PostRequest { get; private set; }

        public Task<(bool, ArticleDeleteResponse)> DeleteArticle(Guid Id)
        {
            DeleteId = Id;
            return Task.FromResult((true, new ArticleDeleteResponse { Id = Id, Title = "Article title", Content = "Article content" }));
        }

        public Task<(bool, ArticleGetByIdResponse)> GetById(Guid Id)
        {
            GetByIdId = Id;
            return Task.FromResult((true, new ArticleGetByIdResponse { Id = Id, Title = "Article title", Content = "Article content" }));
        }

        public Task<(bool, PagedResponse<ArticleGetByIdResponse>)> GetAll(PaginationRequest request)
        {
            PaginationRequest = request;
            return Task.FromResult((true, new PagedResponse<ArticleGetByIdResponse>
            {
                Items = [new ArticleGetByIdResponse { Id = Guid.NewGuid(), Title = "Article title", Content = "Article content" }],
                Page = request.Page,
                PageSize = request.PageSize,
                TotalItems = 1,
                TotalPages = 1
            }));
        }

        public Task<(bool, ArticlePatchResponse)> PatchArticle(PatchArticleRequest request)
        {
            PatchRequest = request;
            return Task.FromResult((true, new ArticlePatchResponse { Id = request.Id, Title = request.Title, Content = request.Content }));
        }

        public Task<(bool, ArticlePostResponse)> PostArticle(PostArticleRequest request)
        {
            PostRequest = request;
            return Task.FromResult((true, new ArticlePostResponse { Id = Guid.NewGuid(), Title = request.Title, Content = request.Content }));
        }
    }

    private sealed class FakeChampionshipAppService : IChampionshipAppService
    {
        public Guid? DeleteId { get; private set; }
        public Guid? GetByIdId { get; private set; }
        public PaginationRequest? PaginationRequest { get; private set; }
        public PatchChampionshipRequest? PatchRequest { get; private set; }
        public PostChampionshipRequest? PostRequest { get; private set; }

        public Task<(bool, ChampionshipDeleteResponse)> DeleteChamp(Guid Id)
        {
            DeleteId = Id;
            return Task.FromResult((true, BuildDeleteResponse(Id)));
        }

        public Task<(bool, ChampionshipGetByIdResponse)> GetById(Guid Id)
        {
            GetByIdId = Id;
            return Task.FromResult((true, BuildGetByIdResponse(Id)));
        }

        public Task<(bool, PagedResponse<ChampionshipGetByIdResponse>)> GetAll(PaginationRequest request)
        {
            PaginationRequest = request;
            return Task.FromResult((true, new PagedResponse<ChampionshipGetByIdResponse>
            {
                Items = [BuildGetByIdResponse(Guid.NewGuid())],
                Page = request.Page,
                PageSize = request.PageSize,
                TotalItems = 1,
                TotalPages = 1
            }));
        }

        public Task<(bool, ChampionshipPatchResponse)> PatchChamp(PatchChampionshipRequest request)
        {
            PatchRequest = request;
            return Task.FromResult((true, new ChampionshipPatchResponse
            {
                ChampId = request.ChampId,
                ChampionshipName = request.ChampionshipName,
                ChampionshipDescription = request.ChampionshipDescription,
                ChampionshipSystem = request.ChampionshipSystem,
                Place = request.Place,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                IsExhibitionOnly = true
            }));
        }

        public Task<(bool, ChampionshipPostResponse)> PostChamp(PostChampionshipRequest request)
        {
            PostRequest = request;
            return Task.FromResult((true, new ChampionshipPostResponse
            {
                ChampId = Guid.NewGuid(),
                ChampionshipName = request.ChampionshipName,
                ChampionshipDescription = request.ChampionshipDescription,
                ChampionshipSystem = request.ChampionshipSystem,
                Place = request.Place,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                IsExhibitionOnly = true
            }));
        }

        private static ChampionshipDeleteResponse BuildDeleteResponse(Guid id)
        {
            return new ChampionshipDeleteResponse
            {
                ChampId = id,
                ChampionshipName = "Championship name",
                ChampionshipDescription = "Championship description",
                ChampionshipSystem = "bracket",
                Place = "Online",
                StartDate = DateTime.UtcNow.AddDays(5),
                EndDate = DateTime.UtcNow.AddDays(10),
                IsExhibitionOnly = true
            };
        }

        private static ChampionshipGetByIdResponse BuildGetByIdResponse(Guid id)
        {
            return new ChampionshipGetByIdResponse
            {
                ChampId = id,
                ChampionshipName = "Championship name",
                ChampionshipDescription = "Championship description",
                ChampionshipSystem = "bracket",
                Place = "Online",
                StartDate = DateTime.UtcNow.AddDays(5),
                EndDate = DateTime.UtcNow.AddDays(10),
                IsExhibitionOnly = true
            };
        }

        private static ChampionshipGetByNameResponse BuildGetByNameResponse(Guid id, string name)
        {
            return new ChampionshipGetByNameResponse
            {
                ChampId = id,
                ChampionshipName = name,
                ChampionshipDescription = "Championship description",
                ChampionshipSystem = "bracket",
                Place = "Online",
                StartDate = DateTime.UtcNow.AddDays(5),
                EndDate = DateTime.UtcNow.AddDays(10),
                IsExhibitionOnly = true
            };
        }
    }

    private sealed class FakeNewsAppService : INewsAppService
    {
        public Guid? DeleteId { get; private set; }
        public Guid? GetByIdId { get; private set; }
        public PaginationRequest? PaginationRequest { get; private set; }
        public PatchNewsRequest? PatchRequest { get; private set; }
        public PostNewsRequest? PostRequest { get; private set; }

        public Task<(bool, NewsDeleteResponse)> DeleteNews(Guid Id)
        {
            DeleteId = Id;
            return Task.FromResult((true, new NewsDeleteResponse { Id = Id, Title = "News title", Content = "News content" }));
        }

        public Task<(bool, NewsGetByIdResponse)> GetById(Guid Id)
        {
            GetByIdId = Id;
            return Task.FromResult((true, new NewsGetByIdResponse { Id = Id, Title = "News title", Content = "News content" }));
        }

        public Task<(bool, PagedResponse<NewsGetByIdResponse>)> GetAll(PaginationRequest request)
        {
            PaginationRequest = request;
            return Task.FromResult((true, new PagedResponse<NewsGetByIdResponse>
            {
                Items = [new NewsGetByIdResponse { Id = Guid.NewGuid(), Title = "News title", Content = "News content" }],
                Page = request.Page,
                PageSize = request.PageSize,
                TotalItems = 1,
                TotalPages = 1
            }));
        }

        public Task<(bool, NewsPatchResponse)> PatchNews(PatchNewsRequest request)
        {
            PatchRequest = request;
            return Task.FromResult((true, new NewsPatchResponse { Id = request.Id, Title = request.Title, Content = request.Content }));
        }

        public Task<(bool, NewsPostResponse)> PostNews(PostNewsRequest request)
        {
            PostRequest = request;
            return Task.FromResult((true, new NewsPostResponse { Id = Guid.NewGuid(), Title = request.Title, Content = request.Content }));
        }
    }
}
