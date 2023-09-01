using JetBrains.Annotations;

namespace dotRMDY.Components.Helpers;

[PublicAPI]
public interface IFileSystemHelper
{
	bool FileExists(string filePath);
	bool FileExists(string filePath, long fileSize);
	void FileWriteAllBytes(string filePath, byte[] bytes);
	void FileDelete(string filePath);
	void CreateDirectory(string path);
}