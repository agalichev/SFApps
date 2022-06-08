﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleEightTasks
{
    public static class DirectoryExtension
    {
        public static long DirSize(DirectoryInfo d)
        {
            long size = 0;

            FileInfo[] fis = d.GetFiles();
            foreach(FileInfo fi in fis)
            {
                size += fi.Length;
            }

            DirectoryInfo[] dis = d.GetDirectories();
            foreach(DirectoryInfo di in dis)
            {
                size += DirSize(di);
            }
            return size;
        }

    }
}
