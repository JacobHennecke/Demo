namespace Demo_project.Domain.Models
{
    public record Asset(
        string assetId,
        string name,
        string description,
        string fileFormat,
        int fileSize,
        string path,
        string createdBy,
        string versionNumber,
        DateTime timestamp,
        string userName,
        string comments,
        string preview,
        string status
        );
}
