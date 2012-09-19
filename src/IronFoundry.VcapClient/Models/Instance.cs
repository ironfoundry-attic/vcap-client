// -----------------------------------------------------------------------
// <copyright file="Instance.cs" company="Tier 3">
// Copyright © 2012 Tier 3 Inc., All Rights Reserved
// </copyright>
// -----------------------------------------------------------------------

namespace IronFoundry.Models
{
    using System;
    using System.Collections.Generic;

    [Serializable]
    public class Instance : EntityBase
    {
        private int cores;
        private float cpu;
        private long disk;
        private long diskQuota;
        private string host;
        private int id;
        private long memory;
        private long memoryQuota;
        private Application parent;
        private string state;
        private TimeSpan uptime;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string State
        {
            get { return state; }
            set { state = value; }
        }

        public int Cores
        {
            get { return cores; }
            set { cores = value; }
        }

        public long MemoryQuota
        {
            get { return memoryQuota; }
            set { memoryQuota = value; }
        }

        public long DiskQuota
        {
            get { return diskQuota; }
            set { diskQuota = value; }
        }

        public string Host
        {
            get { return host; }
            set { host = value; }
        }

        public float Cpu
        {
            get { return cpu; }
            set { cpu = value; }
        }

        public long Memory
        {
            get { return memory; }
            set { memory = value; }
        }

        public long Disk
        {
            get { return disk; }
            set { disk = value; }
        }

        public TimeSpan Uptime
        {
            get { return uptime; }
            set { uptime = value; }
        }

        public Application Parent
        {
            get { return parent; }
            set { parent = value; }
        }
    }
}
