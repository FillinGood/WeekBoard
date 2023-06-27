using System;
using System.IO;
using System.Text;

namespace WeekBoard {
    public static class TaskSerializer {
        public const string PATH = "tasks.bin";

        public static void Save(BoardTask[] tasks) {
            using FileStream fs = new(PATH, FileMode.Create, FileAccess.Write, FileShare.Read);
            using BinaryWriter bw = new(fs);

            bw.Write(Encoding.ASCII.GetBytes("WEEB"));
            bw.Write(tasks.Length);
            foreach(BoardTask task in tasks) {
                bw.Write(task.StartDate.DayNumber);
                bw.Write(task.Name);
                bw.Write(task.Description);
                bw.Write(task.EndDate.HasValue ? task.EndDate.Value.DayNumber : 0);
                bw.Write(task.Interval.HasValue ? (int)task.Interval.Value.TotalDays : 0);
            }
        }

        public static BoardTask[] Load() {
            using FileStream fs = new(PATH, FileMode.Open, FileAccess.Read, FileShare.Read);
            using BinaryReader br = new(fs);

            if(Encoding.ASCII.GetString(br.ReadBytes(4)) != "WEEB")
                throw new System.FormatException("Invalid file magic");

            int length = br.ReadInt32();
            BoardTask[] tasks = new BoardTask[length];
            
            for (int i =0; i < length; i++) {
                int startDays = br.ReadInt32();
                BoardTask task = new(DateOnly.FromDayNumber(startDays));
                task.Name= br.ReadString();
                task.Description= br.ReadString();
                int endDays = br.ReadInt32();
                int intervalDays = br.ReadInt32();
                if (endDays > 0) task.EndDate = DateOnly.FromDayNumber(endDays);
                if (intervalDays> 0) task.Interval = TimeSpan.FromDays(intervalDays);
                tasks[i] = task;
            }

            return tasks;
        }
    }
}
