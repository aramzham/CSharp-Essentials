using System.IO;

namespace OrganizeFolder
{
    public class SortFiles
    {
        public void SortFilesByExtension(string path)
        {
            var files = Directory.GetFiles(path);
            foreach (var file in files)
            { 

                if (Path.GetExtension(file) != string.Empty)
                {
                    if (Directory.Exists(Path.Combine(path, Path.GetExtension(file))))
                        File.Move(file, Path.Combine(path, Path.GetExtension(file),Path.GetFileName(file)));
                    else
                    {
                        Directory.CreateDirectory(Path.Combine(path, Path.GetExtension(file)));
                        File.Move(file, Path.Combine(path, Path.GetExtension(file), Path.GetFileName(file)));
                    }
                }
                else
                {
                    Directory.CreateDirectory(Path.Combine(path, "Files with no extensions"));
                    File.Move(file, Path.Combine(path, "Files with no extensions", Path.GetFileName(file)));
                } 
            }
        }

    }
}
