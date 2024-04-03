
string sourceDirectory = "C:\\Users\\jakub.chabrowski\\Desktop\\test";
string destinationDirectory = "C:\\Users\\jakub.chabrowski\\Desktop\\test1";

if (!Directory.Exists(sourceDirectory) || !Directory.Exists(destinationDirectory))
{
    Console.WriteLine("Source or destination directory does not exist.");
    return;
}

try
{
    MoveFiles(sourceDirectory, destinationDirectory);
    Console.WriteLine("Files moved successfully.");
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred: {ex.Message}");
}


static void MoveFiles(string sourceDir, string destinationDir)
{
    string[] subDirectories = Directory.GetDirectories(sourceDir);

    foreach (string subDir in subDirectories)
    {
        string[] files = Directory.GetFiles(subDir);
        foreach (string file in files)
        {
            string fileName = Path.GetFileName(file);
            string destFilePath = Path.Combine(destinationDir, fileName);

            if (File.Exists(destFilePath))
            {
                Console.WriteLine($"File {fileName} already exists in the destination directory. Skipping...");
            }
            else
            {
                File.Move(file, destFilePath);
                Console.WriteLine($"Moved file: {fileName}");
            }
        }
    }
}
