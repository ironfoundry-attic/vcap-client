// -----------------------------------------------------------------------
// <copyright file="VcapFilesResult.cs" company="Tier 3">
// Copyright © 2012 Tier 3 Inc., All Rights Reserved
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace IronFoundry.VcapClient
{
    public class VcapFilesResult : VcapClientResult
    {
        private readonly IList<FilesResultData> dirs = new List<FilesResultData>();
        private readonly IList<FilesResultData> files = new List<FilesResultData>();

        public VcapFilesResult()
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
        public byte[] File { get; private set; }

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

        #region Nested type: FilesResultData

        public class FilesResultData
        {
            public FilesResultData(string name)
            {
                Name = name.Trim();
            }

            public FilesResultData(string name, string size)
            {
                Name = name.Trim();
                Size = size.Trim();
            }

            public string Name { get; private set; }
            public string Size { get; private set; }
        }

        #endregion
    }
}