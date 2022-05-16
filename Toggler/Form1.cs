using System.IO.Compression;
using System.Text;

namespace Toggler
{
    public partial class Form1 : Form
    {
        private bool isIronman = false;

        private string BaseFullFilePath = "";
        private string BaseDirectory = "";
        private string BaseName = "";
        private string BackupFilePath = "";
        private string RenamedBaseFullFilePath = "";
        

        private static readonly Encoding encoding = Encoding.UTF8;
        private const int _chunkSize = 4096;
        private static readonly string[] Splitters = new string[] {
            "\r\n", "\r", "\n"
        };

        private const string NewLineChar = "\n";
        private const string IronmanEnabled = "ironman=yes";
        private const string IronmanDisabled = "ironman=no";
        private const string MetaFile = "meta";
        private const string GamestateFile = "gamestate";


        public Form1()
        {
            InitializeComponent();
        }

        private string ReadFileStream(StreamReader stream)
        {
            var output = new EncodedStringWriter(encoding);
            output.NewLine = NewLineChar;

            string line;
            while ((line = stream.ReadLine()) != null)
            {
                output.WriteLine(line);
            }
            
            stream.Close();
            return output.ToString();
        }

        private void toggle_btn_Click(object sender, EventArgs e)
        {
            CreateBackup();
            isIronman = !isIronman;
            status_txt.Text = "Updating ironman status...";
            status_txt.Refresh();

            // Read the files...
            var gamestateFile = "";
            var metaFile = "";
            var oldIronman = isIronman ? IronmanDisabled : IronmanEnabled;
            var newIronman = isIronman ? IronmanEnabled : IronmanDisabled;
            
            using (var fileStream = File.Open(BaseFullFilePath, FileMode.Open, FileAccess.ReadWrite))
            {
                using (var zip = new ZipArchive(fileStream, ZipArchiveMode.Update))
                {
                    var entriesToRecreate = new List<(string, List<string>)>();

                    foreach (var entry in zip.Entries)
                    {
                        var contents = ReadFileStream(new StreamReader(entry.Open(), encoding)).Replace(oldIronman, newIronman);
                        if (entry.Name == MetaFile && isIronman && !contents.Contains(IronmanEnabled))
                        {
                            contents = $"{contents}{IronmanEnabled}{NewLineChar}";
                        }
                        entriesToRecreate.Add((entry.Name, contents.Split(Splitters, StringSplitOptions.None).ToList()));
                    }

                    for (var i = 0; i < entriesToRecreate.Count; i++)
                    {
                        var oldEntry = zip.GetEntry(entriesToRecreate[i].Item1);
                        oldEntry.Delete();
                        var entry = zip.CreateEntry(entriesToRecreate[i].Item1);
                        using (var stream = new StreamWriter(entry.Open(), encoding))
                        {
                            stream.NewLine = NewLineChar;
                            for (var j = 0; j < entriesToRecreate[i].Item2.Count; j++)
                            {
                                stream.WriteLine(entriesToRecreate[i].Item2[j]);
                            }
                        }
                    }
                }
            }
            
            status_txt.Text = isIronman ? "Save is IRONMAN" : "Save is NOT IRONMAN";
        }

        private void select_btn_Click(object sender, EventArgs e)
        {
            FileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Stellaris Save Files (*.sav)|*.sav";
            dialog.ShowDialog();
            if (dialog.FileNames.Length > 0)
            {
                GetFileNames(dialog.FileName);
                isIronman = false;
                using (var fileStream = File.OpenRead(dialog.FileName))
                {
                    using (var zip = new ZipArchive(fileStream, ZipArchiveMode.Read))
                    {
                        var entry = zip.Entries.FirstOrDefault(x => x.Name == MetaFile);
                        if (entry == null)
                        {
                            throw new FileNotFoundException("Meta file not found! Save is not valid!");
                        }

                        var contents = ReadFileStream(new StreamReader(entry.Open(), encoding));
                        if (contents.Contains(IronmanEnabled))
                        {
                            isIronman = true;
                        }
                    }
                }

                file_txt.Text = BaseFullFilePath;
                status_txt.Text = isIronman ? "Save is IRONMAN" : "Save is NOT IRONMAN";
            }
        }

        private void GetFileNames(string filePath)
        {
            BaseFullFilePath = filePath;
            BaseDirectory = Path.GetDirectoryName(filePath);
            BaseName = Path.GetFileNameWithoutExtension(filePath);


            // Rename the file to be called *.zip rather than *.sav
            RenamedBaseFullFilePath = Path.Combine(BaseDirectory, $"{BaseName}.zip");
            if (File.Exists(RenamedBaseFullFilePath))
            {
                File.Delete(RenamedBaseFullFilePath);
            }
        }

        private void CreateBackup()
        {
            BackupFilePath = "";
            var i = 1;
            do
            {
                BackupFilePath = Path.Combine(BaseDirectory, $"{BaseName}_backup{i++}.sav");
            } while (File.Exists(BackupFilePath));
            File.Copy(BaseFullFilePath, BackupFilePath);
        }
    }
}