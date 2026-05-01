using WebGames.Domain.Entities;
using WebGames.Domain.Interface.Service;

namespace WebGames.Domain.Service;

public class NewsDomainService : INewsDomainService
{
    private const int TitleMaxLength = 200;
    private const int ContentMaxLength = 5000;
    private const int CaptionMaxLength = 700;

    public async Task<(bool, string)> CreateNewsAsync(News request) => ValidateNews(request);
    public async Task<(bool, string)> GetNewsByIdAsync(Guid id)
    {
        if(id == Guid.Empty)
            return (false, "Invalid news ID.");

        return (true, "News retrieved successfully.");
    }

    public async Task<(bool, string)> UpdateNewsAsync(News request)
    {
        if(request.Id == Guid.Empty)
            return (false, "Invalid news ID.");

        return ValidateNews(request);
    }

    public async Task<(bool, string)> DeleteNewsAsync(Guid id)
    {
        if(id == Guid.Empty)
            return (false, "Invalid news ID.");

        return (true, "News deleted successfully.");
    }

    private static (bool, string) ValidateNews(News request)
    {
        if (string.IsNullOrWhiteSpace(request.Title))
            return (false, "Title cannot be null or empty.");

        if (request.Title.Length > TitleMaxLength)
            return (false, "The title cannot contain more than 200 characters.");

        var contentValidation = ValidateContentBlock(request.Content, request.ImageBase64, request.ImageCaption, true, "1");

        if (!contentValidation.Item1)
            return contentValidation;

        var content2Validation = ValidateContentBlock(request.Content2, request.Image2Base64, request.Image2Caption, false, "2");

        if (!content2Validation.Item1)
            return content2Validation;

        return ValidateContentBlock(request.Content3, request.Image3Base64, request.Image3Caption, false, "3");
    }

    private static (bool, string) ValidateContentBlock(
        string? content,
        string? imageBase64,
        string? imageCaption,
        bool required,
        string blockNumber)
    {
        var hasContent = !string.IsNullOrWhiteSpace(content);
        var hasImage = !string.IsNullOrWhiteSpace(imageBase64);
        var hasCaption = !string.IsNullOrWhiteSpace(imageCaption);

        if (required && (!hasContent || !hasImage || !hasCaption))
            return (false, "The minimum structure must contain at least one title, one content, one image and one caption.");

        if (!required && !hasContent && !hasImage && !hasCaption)
            return (true, string.Empty);

        if (!hasContent || !hasImage || !hasCaption)
            return (false, $"Content, image and image caption must be provided together for block {blockNumber}.");

        if (content!.Length > ContentMaxLength)
            return (false, "The content cannot contain more than 5000 characters.");

        if (imageCaption!.Length > CaptionMaxLength)
            return (false, "The caption cannot contain more than 700 characters.");

        if (!IsValidBase64Image(imageBase64))
            return (false, $"Image {blockNumber} must be a valid base64 value.");

        return (true, string.Empty);
    }

    private static bool IsValidBase64Image(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return false;

        var base64 = value.Trim();
        var commaIndex = base64.IndexOf(',');

        if (commaIndex >= 0)
            base64 = base64[(commaIndex + 1)..];

        Span<byte> buffer = new byte[base64.Length];
        return Convert.TryFromBase64String(base64, buffer, out _);
    }
}
