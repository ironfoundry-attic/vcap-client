// -----------------------------------------------------------------------
// <copyright file="VcapFilesResult.cs" company="Tier 3">
// Copyright © 2012 Tier 3 Inc., All Rights Reserved
// </copyright>
// -----------------------------------------------------------------------

namespace IronFoundry.VcapClient
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class VcapFilesResult : VcapClientResult
    {
        private IList<FilesResultData> files = new List<FilesResultData>();
        private IList<FilesResultData> dirs = new List<FilesResultData>();

        public VcapFilesResult() : base()
        {
        }

        public VcapFilesResult(bool success) : base(success)
        {
        }

        public VcapFilesResult(byte[] file)
        {
            if (null == file)
            {
                throw new ArgumentNullException("file");
            }
            else
            {
                File = file;
            }
        }

        public bool IsFile
        {
            get { return null != File; }
        }

        [JsonIgnore]
        public byte[] File
        {
            get;
            private set;
        }

        public IEnumerable<FilesResultData> Files
        {
            get { return files; }
        }

        public IEnumerable<FilesResultData> Directories
        {
            get { return dirs; }
        }

        public void AddFile(string fileName, string fileSize)
        {
            files.Add(new FilesResultData(fileName, fileSize));
        }

        public void AddDirectory(string dirName)
        {
            dirs.Add(new FilesResultData(dirName));
        }

        public class FilesResultData
        {
            public string Name { get; private set; }
            public string Size { get; private set; }

            public FilesResultData(string name)
            {
                Name = name.Trim();
            }

            public FilesResultData(string name, string size)
            {
                Name = name.Trim();
                Size = size.Trim();
            }
        }
    }
}
