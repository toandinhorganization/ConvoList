using ConvoList.Models;
using SQLite;

namespace ConvoList.Services
{
    public class TodoService
    {
        private SQLiteAsyncConnection _database;

        public TodoService()
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "todo.db3");
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<TodoItem>().Wait();
        }

        public Task<List<TodoItem>> GetTodosAsync()
        {
            return _database.Table<TodoItem>().ToListAsync();
        }

        public Task<int> SaveTodoAsync(TodoItem item)
        {
            if (item.ID != 0)
            {
                return _database.UpdateAsync(item);
            }
            else
            {
                return _database.InsertAsync(item);
            }
        }

        public Task<int> DeleteTodoAsync(TodoItem item)
        {
            return _database.DeleteAsync(item);
        }
    }
}
