using System;
using System.Collections.Generic;
using System.IO;

class ListOfFiles
{
    static void Main()
    {
        string rootDirectory = @"Dir";        

        List<FileInfo> files = ReturnUniqueFiles(rootDirectory);

        foreach (var file in files)
        {
            Console.WriteLine(file);
        }
    }

    public static List<FileInfo> ReturnUniqueFiles(string rootDirectory)
    {
        if (!Directory.Exists(rootDirectory))
        {
            throw new FileNotFoundException("Directory path not found");
        }

        DirectoryInfo dir = new DirectoryInfo(rootDirectory);

        List<FileInfo> files = new List<FileInfo>();
        TraverseDir(dir, files);

        return files;
    }

    private static void TraverseDir(DirectoryInfo dir, List<FileInfo> files)
    {        
        FileInfo[] filesInCurrentDirectory = dir.GetFiles();
        AddFiles(filesInCurrentDirectory, files);

        DirectoryInfo[] children = dir.GetDirectories();
                
        foreach (DirectoryInfo child in children)
        {
            TraverseDir(child, files);
        }
    }

    private static void AddFiles(FileInfo[] filesInCurrentDirectory, List<FileInfo> files)
    {
        foreach (FileInfo file in filesInCurrentDirectory)
        {
            if (!IsFileInList(file, files))
            {
                files.Add(file);
            }
        }
    }

    private static bool IsFileInList(FileInfo file, List<FileInfo> files)
    {
        foreach (FileInfo fileInList in files)
        {
            string currentFilePath = fileInList.FullName;
            string newFilePath = file.FullName;

            if (AreFilesEqual(currentFilePath, newFilePath))
            {
                return true;
            }
        }

        return false;
    }

    private static bool AreFilesEqual(string file1, string file2)
    {
        byte[] file1Bytes = File.ReadAllBytes(file1);
        byte[] file2Bytes = File.ReadAllBytes(file2);

        if (file1Bytes.Length == file2Bytes.Length)
	    {
	        for (int i = 0; i < file1Bytes.Length; i++)
	        {
	            if (file1Bytes[i] != file2Bytes[i])
	            {
		            return false;
	            }
	        }
	        return true;
	    }
	    return false;
    }
}