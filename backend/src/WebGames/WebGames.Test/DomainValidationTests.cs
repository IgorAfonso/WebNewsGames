using WebGames.Domain.Entities;
using WebGames.Domain.Service;

namespace WebGames.Test;

public class DomainValidationTests
{
    private const string ValidBase64Image = "aW1hZ2U=";

    [Test]
    public async Task ArticleCreate_WhenTitleHasMoreThan200Characters_ReturnsFailure()
    {
        var service = new ArticleDomainService();
        var article = BuildValidArticle();
        article.Title = new string('a', 201);

        var result = await service.CreateArticleAsync(article);

        Assert.That(result.Item1, Is.False);
    }

    [Test]
    public async Task NewsCreate_WhenTitleHasMoreThan200Characters_ReturnsFailure()
    {
        var service = new NewsDomainService();
        var news = BuildValidNews();
        news.Title = new string('a', 201);

        var result = await service.CreateNewsAsync(news);

        Assert.That(result.Item1, Is.False);
    }

    [Test]
    public async Task ChampionshipCreate_WhenNameHasMoreThan200Characters_ReturnsFailure()
    {
        var service = new ChampionshipDomainService();
        var championship = new Championship
        {
            Name = new string('a', 201),
            Description = "Championship description"
        };

        var result = await service.CreateChampionshipAsync(championship);

        Assert.That(result.Item1, Is.False);
    }

    [Test]
    public async Task ArticleCreate_WhenFirstImageIsMissing_ReturnsFailure()
    {
        var service = new ArticleDomainService();
        var article = BuildValidArticle();
        article.ImageBase64 = null;

        var result = await service.CreateArticleAsync(article);

        Assert.That(result.Item1, Is.False);
    }

    [Test]
    public async Task NewsCreate_WhenImageHasNoCaption_ReturnsFailure()
    {
        var service = new NewsDomainService();
        var news = BuildValidNews();
        news.ImageCaption = null;

        var result = await service.CreateNewsAsync(news);

        Assert.That(result.Item1, Is.False);
    }

    [Test]
    public async Task ArticleCreate_WhenOptionalBlockIsIncomplete_ReturnsFailure()
    {
        var service = new ArticleDomainService();
        var article = BuildValidArticle();
        article.Content2 = "Second content";
        article.Image2Base64 = ValidBase64Image;

        var result = await service.CreateArticleAsync(article);

        Assert.That(result.Item1, Is.False);
    }

    [Test]
    public async Task NewsCreate_WhenImageIsNotBase64_ReturnsFailure()
    {
        var service = new NewsDomainService();
        var news = BuildValidNews();
        news.ImageBase64 = "not-base64";

        var result = await service.CreateNewsAsync(news);

        Assert.That(result.Item1, Is.False);
    }

    [Test]
    public async Task ArticleCreate_WhenThreeContentBlocksAreValid_ReturnsSuccess()
    {
        var service = new ArticleDomainService();
        var article = BuildValidArticle();
        article.Content2 = "Second content";
        article.Image2Base64 = ValidBase64Image;
        article.Image2Caption = "Second caption";
        article.Content3 = "Third content";
        article.Image3Base64 = "data:image/png;base64,aW1hZ2U=";
        article.Image3Caption = "Third caption";

        var result = await service.CreateArticleAsync(article);

        Assert.That(result.Item1, Is.True);
    }

    private static Article BuildValidArticle()
    {
        return new Article
        {
            Title = "Article title",
            Content = "Article content",
            ImageBase64 = ValidBase64Image,
            ImageCaption = "Article image caption"
        };
    }

    private static News BuildValidNews()
    {
        return new News
        {
            Title = "News title",
            Content = "News content",
            ImageBase64 = ValidBase64Image,
            ImageCaption = "News image caption"
        };
    }
}
