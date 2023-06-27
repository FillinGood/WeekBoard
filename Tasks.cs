using System.Collections.Generic;

namespace WeekBoard {
    public static class Tasks {
        private static List<BoardTask> list = new();
        public static IEnumerable<BoardTask> All => list;

        public static void Set(IEnumerable<BoardTask> tasks) {
            list.Clear();
            list.AddRange(tasks);
        }
        public static void Add(BoardTask task) {
            list.Add(task);
        }
        public static void Remove(BoardTask task) {
            list.Remove(task);
        }
    }
}
